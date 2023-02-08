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
    public class ChiTietDatHangsController : Controller
    {
        private readonly webbanlaptopContext _context;

        public ChiTietDatHangsController(webbanlaptopContext context)
        {
            _context = context;
        }

        // GET: Admin/ChiTietDatHangs
        public async Task<IActionResult> Index()
        {
            var webbanlaptopContext = _context.ChiTietDatHang.Include(c => c.DonDatHangs).Include(c => c.SanPhams);
            return View(await webbanlaptopContext.ToListAsync());
        }

        // GET: Admin/ChiTietDatHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ChiTietDatHang == null)
            {
                return NotFound();
            }

            var chiTietDatHang = await _context.ChiTietDatHang
                .Include(c => c.DonDatHangs)
                .Include(c => c.SanPhams)
                .FirstOrDefaultAsync(m => m.ChiTietDatHangID == id);
            if (chiTietDatHang == null)
            {
                return NotFound();
            }

            return View(chiTietDatHang);
        }

        // GET: Admin/ChiTietDatHangs/Create
        public IActionResult Create()
        {
            ViewData["DonDatHangID"] = new SelectList(_context.DonDatHang, "DonDatHangID", "DonDatHangID");
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID");
            return View();
        }

        // POST: Admin/ChiTietDatHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChiTietDatHangID,DonDatHangID,SanPhamID,DonGia,SoLuong,ThanhTien")] ChiTietDatHang chiTietDatHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietDatHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DonDatHangID"] = new SelectList(_context.DonDatHang, "DonDatHangID", "DonDatHangID", chiTietDatHang.DonDatHangID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID", chiTietDatHang.SanPhamID);
            return View(chiTietDatHang);
        }

        // GET: Admin/ChiTietDatHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChiTietDatHang == null)
            {
                return NotFound();
            }

            var chiTietDatHang = await _context.ChiTietDatHang.FindAsync(id);
            if (chiTietDatHang == null)
            {
                return NotFound();
            }
            ViewData["DonDatHangID"] = new SelectList(_context.DonDatHang, "DonDatHangID", "DonDatHangID", chiTietDatHang.DonDatHangID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID", chiTietDatHang.SanPhamID);
            return View(chiTietDatHang);
        }

        // POST: Admin/ChiTietDatHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChiTietDatHangID,DonDatHangID,SanPhamID,DonGia,SoLuong,ThanhTien")] ChiTietDatHang chiTietDatHang)
        {
            if (id != chiTietDatHang.ChiTietDatHangID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietDatHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietDatHangExists(chiTietDatHang.ChiTietDatHangID))
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
            ViewData["DonDatHangID"] = new SelectList(_context.DonDatHang, "DonDatHangID", "DonDatHangID", chiTietDatHang.DonDatHangID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID", chiTietDatHang.SanPhamID);
            return View(chiTietDatHang);
        }

        // GET: Admin/ChiTietDatHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChiTietDatHang == null)
            {
                return NotFound();
            }

            var chiTietDatHang = await _context.ChiTietDatHang
                .Include(c => c.DonDatHangs)
                .Include(c => c.SanPhams)
                .FirstOrDefaultAsync(m => m.ChiTietDatHangID == id);
            if (chiTietDatHang == null)
            {
                return NotFound();
            }

            return View(chiTietDatHang);
        }

        // POST: Admin/ChiTietDatHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ChiTietDatHang == null)
            {
                return Problem("Entity set 'webbanlaptopContext.ChiTietDatHang'  is null.");
            }
            var chiTietDatHang = await _context.ChiTietDatHang.FindAsync(id);
            if (chiTietDatHang != null)
            {
                _context.ChiTietDatHang.Remove(chiTietDatHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietDatHangExists(int id)
        {
          return _context.ChiTietDatHang.Any(e => e.ChiTietDatHangID == id);
        }
    }
}
