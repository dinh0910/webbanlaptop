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
    public class LoaiThongSosController : Controller
    {
        private readonly webbanlaptopContext _context;

        public LoaiThongSosController(webbanlaptopContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiThongSos
        public async Task<IActionResult> Index()
        {
              return View(await _context.LoaiThongSo.ToListAsync());
        }

        // GET: Admin/LoaiThongSos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LoaiThongSo == null)
            {
                return NotFound();
            }

            var loaiThongSo = await _context.LoaiThongSo
                .FirstOrDefaultAsync(m => m.LoaiThongSoID == id);
            if (loaiThongSo == null)
            {
                return NotFound();
            }

            return View(loaiThongSo);
        }

        // GET: Admin/LoaiThongSos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiThongSos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoaiThongSoID,Ten")] LoaiThongSo loaiThongSo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiThongSo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiThongSo);
        }

        // GET: Admin/LoaiThongSos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LoaiThongSo == null)
            {
                return NotFound();
            }

            var loaiThongSo = await _context.LoaiThongSo.FindAsync(id);
            if (loaiThongSo == null)
            {
                return NotFound();
            }
            return View(loaiThongSo);
        }

        // POST: Admin/LoaiThongSos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoaiThongSoID,Ten")] LoaiThongSo loaiThongSo)
        {
            if (id != loaiThongSo.LoaiThongSoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiThongSo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiThongSoExists(loaiThongSo.LoaiThongSoID))
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
            return View(loaiThongSo);
        }

        // GET: Admin/LoaiThongSos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LoaiThongSo == null)
            {
                return NotFound();
            }

            var loaiThongSo = await _context.LoaiThongSo
                .FirstOrDefaultAsync(m => m.LoaiThongSoID == id);
            if (loaiThongSo == null)
            {
                return NotFound();
            }

            return View(loaiThongSo);
        }

        // POST: Admin/LoaiThongSos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LoaiThongSo == null)
            {
                return Problem("Entity set 'webbanlaptopContext.LoaiThongSo'  is null.");
            }
            var loaiThongSo = await _context.LoaiThongSo.FindAsync(id);
            if (loaiThongSo != null)
            {
                _context.LoaiThongSo.Remove(loaiThongSo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiThongSoExists(int id)
        {
          return _context.LoaiThongSo.Any(e => e.LoaiThongSoID == id);
        }
    }
}
