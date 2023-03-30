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
    public class DanhMucConsController : Controller
    {
        private readonly webbanlaptopContext _context;
        private readonly IToastNotification _toastNotification;

        public DanhMucConsController(webbanlaptopContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        // GET: Admin/DanhMucCons
        public async Task<IActionResult> Index()
        {
            var webbanlaptopContext = _context.DanhMucCon.Include(d => d.DanhMucs);
            ViewData["DanhMucID"] = new SelectList(_context.DanhMuc, "DanhMucID", "Ten");
            return View(await webbanlaptopContext.ToListAsync());
        }

        // GET: Admin/DanhMucCons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DanhMucCon == null)
            {
                return NotFound();
            }

            var danhMucCon = await _context.DanhMucCon
                .Include(d => d.DanhMucs)
                .FirstOrDefaultAsync(m => m.DanhMucConID == id);
            if (danhMucCon == null)
            {
                return NotFound();
            }

            return View(danhMucCon);
        }

        // POST: Admin/DanhMucCons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DanhMucConID,DanhMucID,Ten")] DanhMucCon danhMucCon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhMucCon);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Thêm thành công!");
                return RedirectToAction(nameof(Index));
            }
            _toastNotification.AddErrorToastMessage("Thêm thất bại!");
            ViewData["DanhMucID"] = new SelectList(_context.DanhMuc, "DanhMucID", "Ten", danhMucCon.DanhMucID);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/DanhMucCons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DanhMucCon == null)
            {
                return NotFound();
            }

            var danhMucCon = await _context.DanhMucCon.FindAsync(id);
            if (danhMucCon == null)
            {
                return NotFound();
            }
            ViewData["DanhMucID"] = new SelectList(_context.DanhMuc, "DanhMucID", "DanhMucID", danhMucCon.DanhMucID);
            return View(danhMucCon);
        }

        // POST: Admin/DanhMucCons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DanhMucConID,DanhMucID,Ten")] DanhMucCon danhMucCon)
        {
            if (id != danhMucCon.DanhMucConID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhMucCon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhMucConExists(danhMucCon.DanhMucConID))
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
            ViewData["DanhMucID"] = new SelectList(_context.DanhMuc, "DanhMucID", "DanhMucID", danhMucCon.DanhMucID);
            return View(danhMucCon);
        }

        // GET: Admin/DanhMucCons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DanhMucCon == null)
            {
                return NotFound();
            }

            var danhMucCon = await _context.DanhMucCon
                .Include(d => d.DanhMucs)
                .FirstOrDefaultAsync(m => m.DanhMucConID == id);
            if (danhMucCon == null)
            {
                return NotFound();
            } else
            {
                _toastNotification.AddSuccessToastMessage("Xóa thành công!");
                _context.DanhMucCon.Remove(danhMucCon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhMucConExists(int id)
        {
          return _context.DanhMucCon.Any(e => e.DanhMucConID == id);
        }
    }
}
