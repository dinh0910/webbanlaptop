using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using webbanlaptop.Data;
using webbanlaptop.Models;

namespace webbanlaptop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MausController : Controller
    {
        private readonly webbanlaptopContext _context;
        private readonly IToastNotification _toastNotification;

        public MausController(webbanlaptopContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Mau.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MauID,Ten")] Mau mau)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mau);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Thêm thành công!");
                return RedirectToAction(nameof(Index));
            }
            _toastNotification.AddErrorToastMessage("Thêm thất bại!");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mau == null)
            {
                return NotFound();
            }

            var mau = await _context.Mau
                .FirstOrDefaultAsync(m => m.MauID == id);
            if (mau == null)
            {
                return NotFound();
            }
            else
            {
                _toastNotification.AddSuccessToastMessage("Xóa thành công!");
                _context.Mau.Remove(mau);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
