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
    public class LoaiSanPhamsController : Controller
    {
        private readonly webbanlaptopContext _context;
        private readonly IToastNotification _toastNotification;

        public LoaiSanPhamsController(webbanlaptopContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        // GET: Admin/LoaiSanPhams
        public async Task<IActionResult> Index()
        {
              return View(await _context.LoaiSanPham.ToListAsync());
        }

        // GET: Admin/LoaiSanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LoaiSanPham == null)
            {
                return NotFound();
            }

            var loaiSanPham = await _context.LoaiSanPham
                .FirstOrDefaultAsync(m => m.LoaiSanPhamID == id);
            if (loaiSanPham == null)
            {
                return NotFound();
            }

            return View(loaiSanPham);
        }

        // POST: Admin/LoaiSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoaiSanPhamID,Ten")] LoaiSanPham loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiSanPham);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Thêm thành công!");
                return RedirectToAction(nameof(Index));
            }
            _toastNotification.AddErrorToastMessage("Thêm thất bại!");
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/LoaiSanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LoaiSanPham == null)
            {
                return NotFound();
            }

            var loaiSanPham = await _context.LoaiSanPham.FindAsync(id);
            if (loaiSanPham == null)
            {
                return NotFound();
            }
            return View(loaiSanPham);
        }

        // POST: Admin/LoaiSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoaiSanPhamID,Ten")] LoaiSanPham loaiSanPham)
        {
            if (id != loaiSanPham.LoaiSanPhamID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiSanPhamExists(loaiSanPham.LoaiSanPhamID))
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
            return View(loaiSanPham);
        }

        // GET: Admin/LoaiSanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LoaiSanPham == null)
            {
                return NotFound();
            }

            var loaiSanPham = await _context.LoaiSanPham
                .FirstOrDefaultAsync(m => m.LoaiSanPhamID == id);
            if (loaiSanPham == null)
            {
                return NotFound();
            } else
            {
                _toastNotification.AddSuccessToastMessage("Xóa thành công!");
                _context.LoaiSanPham.Remove(loaiSanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiSanPhamExists(int id)
        {
          return _context.LoaiSanPham.Any(e => e.LoaiSanPhamID == id);
        }
    }
}
