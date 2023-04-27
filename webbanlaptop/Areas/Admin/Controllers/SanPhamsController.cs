using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NToastNotify;
using System.Reflection;
using webbanlaptop.Data;
using webbanlaptop.Models;

namespace webbanlaptop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamsController : Controller
    {
        private readonly webbanlaptopContext _context;
        private readonly IToastNotification _toastNotification;

        public SanPhamsController(webbanlaptopContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var webbanlaptopContext = _context.SanPham.Include(d => d.DanhMucs).Include(s => s.ThuongHieus);
            ViewData["DanhMucID"] = new SelectList(_context.DanhMuc, "DanhMucID", "Ten");
            ViewData["ThuongHieuID"] = new SelectList(_context.ThuongHieu, "ThuongHieuID", "Ten");
            return View(await webbanlaptopContext.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, [Bind("SanPhamID,DanhMucID,ThuongHieuID,Ten,HinhAnh,DonGia,GiamGia,DacTrung,ThanhTien")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                sanPham.HinhAnh = Upload(file);
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Thêm thành công!");
                return RedirectToAction(nameof(Index));
            }
            _toastNotification.AddErrorToastMessage("Thêm thất bại!");
            ViewData["DanhMucID"] = new SelectList(_context.DanhMuc, "DanhMucID", "Ten", sanPham.DanhMucID);
            ViewData["ThuongHieuID"] = new SelectList(_context.ThuongHieu, "ThuongHieuID", "Ten", sanPham.ThuongHieuID);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var sanPham = await _context.SanPham.FindAsync(id);
            ViewData["DanhMucID"] = new SelectList(_context.DanhMuc, "DanhMucID", "Ten", sanPham.DanhMucID);
            ViewData["ThuongHieuID"] = new SelectList(_context.ThuongHieu, "ThuongHieuID", "Ten", sanPham.ThuongHieuID);
            return View(sanPham);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SanPhamID,DanhMucID,ThuongHieuID,Ten,HinhAnh,DonGia,GiamGia,DacTrung,ThanhTien,SoLuong")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.SanPhamID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMucID"] = new SelectList(_context.DanhMuc, "DanhMucID", "Ten", sanPham.DanhMucID);
            ViewData["ThuongHieuID"] = new SelectList(_context.ThuongHieu, "ThuongHieuID", "Ten", sanPham.ThuongHieuID);
            return View(sanPham);
        }

        private bool SanPhamExists(int id)
        {
            return _context.SanPham.Any(e => e.SanPhamID == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SanPham == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham
                .Include(d => d.DanhMucs)
                .Include(d => d.ThuongHieus)
                .FirstOrDefaultAsync(m => m.SanPhamID == id);
            if (sanPham == null)
            {
                return NotFound();
            }
            else
            {
                _toastNotification.AddSuccessToastMessage("Xóa thành công!");
                _context.SanPham.Remove(sanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public string Upload(IFormFile file)
        {
            string fn = null;

            if (file != null)
            {
                fn = Guid.NewGuid().ToString() + "_" + file.FileName;
                var path = $"wwwroot\\images\\products\\{fn}"; // đường dẫn lưu file
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return fn;
        }

        public const string CARTIMPORT = "addcart";

        public async Task<IActionResult> Stored()
        {
            if (HttpContext.Session.GetInt32("_TaiKhoanID") != null)
            {
                var webbanlaptopContext = _context.SanPham;
                ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "Ten");
                ViewData["DonViTinhID"] = new SelectList(_context.DonViTinh, "DonViTinhID", "Ten");
                return View(await webbanlaptopContext.ToListAsync());
            }
            return RedirectToAction("Login", "Home");
        }

        public async Task<IActionResult> HistoryImport()
        {
            if (HttpContext.Session.GetInt32("_TaiKhoanID") != null)
            {
                var webbanlaptopContext = _context.NhapHang.Include(s => s.TaiKhoans).Include(s => s.NhaCungCaps);
                ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "Ten");
                ViewData["DonViTinhID"] = new SelectList(_context.DonViTinh, "DonViTinhID", "Ten");
                return View(await webbanlaptopContext.ToListAsync());
            }
            return RedirectToAction("Login", "Home");
        }

        public async Task<IActionResult> ImportDetails(int? id)
        {
            var webbanlaptopContext = _context.ChiTietNhapHang
                .Include(c => c.NhapHangs)
                .Include(c => c.SanPhams)
                .Include(c => c.DonViTinhs)
                .Where(m => m.NhapHangID == id);

            return View(await webbanlaptopContext.ToListAsync());
        }

        List<ImportItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTIMPORT);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<ImportItem>>(jsoncart);
            }
            return new List<ImportItem>();
        }

        // Lưu danh sách CartItem trong giỏ hàng vào session
        void SaveCartSession(List<ImportItem> list)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(list);
            session.SetString("addcart", jsoncart);
        }

        // Xóa session giỏ hàng
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove("addcart");
        }

        // Cho hàng vào giỏ
        public async Task<IActionResult> AddToCart([Bind("SanPhamID,DonViTinhID,SoLuong")] ImportItem importItem)
        {
            var product = await _context.SanPham
                .FirstOrDefaultAsync(m => m.SanPhamID == importItem.SanPhamID);
            var dvt = await _context.DonViTinh
                .FirstOrDefaultAsync(m => m.DonViTinhID == importItem.DonViTinhID);
            if (product == null)
            {
                _toastNotification.AddInfoToastMessage("Sản phẩm không tồn tại.");
            }
            var cart = GetCartItems();
            var item = cart.Find(p => p.SanPham.SanPhamID == importItem.SanPhamID);
            if (item != null)
            {
                item.SoLuong += importItem.SoLuong;
            }
            else
            {
                cart.Add(new ImportItem() { SanPham = product, DonViTinh = dvt, SoLuong = importItem.SoLuong });
            }
            SaveCartSession(cart);
            //return RedirectToAction(nameof(ViewImport));
            return RedirectToAction("Stored", "SanPhams");
        }

        [Route("/updateitem", Name = "updateitem")]
        public async Task<IActionResult> UpdateItem(int id, int quantity)
        {
            var cart = GetCartItems();
            var item = cart.Find(p => p.SanPham.SanPhamID == id);
            if (quantity == 0)
            {
                cart.Remove(item);
            }
            item.SoLuong = quantity;
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewImport));
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
            return RedirectToAction(nameof(ViewImport));
        }

        [Route("/viewimport", Name = "import")]
        public IActionResult ViewImport()
        {
            ViewData["NhaCungCapID"] = new SelectList(_context.NhaCungCap, "NhaCungCapID", "Ten");
            return View(GetCartItems());
        }

        public async Task<IActionResult> CreateBill(int NhaCungCapID)
        {
            // lưu hóa đơn
            var bill = new NhapHang();
            bill.NgayNhap = DateTime.Now;
            bill.NhaCungCapID = NhaCungCapID;
            bill.TaiKhoanID = (int)HttpContext.Session.GetInt32("_TaiKhoanID");

            _context.Add(bill);
            await _context.SaveChangesAsync();

            var cart = GetCartItems();
            int amount = 0;
            int soLuong = 0;
            //chi tiết hóa đơn
            foreach (var i in cart)
            {
                var b = new ChiTietNhapHang();
                b.NhapHangID = bill.NhapHangID;
                b.SanPhamID = i.SanPham.SanPhamID;
                b.DonViTinhID = i.DonViTinh.DonViTinhID;
                b.DonGia = i.SanPham.ThanhTien;
                b.SoLuong = i.SoLuong;
                amount = i.SanPham.ThanhTien * i.SoLuong;
                b.ThanhTien = amount;

                var sp = _context.SanPham.FirstOrDefault(s => s.SanPhamID == b.SanPhamID);
                sp.SoLuong += i.SoLuong;
                bill.TongTien += amount;
                _context.Add(b);
            }
            await _context.SaveChangesAsync();
            ClearCart();
            return RedirectToAction(nameof(Stored));
        }

        public async Task<IActionResult> Details(int? id)
        {
            var sp = await _context.SanPham.FirstOrDefaultAsync(s => s.SanPhamID == id);
            ViewBag.thongtin = _context.ThongTin;
            ViewBag.thongso = _context.ThongSo;
            ViewBag.hinhanh = _context.HinhAnh;
            ViewBag.khuyenmai = _context.KhuyenMai;
            return View(sp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int id, [Bind("ThongTinID,SanPhamID,TrongHop,BaoHanh,ChinhSach")] ThongTin thongTin
            , [Bind("KhuyenMaiID,SanPhamID,NoiDung")] KhuyenMai khuyenMai, [Bind("ThongSoID,SanPhamID,TenThongSo,NoiDungTS")] ThongSo thongSo,
            IFormFile file, [Bind("HinhAnhID,SanPhamID,Anh")] HinhAnh hinhAnh)
        {
            if(thongTin.BaoHanh != null || thongTin.BaoHanh != null || thongTin.ChinhSach != null)
            {
                _context.Update(thongTin);
                await _context.SaveChangesAsync();
            } 
            else if (khuyenMai.NoiDung != null)
            {
                _context.Update(khuyenMai);
                await _context.SaveChangesAsync();
            } 
            else if (thongSo.TenThongSo != null || thongSo.NoiDungTS != null)
            {
                _context.Update(thongSo);
                await _context.SaveChangesAsync();
            }
            else 
            {
                hinhAnh.Anh = Upload(file);
                _context.Update(hinhAnh);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction("Details", "SanPhams", routeValues: new { id });
        }

        public async Task<IActionResult> DeleteThongTin(int? id)
        {
            var tt = await _context.ThongTin
                .FirstOrDefaultAsync(m => m.SanPhamID == id);

            _context.ThongTin.Remove(tt);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "SanPhams", routeValues: new { id });
        }

        public async Task<IActionResult> DeleteThongSo(int? id)
        {
            var ts = await _context.ThongSo
                .FirstOrDefaultAsync(m => m.SanPhamID == id);

            _context.ThongSo.Remove(ts);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "SanPhams", routeValues: new { id });
        }

        public async Task<IActionResult> DeleteKhuyenMai(int? id)
        {
            var tt = await _context.KhuyenMai
                .FirstOrDefaultAsync(m => m.KhuyenMaiID == id);

            _context.KhuyenMai.Remove(tt);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "SanPhams", routeValues: new { id });
        }

        public async Task<IActionResult> DeleteHinhAnh(int? id)
        {
            var tt = await _context.HinhAnh
                .FirstOrDefaultAsync(m => m.HinhAnhID == id);

            _context.HinhAnh.Remove(tt);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "SanPhams", routeValues: new { id });
        }
    }
}
