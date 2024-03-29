﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.Diagnostics;
using webbanlaptop.Data;
using webbanlaptop.Libs;
using webbanlaptop.Models;

namespace webbanlaptop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly webbanlaptopContext _context;
        private readonly IToastNotification _toastNotification;

        public const string SessionTKAdmin = "_TaiKhoanID";
        public const string SessionHoten = "_HoTen";
        public const string SessionTenDN = "_TenTaiKhoan";
        public const string SessionEmail = "_Email";
        public const string SessionSDT = "_SDT";
        public const string SessionDiaChi = "_DiaChi";
        public const string SessionQuyen = "_QuyenID";

        public HomeController(ILogger<HomeController> logger, webbanlaptopContext context, IToastNotification toastNotification)
        {
            _logger = logger;
            _context = context;
            _toastNotification = toastNotification;
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
                                                                            && (r.QuyenID == 1 || r.QuyenID == 2));

                if (taiKhoan == null)
                {
                    _toastNotification.AddErrorToastMessage("Đăng nhập không thành công!");
                }
                else
                {
                    // Đăng ký SESSION
                    HttpContext.Session.SetInt32(SessionTKAdmin, (int)taiKhoan.TaiKhoanID);
                    HttpContext.Session.SetString(SessionTenDN, taiKhoan.TenTaiKhoan);
                    //HttpContext.Session.SetString(SessionHoten, taiKhoan.HoTen);
                    //HttpContext.Session.SetString(SessionEmail, taiKhoan.Email);
                    //HttpContext.Session.SetString(SessionSDT, taiKhoan.SoDienThoai);
                    //HttpContext.Session.SetString(SessionDiaChi, taiKhoan.DiaChi);
                    _toastNotification.AddSuccessToastMessage("Đăng nhập thành công!");
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Login", "Home");
        }

        [Route("/admin")]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("_TaiKhoanID") == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [Route("/admin/home")]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("_TaiKhoanID") != null)
            {
                var dateNow = DateTime.Today.Date;
                var webbanlaptopContext = _context.DonDatHang.Where(d => d.NgayLap.Month == DateTime.Today.Month);
                ViewBag.dondathang = _context.DonDatHang.Where(d => d.NgayLap.Month == DateTime.Today.Month);

                return View(await webbanlaptopContext.ToListAsync());
            }
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("_TaiKhoanID");
            //HttpContext.Session.Remove("_Hoten");
            //HttpContext.Session.Remove("_TenTaiKhoan");
            //HttpContext.Session.Remove("_Quyen");
            //HttpContext.Session.Remove("_HinhAnh");
            //HttpContext.Session.Remove("_Email");

            return RedirectToAction("Index", "Home");
        }
    }
}