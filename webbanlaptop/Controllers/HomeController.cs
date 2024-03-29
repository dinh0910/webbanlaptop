﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NToastNotify;
using System.Diagnostics;
using System.Net.WebSockets;
using webbanlaptop.Data;
using webbanlaptop.Libs;
using webbanlaptop.Models;
using XAct;

namespace webbanlaptop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly webbanlaptopContext _context;
        private readonly IToastNotification _toastNotification;

        public const string SessionTK = "_TaiKhoanIDU";
        public const string SessionHoten = "_HoTenU";
        public const string SessionTenDN = "_TenTaiKhoanU";
        public const string SessionMK = "_MatKhauU";
        public const string SessionEmail = "_EmailU";
        public const string SessionSDT = "_SDTU";
        public const string SessionDiaChi = "_DiaChiU";

        public HomeController(ILogger<HomeController> logger, webbanlaptopContext context, IToastNotification toastNotification)
        {
            _logger = logger;
            _context = context;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            ViewBag.banner = _context.Banner;
            ViewBag.danhmuc = _context.DanhMuc;
            ViewBag.sanPham = _context.SanPham;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(TaiKhoanLogin TaiKhoan)
        {
            if (ModelState.IsValid)
            {
                string mahoamatkhau = SHA1.ComputeHash(TaiKhoan.MatKhau);
                var taiKhoan = await _context.TaiKhoan.FirstOrDefaultAsync(r => r.TenTaiKhoan == TaiKhoan.TenTaiKhoan
                                                                            && r.MatKhau == mahoamatkhau
                                                                            && r.QuyenID == 3);
                if (taiKhoan == null)
                {
                    _toastNotification.AddErrorToastMessage("Đăng nhập không thành công!");
                }
                else
                {
                    // Đăng ký SESSION
                    HttpContext.Session.SetInt32(SessionTK, (int)taiKhoan.TaiKhoanID);
                    HttpContext.Session.SetString(SessionTenDN, taiKhoan.TenTaiKhoan);
                    HttpContext.Session.SetString(SessionMK, taiKhoan.MatKhau);
                    //HttpContext.Session.SetString(SessionHoten, taiKhoan.HoTen);
                    //HttpContext.Session.SetString(SessionEmail, taiKhoan.Email);
                    //HttpContext.Session.SetString(SessionSDT, taiKhoan.SoDienThoai);
                    //HttpContext.Session.SetString(SessionDiaChi, taiKhoan.DiaChi);

                    _toastNotification.AddSuccessToastMessage("Đăng nhập thành công!");
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(TaiKhoan);
        }

        public void OnGet()
        {
            // Success Toast
            _toastNotification.AddSuccessToastMessage("Woo hoo - it works!");

            // Info Toast
            _toastNotification.AddInfoToastMessage("Here is some information.");

            // Error Toast
            _toastNotification.AddErrorToastMessage("Woops an error occured.");

            // Warning Toast
            _toastNotification.AddWarningToastMessage("Here is a simple warning!");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,TenTaiKhoan,MatKhau")] TaiKhoan TaiKhoan)
        {
            if (ModelState.IsValid)
            {
                var check = _context.TaiKhoan.FirstOrDefault(r => r.TenTaiKhoan == TaiKhoan.TenTaiKhoan);
                if (check == null)
                {
                    if (RegexPassword.Validation(TaiKhoan.MatKhau))
                    {
                        TaiKhoan.MatKhau = SHA1.ComputeHash(TaiKhoan.MatKhau);
                        _context.Add(TaiKhoan);
                        await _context.SaveChangesAsync();
                        _toastNotification.AddSuccessToastMessage("Đăng ký tài khoản thành công!");
                        return RedirectToAction("Login", "Home");
                    } else
                    {
                        _toastNotification.AddErrorToastMessage("Mật khẩu phải nhiều hơn 8 ký tự, ít nhất 1 chữ thường 1 chữ in hoa, 1 chữ số, 1 ký tự đặc biệt!");
                        return RedirectToAction("Register", "Home");
                    }
                }
                else
                {
                    _toastNotification.AddWarningToastMessage("Tên đăng nhập đã tồn tại. Bạn hãy nhập tên khác!");
                    return RedirectToAction("Register", "Home");
                }
            }
            return RedirectToAction("Register", "Home");
        }

        public IActionResult Login()
        {
            ViewBag.danhmuc = _context.DanhMuc;
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("_TaiKhoanIDU");
            //HttpContext.Session.Remove("_Hoten");
            HttpContext.Session.Remove("_TenTaiKhoanU");
            HttpContext.Session.Remove("_MatKhauU");
            //HttpContext.Session.Remove("_Quyen");
            //HttpContext.Session.Remove("_HinhAnh");
            //HttpContext.Session.Remove("_Email");

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Register()
        {
            ViewBag.danhmuc = _context.DanhMuc;
            return View();
        }

        public IActionResult ChangePassword() 
        {
            ViewBag.danhmuc = _context.DanhMuc;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> ShopGrid(int? id)
        {
            var grid = _context.SanPham.Where(d => d.DanhMucID == id);

            ViewBag.danhmuc = _context.DanhMuc;
            ViewBag.thuonghieu = _context.ThuongHieu;

            return View(grid);
        }

        public const string CARTKEY = "shopcart";

        List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }

        List<CartLove> GetCartsLove()
        {
            var jsoncartlove = HttpContext.Request.Cookies[$"{HttpContext.Session.GetInt32("_TaiKhoanIDU")}_cartlove"];
            if (!string.IsNullOrEmpty(jsoncartlove))
            {
                return JsonConvert.DeserializeObject<List<CartLove>>(jsoncartlove);
            }
            return new List<CartLove>();
        }

        // Lưu danh sách CartItem trong giỏ hàng vào session
        void SaveCartSession(List<CartItem> list)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(list);
            session.SetString(CARTKEY, jsoncart);
        }

        // Xóa session giỏ hàng
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }
        
        // Lưu danh sách CartItem trong giỏ hàng vào session
        void SaveCartLoveSession(List<CartLove> love)
        {
            string jsoncartlove = JsonConvert.SerializeObject(love);
            HttpContext.Response.Cookies.Append($"{HttpContext.Session.GetInt32(SessionTK)}_cartlove", jsoncartlove);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            ViewBag.danhmuc = _context.DanhMuc;
            var product = await _context.SanPham
                .FirstOrDefaultAsync(m => m.SanPhamID == id);
            if (product == null)
            {
                _toastNotification.AddInfoToastMessage("Sản phẩm không tồn tại.");
            }
            var cart = GetCartItems();
            var item = cart.Find(p => p.SanPham.SanPhamID == id);
            if (item != null)
            {
                item.SoLuong++;
            }
            else
            {
                cart.Add(new CartItem() { SanPham = product, SoLuong = 1 });
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }

        public async Task<IActionResult> AddToCartHasCount([Bind("SanPhamID,SoLuong")] CartItem cartItem)
        {
            ViewBag.danhmuc = _context.DanhMuc;
            var product = await _context.SanPham
                .FirstOrDefaultAsync(m => m.SanPhamID == cartItem.SanPhamID);
            if (product == null)
            {
                _toastNotification.AddInfoToastMessage("Sản phẩm không tồn tại.");
            }
            var cart = GetCartItems();
            var item = cart.Find(p => p.SanPham.SanPhamID == cartItem.SanPhamID);
            if (item != null)
            {
                item.SoLuong+=cartItem.SoLuong;
                if(item.SoLuong >= 5)
                {
                    _toastNotification.AddWarningToastMessage("Sản phẩm bạn chọn vượt mức cho phép!");
                    cart.Remove(item);
                }
            }
            else
            {
                if (cartItem.SoLuong >= 5)
                {
                    _toastNotification.AddWarningToastMessage("Sản phẩm bạn chọn vượt mức cho phép!");
                    cart.Remove(item);
                }
                cart.Add(new CartItem() { SanPham = product, SoLuong = cartItem.SoLuong });
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }

        public async Task<IActionResult> AddToCartLove(int id)
        {
            if (HttpContext.Session.GetInt32("_TaiKhoanIDU") != null)
            {
                ViewBag.danhmuc = _context.DanhMuc;
                var product = await _context.SanPham
                    .FirstOrDefaultAsync(m => m.SanPhamID == id);
                if (product == null)
                {
                    _toastNotification.AddInfoToastMessage("Sản phẩm không tồn tại.");
                }
                var cart = GetCartsLove();
                cart.Add(new CartLove() { SanPhams = product });

                SaveCartLoveSession(cart);
                return RedirectToAction(nameof(ViewLove));
            }
            return RedirectToAction("Login", "Home");
        }

        public async Task<IActionResult> UpdateItem(int id, int quantity)
        {
            var cart = GetCartItems();
            var item = cart.Find(p => p.SanPham.SanPhamID == id);
            if (quantity == 0)
            {
                cart.Remove(item);
            } else if(quantity >= 5)
            {
                _toastNotification.AddWarningToastMessage("Sản phẩm bạn chọn vượt mức cho phép!");
                cart.Remove(item);
            }
            item.SoLuong = quantity;
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }

        public async Task<IActionResult> RemoveItem(int id)
        {
            var cart = GetCartItems();
            var item = cart.Find(p => p.SanPham.SanPhamID == id);
            if (item != null)
            {
                cart.Remove(item);
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }

        public async Task<IActionResult> RemoveItemLove(int id)
        {
            var cart = GetCartsLove();
            var item = cart.Find(p => p.SanPhams.SanPhamID == id);
            if (item != null)
            {
                cart.Remove(item);
            }
            SaveCartLoveSession(cart);
            return RedirectToAction(nameof(ViewLove));
        }


        // Chuyển đến view xem giỏ hàng
        public IActionResult ViewCart()
        {
            ViewBag.danhmuc = _context.DanhMuc;

            return View(GetCartItems());
        }
        
        public IActionResult ViewLove()
        {
            if (HttpContext.Session.GetInt32("_TaiKhoanIDU") != null)
            {
                ViewBag.danhmuc = _context.DanhMuc;

                return View(GetCartsLove());
            }
            return RedirectToAction("Login", "Home");
        }

        public IActionResult CheckOut()
        {
            ViewBag.danhmuc = _context.DanhMuc;

            return View(GetCartItems());
        }

        public async Task<IActionResult> CreateBill(string Ten, string SoDienThoai, string DiaChi, string Email, string GhiChu)
        {
            // lưu hóa đơn
            var bill = new DonDatHang();
            bill.NgayLap = DateTime.Now;
            bill.HoTen = Ten;
            bill.SoDienThoai = SoDienThoai;
            bill.DiaChi = DiaChi;
            bill.Email = Email;
            bill.GhiChu = GhiChu;

            _context.Add(bill);
            await _context.SaveChangesAsync();

            var cart = GetCartItems();
            int amount = 0;
            int soLuong = 0;

            //chi tiết hóa đơn
            foreach (var i in cart)
            {
                var b = new ChiTietDatHang();
                b.DonDatHangID = bill.DonDatHangID;
                b.SanPhamID = i.SanPham.SanPhamID;
                b.DonGia = i.SanPham.ThanhTien;
                b.SoLuong = i.SoLuong;
                amount = i.SanPham.ThanhTien * i.SoLuong;
                b.ThanhTien = amount;

                var sp = _context.SanPham.FirstOrDefault(s => s.SanPhamID == b.SanPhamID);
                sp.SoLuong -= i.SoLuong;
                bill.TongTien += amount;
                _context.Add(b);
            }
            await _context.SaveChangesAsync();
            ClearCart();
            return RedirectToAction(nameof(Message));
        }

        public IActionResult Message()
        {
            ViewBag.danhmuc = _context.DanhMuc;

            return View();
        }

        public async Task<IActionResult> PersonalInformation(int? id)
        {
            var taikhoan = await _context.TaiKhoan.FindAsync(id);
            ViewBag.danhmuc = _context.DanhMuc;

            return View(taikhoan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PersonalInformation([Bind("TaiKhoanID","TenTaiKhoan","MatKhau","HoTen","Email","SoDienThoai","DiaChi")] TaiKhoan tk)
        {
            _context.Update(tk);
            await _context.SaveChangesAsync();

            return View(tk);
        }

        public async Task<IActionResult> SearchOrder(string? SoDienThoai)
        {
            var order = _context.DonDatHang.Where(d => d.SoDienThoai == SoDienThoai);
            ViewBag.ctdh = _context.ChiTietDatHang.Include(c => c.SanPhams);
            ViewBag.danhmuc = _context.DanhMuc;
            return View(order);
        }

        public async Task<IActionResult> Details(int? id)
        {
            var products = await _context.SanPham.FirstOrDefaultAsync(s => s.SanPhamID == id);
            ViewBag.hinhanh = _context.HinhAnh;
            ViewBag.thongtin = _context.ThongTin;
            ViewBag.thongso = _context.ThongSo;
            ViewBag.khuyenmai = _context.KhuyenMai;
            ViewBag.danhmuc = _context.DanhMuc;
            return View(products);
        }

        public async Task<IActionResult> SearchProduct(string? name)
        {
            ViewBag.danhmuc = _context.DanhMuc;
            ViewBag.thuonghieu = _context.ThuongHieu;
            var sanPham = _context.SanPham
               .Include(s => s.ThuongHieus)
               .Where(s => s.Ten.Contains(name));
            return View(sanPham);
        }

        public IActionResult Contact()
        {
            ViewBag.danhmuc = _context.DanhMuc;
            return View();
        }
    }
}