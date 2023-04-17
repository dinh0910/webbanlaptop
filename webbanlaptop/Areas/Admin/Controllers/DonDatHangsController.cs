using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webbanlaptop.Data;
using webbanlaptop.Models;

namespace webbanlaptop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DonDatHangsController : Controller
    {
        private readonly webbanlaptopContext _context;

        public DonDatHangsController(webbanlaptopContext context)
        {
            _context = context;
        }

        // GET: Admin/DonDatHangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.DonDatHang.ToListAsync());
        }

        // GET: Admin/DonDatHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DonDatHang == null)
            {
                return NotFound();
            }

            var donDatHang = await _context.DonDatHang
                .FirstOrDefaultAsync(m => m.DonDatHangID == id);
            if (donDatHang == null)
            {
                return NotFound();
            }

            return View(donDatHang);
        }

        // POST: Admin/DonDatHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DonDatHang == null)
            {
                return Problem("Entity set 'webbanlaptopContext.DonDatHang'  is null.");
            }
            var donDatHang = await _context.DonDatHang.FindAsync(id);
            if (donDatHang != null)
            {
                _context.DonDatHang.Remove(donDatHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            var webbanlaptopContext = _context.ChiTietDatHang
                .Include(c => c.DonDatHangs)
                .Include(c => c.SanPhams)
                .Where(m => m.DonDatHangID == id);

            ViewBag.ddh = _context.DonDatHang.FirstOrDefault(d => d.DonDatHangID == id);

            return View(await webbanlaptopContext.ToListAsync());
        }

        private bool DonDatHangExists(int id)
        {
          return _context.DonDatHang.Any(e => e.DonDatHangID == id);
        }
    }
}
