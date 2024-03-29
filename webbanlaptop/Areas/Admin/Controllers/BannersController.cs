﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webbanlaptop.Data;
using webbanlaptop.Models;
using webbanlaptop.Areas.Admin;
using NToastNotify;


namespace webbanlaptop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannersController : Controller
    {
        private readonly webbanlaptopContext _context;
        private readonly IToastNotification _toastNotification;

        public BannersController(webbanlaptopContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        // GET: Admin/Banners
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("_TaiKhoanID") != null)
            {
                return View(await _context.Banner.ToListAsync());
            }
            return RedirectToAction("Login", "Home");
        }

        // POST: Admin/Banners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, [Bind("BannerID,HinhAnh, BiaDau")] Banner banner)
        {
            if (ModelState.IsValid)
            {
                banner.HinhAnh = Upload(file);
                _context.Add(banner);
                _toastNotification.AddSuccessToastMessage("Thêm thành công!");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                //return RedirectToAction("Error404", "Errors");
            }
            _toastNotification.AddErrorToastMessage("Thêm thất bại!");
            //return RedirectToAction("Error404", "Errors");
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Banners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Banner == null)
            {
                return NotFound();
            }

            var banner = await _context.Banner.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }
            return View(banner);
        }

        // POST: Admin/Banners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormFile file, [Bind("BannerID,HinhAnh")] Banner banner)
        {
            if (id != banner.BannerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null)
                    {
                        banner.HinhAnh = Upload(file);
                    }
                    _toastNotification.AddSuccessToastMessage("Sửa thành công!");
                    _context.Update(banner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BannerExists(banner.BannerID))
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
            _toastNotification.AddErrorToastMessage("Sửa thất bại!");
            return View(banner);
        }

        // GET: Admin/Banners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Banner == null)
            {
                return NotFound();
            }
            var banner = await _context.Banner
                .FirstOrDefaultAsync(m => m.BannerID == id);
            if (banner == null)
            {
                return NotFound();
            } else
            {
                _toastNotification.AddSuccessToastMessage("Xóa thành công!");
                _context.Banner.Remove(banner);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BannerExists(int id)
        {
          return _context.Banner.Any(e => e.BannerID == id);
        }

        public string Upload(IFormFile file)
        {
            string fn = null;

            if (file != null)
            {
                // Phát sinh tên mới cho file để tránh trùng tên
                fn = Guid.NewGuid().ToString() + "_" + file.FileName;
                var path = $"wwwroot\\images\\banners\\{fn}"; // đường dẫn lưu file
                // upload file lên đường dẫn chỉ định
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return fn;
        }
    }
}
