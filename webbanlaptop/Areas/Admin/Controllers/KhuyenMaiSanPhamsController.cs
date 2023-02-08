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
    public class KhuyenMaiSanPhamsController : Controller
    {
        private readonly webbanlaptopContext _context;

        public KhuyenMaiSanPhamsController(webbanlaptopContext context)
        {
            _context = context;
        }

        // GET: Admin/KhuyenMaiSanPhams
        public async Task<IActionResult> Index()
        {
            var webbanlaptopContext = _context.KhuyenMaiSanPham.Include(k => k.KhuyenMais).Include(k => k.SanPhams);
            return View(await webbanlaptopContext.ToListAsync());
        }

        // GET: Admin/KhuyenMaiSanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KhuyenMaiSanPham == null)
            {
                return NotFound();
            }

            var khuyenMaiSanPham = await _context.KhuyenMaiSanPham
                .Include(k => k.KhuyenMais)
                .Include(k => k.SanPhams)
                .FirstOrDefaultAsync(m => m.KhuyenMaiSanPhamID == id);
            if (khuyenMaiSanPham == null)
            {
                return NotFound();
            }

            return View(khuyenMaiSanPham);
        }

        // GET: Admin/KhuyenMaiSanPhams/Create
        public IActionResult Create()
        {
            ViewData["KhuyenMaiID"] = new SelectList(_context.KhuyenMai, "KhuyenMaiID", "KhuyenMaiID");
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID");
            return View();
        }

        // POST: Admin/KhuyenMaiSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KhuyenMaiSanPhamID,KhuyenMaiID,SanPhamID")] KhuyenMaiSanPham khuyenMaiSanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khuyenMaiSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhuyenMaiID"] = new SelectList(_context.KhuyenMai, "KhuyenMaiID", "KhuyenMaiID", khuyenMaiSanPham.KhuyenMaiID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID", khuyenMaiSanPham.SanPhamID);
            return View(khuyenMaiSanPham);
        }

        // GET: Admin/KhuyenMaiSanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KhuyenMaiSanPham == null)
            {
                return NotFound();
            }

            var khuyenMaiSanPham = await _context.KhuyenMaiSanPham.FindAsync(id);
            if (khuyenMaiSanPham == null)
            {
                return NotFound();
            }
            ViewData["KhuyenMaiID"] = new SelectList(_context.KhuyenMai, "KhuyenMaiID", "KhuyenMaiID", khuyenMaiSanPham.KhuyenMaiID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID", khuyenMaiSanPham.SanPhamID);
            return View(khuyenMaiSanPham);
        }

        // POST: Admin/KhuyenMaiSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KhuyenMaiSanPhamID,KhuyenMaiID,SanPhamID")] KhuyenMaiSanPham khuyenMaiSanPham)
        {
            if (id != khuyenMaiSanPham.KhuyenMaiSanPhamID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khuyenMaiSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhuyenMaiSanPhamExists(khuyenMaiSanPham.KhuyenMaiSanPhamID))
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
            ViewData["KhuyenMaiID"] = new SelectList(_context.KhuyenMai, "KhuyenMaiID", "KhuyenMaiID", khuyenMaiSanPham.KhuyenMaiID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID", khuyenMaiSanPham.SanPhamID);
            return View(khuyenMaiSanPham);
        }

        // GET: Admin/KhuyenMaiSanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KhuyenMaiSanPham == null)
            {
                return NotFound();
            }

            var khuyenMaiSanPham = await _context.KhuyenMaiSanPham
                .Include(k => k.KhuyenMais)
                .Include(k => k.SanPhams)
                .FirstOrDefaultAsync(m => m.KhuyenMaiSanPhamID == id);
            if (khuyenMaiSanPham == null)
            {
                return NotFound();
            }

            return View(khuyenMaiSanPham);
        }

        // POST: Admin/KhuyenMaiSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KhuyenMaiSanPham == null)
            {
                return Problem("Entity set 'webbanlaptopContext.KhuyenMaiSanPham'  is null.");
            }
            var khuyenMaiSanPham = await _context.KhuyenMaiSanPham.FindAsync(id);
            if (khuyenMaiSanPham != null)
            {
                _context.KhuyenMaiSanPham.Remove(khuyenMaiSanPham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhuyenMaiSanPhamExists(int id)
        {
          return _context.KhuyenMaiSanPham.Any(e => e.KhuyenMaiSanPhamID == id);
        }
    }
}
