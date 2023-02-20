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
    public class ThongTinSanPhamsController : Controller
    {
        private readonly webbanlaptopContext _context;

        public ThongTinSanPhamsController(webbanlaptopContext context)
        {
            _context = context;
        }

        // GET: Admin/ThongTinSanPhams
        public async Task<IActionResult> Index()
        {
            var webbanlaptopContext = _context.ThongTinSanPham.Include(t => t.SanPhams).Include(t => t.ThongTins);
            return View(await webbanlaptopContext.ToListAsync());
        }

        // GET: Admin/ThongTinSanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ThongTinSanPham == null)
            {
                return NotFound();
            }

            var thongTinSanPham = await _context.ThongTinSanPham
                .Include(t => t.SanPhams)
                .Include(t => t.ThongTins)
                .FirstOrDefaultAsync(m => m.ThongTinSanPhamID == id);
            if (thongTinSanPham == null)
            {
                return NotFound();
            }

            return View(thongTinSanPham);
        }

        // GET: Admin/ThongTinSanPhams/Create
        public IActionResult Create()
        {
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID");
            ViewData["ThongTinID"] = new SelectList(_context.ThongTin, "ThongTinID", "ThongTinID");
            return View();
        }

        // POST: Admin/ThongTinSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThongTinSanPhamID,SanPhamID,ThongTinID")] ThongTinSanPham thongTinSanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thongTinSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID", thongTinSanPham.SanPhamID);
            ViewData["ThongTinID"] = new SelectList(_context.ThongTin, "ThongTinID", "ThongTinID", thongTinSanPham.ThongTinID);
            return View(thongTinSanPham);
        }

        // GET: Admin/ThongTinSanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ThongTinSanPham == null)
            {
                return NotFound();
            }

            var thongTinSanPham = await _context.ThongTinSanPham.FindAsync(id);
            if (thongTinSanPham == null)
            {
                return NotFound();
            }
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID", thongTinSanPham.SanPhamID);
            ViewData["ThongTinID"] = new SelectList(_context.ThongTin, "ThongTinID", "ThongTinID", thongTinSanPham.ThongTinID);
            return View(thongTinSanPham);
        }

        // POST: Admin/ThongTinSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ThongTinSanPhamID,SanPhamID,ThongTinID")] ThongTinSanPham thongTinSanPham)
        {
            if (id != thongTinSanPham.ThongTinSanPhamID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thongTinSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThongTinSanPhamExists(thongTinSanPham.ThongTinSanPhamID))
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
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID", thongTinSanPham.SanPhamID);
            ViewData["ThongTinID"] = new SelectList(_context.ThongTin, "ThongTinID", "ThongTinID", thongTinSanPham.ThongTinID);
            return View(thongTinSanPham);
        }

        // GET: Admin/ThongTinSanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ThongTinSanPham == null)
            {
                return NotFound();
            }

            var thongTinSanPham = await _context.ThongTinSanPham
                .Include(t => t.SanPhams)
                .Include(t => t.ThongTins)
                .FirstOrDefaultAsync(m => m.ThongTinSanPhamID == id);
            if (thongTinSanPham == null)
            {
                return NotFound();
            }

            return View(thongTinSanPham);
        }

        // POST: Admin/ThongTinSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ThongTinSanPham == null)
            {
                return Problem("Entity set 'webbanlaptopContext.ThongTinSanPham'  is null.");
            }
            var thongTinSanPham = await _context.ThongTinSanPham.FindAsync(id);
            if (thongTinSanPham != null)
            {
                _context.ThongTinSanPham.Remove(thongTinSanPham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThongTinSanPhamExists(int id)
        {
          return _context.ThongTinSanPham.Any(e => e.ThongTinSanPhamID == id);
        }
    }
}
