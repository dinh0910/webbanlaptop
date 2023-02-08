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
    public class MausController : Controller
    {
        private readonly webbanlaptopContext _context;

        public MausController(webbanlaptopContext context)
        {
            _context = context;
        }

        // GET: Admin/Maus
        public async Task<IActionResult> Index()
        {
            var webbanlaptopContext = _context.Mau.Include(m => m.SanPhams);
            return View(await webbanlaptopContext.ToListAsync());
        }

        // GET: Admin/Maus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mau == null)
            {
                return NotFound();
            }

            var mau = await _context.Mau
                .Include(m => m.SanPhams)
                .FirstOrDefaultAsync(m => m.MauID == id);
            if (mau == null)
            {
                return NotFound();
            }

            return View(mau);
        }

        // GET: Admin/Maus/Create
        public IActionResult Create()
        {
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID");
            return View();
        }

        // POST: Admin/Maus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MauID,SanPhamID,Ten")] Mau mau)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mau);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID", mau.SanPhamID);
            return View(mau);
        }

        // GET: Admin/Maus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mau == null)
            {
                return NotFound();
            }

            var mau = await _context.Mau.FindAsync(id);
            if (mau == null)
            {
                return NotFound();
            }
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID", mau.SanPhamID);
            return View(mau);
        }

        // POST: Admin/Maus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MauID,SanPhamID,Ten")] Mau mau)
        {
            if (id != mau.MauID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mau);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MauExists(mau.MauID))
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
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID", mau.SanPhamID);
            return View(mau);
        }

        // GET: Admin/Maus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mau == null)
            {
                return NotFound();
            }

            var mau = await _context.Mau
                .Include(m => m.SanPhams)
                .FirstOrDefaultAsync(m => m.MauID == id);
            if (mau == null)
            {
                return NotFound();
            }

            return View(mau);
        }

        // POST: Admin/Maus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mau == null)
            {
                return Problem("Entity set 'webbanlaptopContext.Mau'  is null.");
            }
            var mau = await _context.Mau.FindAsync(id);
            if (mau != null)
            {
                _context.Mau.Remove(mau);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MauExists(int id)
        {
          return _context.Mau.Any(e => e.MauID == id);
        }
    }
}
