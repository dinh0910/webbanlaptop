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
    public class TenThongSosController : Controller
    {
        private readonly webbanlaptopContext _context;

        public TenThongSosController(webbanlaptopContext context)
        {
            _context = context;
        }

        // GET: Admin/TenThongSos
        public async Task<IActionResult> Index()
        {
            var webbanlaptopContext = _context.TenThongSo.Include(t => t.LoaiThongSos);
            return View(await webbanlaptopContext.ToListAsync());
        }

        // GET: Admin/TenThongSos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TenThongSo == null)
            {
                return NotFound();
            }

            var tenThongSo = await _context.TenThongSo
                .Include(t => t.LoaiThongSos)
                .FirstOrDefaultAsync(m => m.TenThongSoID == id);
            if (tenThongSo == null)
            {
                return NotFound();
            }

            return View(tenThongSo);
        }

        // GET: Admin/TenThongSos/Create
        public IActionResult Create()
        {
            ViewData["LoaiThongSoID"] = new SelectList(_context.LoaiThongSo, "LoaiThongSoID", "LoaiThongSoID");
            return View();
        }

        // POST: Admin/TenThongSos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenThongSoID,LoaiThongSoID,Ten")] TenThongSo tenThongSo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tenThongSo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoaiThongSoID"] = new SelectList(_context.LoaiThongSo, "LoaiThongSoID", "LoaiThongSoID", tenThongSo.LoaiThongSoID);
            return View(tenThongSo);
        }

        // GET: Admin/TenThongSos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TenThongSo == null)
            {
                return NotFound();
            }

            var tenThongSo = await _context.TenThongSo.FindAsync(id);
            if (tenThongSo == null)
            {
                return NotFound();
            }
            ViewData["LoaiThongSoID"] = new SelectList(_context.LoaiThongSo, "LoaiThongSoID", "LoaiThongSoID", tenThongSo.LoaiThongSoID);
            return View(tenThongSo);
        }

        // POST: Admin/TenThongSos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TenThongSoID,LoaiThongSoID,Ten")] TenThongSo tenThongSo)
        {
            if (id != tenThongSo.TenThongSoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tenThongSo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenThongSoExists(tenThongSo.TenThongSoID))
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
            ViewData["LoaiThongSoID"] = new SelectList(_context.LoaiThongSo, "LoaiThongSoID", "LoaiThongSoID", tenThongSo.LoaiThongSoID);
            return View(tenThongSo);
        }

        // GET: Admin/TenThongSos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TenThongSo == null)
            {
                return NotFound();
            }

            var tenThongSo = await _context.TenThongSo
                .Include(t => t.LoaiThongSos)
                .FirstOrDefaultAsync(m => m.TenThongSoID == id);
            if (tenThongSo == null)
            {
                return NotFound();
            }

            return View(tenThongSo);
        }

        // POST: Admin/TenThongSos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TenThongSo == null)
            {
                return Problem("Entity set 'webbanlaptopContext.TenThongSo'  is null.");
            }
            var tenThongSo = await _context.TenThongSo.FindAsync(id);
            if (tenThongSo != null)
            {
                _context.TenThongSo.Remove(tenThongSo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TenThongSoExists(int id)
        {
          return _context.TenThongSo.Any(e => e.TenThongSoID == id);
        }
    }
}
