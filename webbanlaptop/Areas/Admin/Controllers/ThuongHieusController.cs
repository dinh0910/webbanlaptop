using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using webbanlaptop.Data;
using webbanlaptop.Models;

namespace webbanlaptop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThuongHieusController : Controller
    {
        private readonly webbanlaptopContext _context;
        private readonly IToastNotification _toastNotification;

        public ThuongHieusController(webbanlaptopContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        // GET: Admin/ThuongHieus
        public async Task<IActionResult> Index()
        {
              return View(await _context.ThuongHieu.ToListAsync());
        }

        // POST: Admin/ThuongHieus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThuongHieuID,Ten")] ThuongHieu thuongHieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thuongHieu);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Thêm thành công!");
                return RedirectToAction(nameof(Index));
            }
            _toastNotification.AddErrorToastMessage("Thêm thất bại!");
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/ThuongHieus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ThuongHieu == null)
            {
                return NotFound();
            }

            var thuongHieu = await _context.ThuongHieu.FindAsync(id);
            if (thuongHieu == null)
            {
                return NotFound();
            }
            return View(thuongHieu);
        }

        // POST: Admin/ThuongHieus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ThuongHieuID,Ten")] ThuongHieu thuongHieu)
        {
            if (id != thuongHieu.ThuongHieuID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thuongHieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThuongHieuExists(thuongHieu.ThuongHieuID))
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
            return View(thuongHieu);
        }

        // GET: Admin/ThuongHieus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ThuongHieu == null)
            {
                return NotFound();
            }

            var thuongHieu = await _context.ThuongHieu
                .FirstOrDefaultAsync(m => m.ThuongHieuID == id);
            if (thuongHieu == null)
            {
                return NotFound();
            } else
            {
                _toastNotification.AddSuccessToastMessage("Xóa thành công!");
                _context.ThuongHieu.Remove(thuongHieu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThuongHieuExists(int id)
        {
            return _context.ThuongHieu.Any(e => e.ThuongHieuID == id);
        }
    }
}
