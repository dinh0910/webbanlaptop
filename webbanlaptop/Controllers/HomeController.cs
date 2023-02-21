using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using webbanlaptop.Models;
using webbanlaptop.Libs;
using webbanlaptop.Data;
using Microsoft.AspNetCore.Authentication;


namespace webbanlaptop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly webbanlaptopContext _context;
        public INotyfService _notifyService { get; }

        public const string SessionTK = "_TaiKhoanID";
        public const string SessionHoten = "_HoTen";
        public const string SessionTenDN = "_TenTaiKhoan";
        public const string SessionEmail = "_Email";
        public const string SessionSDT = "_SDT";
        public const string SessionDiaChi = "_DiaChi";

        public HomeController(ILogger<HomeController> logger, webbanlaptopContext context, INotyfService notifyService)
        {
            _logger = logger;
            _context = context;
            _notifyService = notifyService;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(TaiKhoanLogin TaiKhoan)
        {
            if (ModelState.IsValid)
            {
                string mahoamatkhau = SHA1.ComputeHash(TaiKhoan.MatKhau);
                var taiKhoan = await _context.TaiKhoan.FirstOrDefaultAsync(r => r.TenTaiKhoan == TaiKhoan.TenTaiKhoan && r.MatKhau == mahoamatkhau);

                if (taiKhoan == null)
                {
                    TempData["AlertMessageLogin"] = "Đăng nhập không thành công!";
                }
                else
                {
                    // Đăng ký SESSION

                    HttpContext.Session.SetInt32(SessionTK, (int)taiKhoan.TaiKhoanID);
                    HttpContext.Session.SetString(SessionHoten, taiKhoan.HoTen);
                    HttpContext.Session.SetString(SessionTenDN, taiKhoan.TenTaiKhoan);
                    HttpContext.Session.SetString(SessionEmail, taiKhoan.Email);
                    HttpContext.Session.SetString(SessionSDT, taiKhoan.SoDienThoai);
                    HttpContext.Session.SetString(SessionDiaChi, taiKhoan.DiaChi);


                    //var cart = _context.Carts.FirstOrDefault(x => x.IdKh == (int)HttpContext.Session.GetInt32("_IdKhachHang"));
                    /*if (cart is not null)
                    {
                        var data = JsonConvert.DeserializeObject<List<CartItem>>(cart.Data);

                        HttpContext.Session.SetInt32("CartNumber", data.Count);
                    }*/

                    _notifyService.Success("Đăng nhập thành công ");
                    TempData["AlertMessageLogin"] = "Đăng nhập thành công!";


                    // Quay về trang chủ
                    return RedirectToAction("Index", "Home");
                    //return View(TaiKhoan);
                }
            }

            TempData["AlertMessageLogin"] = "Đăng nhập thành công!";

            return RedirectToAction("Index", "Home");
            //return View(TaiKhoan);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}