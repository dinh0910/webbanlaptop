﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using webbanlaptop.Data;
using webbanlaptop.Models;

namespace webbanlaptop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamsController : Controller
    {
        private readonly webbanlaptopContext _context;
        private readonly IToastNotification _toastNotification;

        public SanPhamsController(webbanlaptopContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var webbanlaptopContext = _context.SanPham.Include(d => d.DanhMucs);
            ViewData["DanhMucID"] = new SelectList(_context.DanhMuc, "DanhMucID", "Ten");
            ViewData["ThuongHieuID"] = new SelectList(_context.ThuongHieu, "ThuongHieuID", "Ten");
            return View(await webbanlaptopContext.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, [Bind("SanPhamID,DanhMucID,ThuongHieuID,Ten,HinhAnh,DonGia,GiamGia,ThanhTien")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                sanPham.HinhAnh = Upload(file);
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Thêm thành công!");
                return RedirectToAction(nameof(Index));
            }
            _toastNotification.AddErrorToastMessage("Thêm thất bại!");
            ViewData["DanhMucID"] = new SelectList(_context.DanhMuc, "DanhMucConID", "Ten", sanPham.DanhMucID);
            ViewData["ThuongHieuID"] = new SelectList(_context.ThuongHieu, "ThuongHieuID", "Ten", sanPham.ThuongHieuID);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SanPham == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham
                .Include(d => d.DanhMucs)
                .Include(d => d.ThuongHieus)
                .FirstOrDefaultAsync(m => m.SanPhamID == id);
            if (sanPham == null)
            {
                return NotFound();
            }
            else
            {
                _toastNotification.AddSuccessToastMessage("Xóa thành công!");
                _context.SanPham.Remove(sanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public string Upload(IFormFile file)
        {
            string fn = null;

            if (file != null)
            {
                fn = Guid.NewGuid().ToString() + "_" + file.FileName;
                var path = $"wwwroot\\images\\products\\{fn}"; // đường dẫn lưu file
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return fn;
        }
    }
}