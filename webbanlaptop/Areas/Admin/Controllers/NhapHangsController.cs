using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using webbanlaptop.Data;
using webbanlaptop.Libs;
using webbanlaptop.Models;

namespace webbanlaptop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NhapHangsController : Controller
    {
        private readonly webbanlaptopContext _context;
        private readonly IToastNotification _toastNotification;

        public NhapHangsController(webbanlaptopContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        // GET: Admin/DanhMucs
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("_TaiKhoanID") != null)
            {
                var webbanlaptopContext = _context.NhapHang.Include(t => t.TaiKhoans)
                                                           .Include(t => t.NhaCungCaps);
                return View(await webbanlaptopContext.ToListAsync());
            }
            return RedirectToAction("Login", "Home");
        }


    }
}
