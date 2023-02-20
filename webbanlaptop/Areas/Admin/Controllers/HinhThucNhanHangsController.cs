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
    public class HinhThucNhanHangsController : Controller
    {
        private readonly webbanlaptopContext _context;

        public HinhThucNhanHangsController(webbanlaptopContext context)
        {
            _context = context;
        }

        // GET: Admin/HinhThucNhanHangs
        public async Task<IActionResult> Index()
        {
              return View(await _context.HinhThucNhanHang.ToListAsync());
        }

        // GET: Admin/HinhThucNhanHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HinhThucNhanHang == null)
            {
                return NotFound();
            }

            var hinhThucNhanHang = await _context.HinhThucNhanHang
                .FirstOrDefaultAsync(m => m.HinhThucNhanHangID == id);
            if (hinhThucNhanHang == null)
            {
                return NotFound();
            }

            return View(hinhThucNhanHang);
        }

        // GET: Admin/HinhThucNhanHangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/HinhThucNhanHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HinhThucNhanHangID,NoiDung")] HinhThucNhanHang hinhThucNhanHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hinhThucNhanHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hinhThucNhanHang);
        }

        // GET: Admin/HinhThucNhanHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HinhThucNhanHang == null)
            {
                return NotFound();
            }

            var hinhThucNhanHang = await _context.HinhThucNhanHang.FindAsync(id);
            if (hinhThucNhanHang == null)
            {
                return NotFound();
            }
            return View(hinhThucNhanHang);
        }

        // POST: Admin/HinhThucNhanHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HinhThucNhanHangID,NoiDung")] HinhThucNhanHang hinhThucNhanHang)
        {
            if (id != hinhThucNhanHang.HinhThucNhanHangID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hinhThucNhanHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HinhThucNhanHangExists(hinhThucNhanHang.HinhThucNhanHangID))
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
            return View(hinhThucNhanHang);
        }

        // GET: Admin/HinhThucNhanHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HinhThucNhanHang == null)
            {
                return NotFound();
            }

            var hinhThucNhanHang = await _context.HinhThucNhanHang
                .FirstOrDefaultAsync(m => m.HinhThucNhanHangID == id);
            if (hinhThucNhanHang == null)
            {
                return NotFound();
            }

            return View(hinhThucNhanHang);
        }

        // POST: Admin/HinhThucNhanHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HinhThucNhanHang == null)
            {
                return Problem("Entity set 'webbanlaptopContext.HinhThucNhanHang'  is null.");
            }
            var hinhThucNhanHang = await _context.HinhThucNhanHang.FindAsync(id);
            if (hinhThucNhanHang != null)
            {
                _context.HinhThucNhanHang.Remove(hinhThucNhanHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HinhThucNhanHangExists(int id)
        {
          return _context.HinhThucNhanHang.Any(e => e.HinhThucNhanHangID == id);
        }
    }
}
