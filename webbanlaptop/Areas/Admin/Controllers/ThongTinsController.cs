using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using webbanlaptop.Data;

namespace webbanlaptop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThongTinsController : Controller
    {
        private readonly webbanlaptopContext _context;
        private readonly IToastNotification _toastNotification;

        public ThongTinsController(webbanlaptopContext context, IToastNotification toastNotification)
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


    }
}
