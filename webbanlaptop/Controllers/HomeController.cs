using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.Diagnostics;
using webbanlaptop.Data;
using webbanlaptop.Libs;
using webbanlaptop.Models;

namespace webbanlaptop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly webbanlaptopContext _context;
        private readonly IToastNotification _toastNotification;

        public const string SessionTK = "_TaiKhoanID";
        public const string SessionHoten = "_HoTen";
        public const string SessionTenDN = "_TenTaiKhoan";
        public const string SessionEmail = "_Email";
        public const string SessionSDT = "_SDT";
        public const string SessionDiaChi = "_DiaChi";

        public HomeController(ILogger<HomeController> logger, webbanlaptopContext context, IToastNotification toastNotification)
        {
            _logger = logger;
            _context = context;
            _toastNotification = toastNotification;
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
                var taiKhoan = await _context.TaiKhoan.FirstOrDefaultAsync(r => r.TenTaiKhoan == TaiKhoan.TenTaiKhoan
                                                                            && r.MatKhau == mahoamatkhau
                                                                            && r.QuyenID == 2);
                if (taiKhoan == null)
                {
                    _toastNotification.AddErrorToastMessage("Đăng nhập không thành công!");
                }
                else
                {
                    // Đăng ký SESSION
                    HttpContext.Session.SetInt32(SessionTK, (int)taiKhoan.TaiKhoanID);
                    HttpContext.Session.SetString(SessionTenDN, taiKhoan.TenTaiKhoan);
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
                    }
                    _toastNotification.AddErrorToastMessage("Mật khẩu phải nhiều hơn 8 ký tự, ít nhất 1 chữ thường 1 chữ in hoa, 1 chữ số, 1 ký tự đặc biệt!");
                }
                else
                {
                    _toastNotification.AddWarningToastMessage("Tên đăng nhập đã tồn tại. Bạn hãy nhập tên khác!");
                    return View();
                }
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("_TaiKhoanID");
            //HttpContext.Session.Remove("_Hoten");
            HttpContext.Session.Remove("_TenTaiKhoan");
            //HttpContext.Session.Remove("_Quyen");
            //HttpContext.Session.Remove("_HinhAnh");
            //HttpContext.Session.Remove("_Email");

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Register()
        {
            return View();
        }

        public IActionResult ChangePassword() 
        { 
            return View();
        }

        public IActionResult PersonalInformation()
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