using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using webbanlaptop.Data;
using webbanlaptop.Libs;
using webbanlaptop.Models;

namespace webbanlaptop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TaiKhoansController : Controller
    {
        private readonly webbanlaptopContext _context;
        private readonly IToastNotification _toastNotification;

        public TaiKhoansController(webbanlaptopContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        // GET: Admin/TaiKhoans
        public async Task<IActionResult> Index()
        {
            var webbanlaptopContext = _context.TaiKhoan.Include(t => t.Quyens);
            return View(await webbanlaptopContext.ToListAsync());
        }

        // GET: Admin/TaiKhoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TaiKhoan == null)
            {
                return NotFound();
            }

            var taiKhoan = await _context.TaiKhoan
                .Include(t => t.Quyens)
                .FirstOrDefaultAsync(m => m.TaiKhoanID == id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Create

        // POST: Admin/TaiKhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaiKhoanID,TenTaiKhoan,MatKhau,HoTen,DiaChi,SoDienThoai,Email,QuyenID")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                if (RegexPassword.Validation(taiKhoan.MatKhau))
                {
                    taiKhoan.MatKhau = SHA1.ComputeHash(taiKhoan.MatKhau);
                    _context.Add(taiKhoan);
                    await _context.SaveChangesAsync();
                    _toastNotification.AddSuccessToastMessage("Thêm thành công!");
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["QuyenID"] = new SelectList(_context.Quyen, "QuyenID", "QuyenID", taiKhoan.QuyenID);
            _toastNotification.AddErrorToastMessage("Thêm thất bại!");
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/TaiKhoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TaiKhoan == null)
            {
                return NotFound();
            }

            var taiKhoan = await _context.TaiKhoan.FindAsync(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }
            ViewData["QuyenID"] = new SelectList(_context.Quyen, "QuyenID", "QuyenID", taiKhoan.QuyenID);
            return View(taiKhoan);
        }

        // POST: Admin/TaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaiKhoanID,TenTaiKhoan,MatKhau,HoTen,DiaChi,SoDienThoai,Email,QuyenID")] TaiKhoan taiKhoan)
        {
            if (id != taiKhoan.TaiKhoanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taiKhoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaiKhoanExists(taiKhoan.TaiKhoanID))
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
            ViewData["QuyenID"] = new SelectList(_context.Quyen, "QuyenID", "QuyenID", taiKhoan.QuyenID);
            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TaiKhoan == null)
            {
                return NotFound();
            }

            var taiKhoan = await _context.TaiKhoan
                .Include(t => t.Quyens)
                .FirstOrDefaultAsync(m => m.TaiKhoanID == id);
            if (taiKhoan == null)
            {
                return NotFound();
            }
            else
            {
                _toastNotification.AddSuccessToastMessage("Xóa thành công!");
                _context.TaiKhoan.Remove(taiKhoan);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaiKhoanExists(int id)
        {
          return _context.TaiKhoan.Any(e => e.TaiKhoanID == id);
        }
    }
}
