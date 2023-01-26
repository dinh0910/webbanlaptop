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
    public class HinhThucThanhToansController : Controller
    {
        private readonly webbanlaptopContext _context;

        public HinhThucThanhToansController(webbanlaptopContext context)
        {
            _context = context;
        }

        // GET: Admin/HinhThucThanhToans
        public async Task<IActionResult> Index()
        {
              return View(await _context.HinhThucThanhToan.ToListAsync());
        }

        // GET: Admin/HinhThucThanhToans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HinhThucThanhToan == null)
            {
                return NotFound();
            }

            var hinhThucThanhToan = await _context.HinhThucThanhToan
                .FirstOrDefaultAsync(m => m.HinhThucThanhToanID == id);
            if (hinhThucThanhToan == null)
            {
                return NotFound();
            }

            return View(hinhThucThanhToan);
        }

        // GET: Admin/HinhThucThanhToans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/HinhThucThanhToans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HinhThucThanhToanID,Ten")] HinhThucThanhToan hinhThucThanhToan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hinhThucThanhToan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hinhThucThanhToan);
        }

        // GET: Admin/HinhThucThanhToans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HinhThucThanhToan == null)
            {
                return NotFound();
            }

            var hinhThucThanhToan = await _context.HinhThucThanhToan.FindAsync(id);
            if (hinhThucThanhToan == null)
            {
                return NotFound();
            }
            return View(hinhThucThanhToan);
        }

        // POST: Admin/HinhThucThanhToans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HinhThucThanhToanID,Ten")] HinhThucThanhToan hinhThucThanhToan)
        {
            if (id != hinhThucThanhToan.HinhThucThanhToanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hinhThucThanhToan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HinhThucThanhToanExists(hinhThucThanhToan.HinhThucThanhToanID))
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
            return View(hinhThucThanhToan);
        }

        // GET: Admin/HinhThucThanhToans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HinhThucThanhToan == null)
            {
                return NotFound();
            }

            var hinhThucThanhToan = await _context.HinhThucThanhToan
                .FirstOrDefaultAsync(m => m.HinhThucThanhToanID == id);
            if (hinhThucThanhToan == null)
            {
                return NotFound();
            }

            return View(hinhThucThanhToan);
        }

        // POST: Admin/HinhThucThanhToans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HinhThucThanhToan == null)
            {
                return Problem("Entity set 'webbanlaptopContext.HinhThucThanhToan'  is null.");
            }
            var hinhThucThanhToan = await _context.HinhThucThanhToan.FindAsync(id);
            if (hinhThucThanhToan != null)
            {
                _context.HinhThucThanhToan.Remove(hinhThucThanhToan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HinhThucThanhToanExists(int id)
        {
          return _context.HinhThucThanhToan.Any(e => e.HinhThucThanhToanID == id);
        }
    }
}
