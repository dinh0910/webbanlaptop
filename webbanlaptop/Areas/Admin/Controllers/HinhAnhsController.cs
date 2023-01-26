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
    public class HinhAnhsController : Controller
    {
        private readonly webbanlaptopContext _context;

        public HinhAnhsController(webbanlaptopContext context)
        {
            _context = context;
        }

        // GET: Admin/HinhAnhs
        public async Task<IActionResult> Index()
        {
            var webbanlaptopContext = _context.HinhAnh.Include(h => h.SanPhams);
            return View(await webbanlaptopContext.ToListAsync());
        }

        // GET: Admin/HinhAnhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HinhAnh == null)
            {
                return NotFound();
            }

            var hinhAnh = await _context.HinhAnh
                .Include(h => h.SanPhams)
                .FirstOrDefaultAsync(m => m.HinhAnhID == id);
            if (hinhAnh == null)
            {
                return NotFound();
            }

            return View(hinhAnh);
        }

        // GET: Admin/HinhAnhs/Create
        public IActionResult Create()
        {
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID");
            return View();
        }

        // POST: Admin/HinhAnhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, [Bind("HinhAnhID,Anh,SanPhamID")] HinhAnh hinhAnh)
        {
            if (ModelState.IsValid)
            {
                hinhAnh.Anh = Upload(file);
                _context.Add(hinhAnh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID", hinhAnh.SanPhamID);
            return View(hinhAnh);
        }

        // GET: Admin/HinhAnhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HinhAnh == null)
            {
                return NotFound();
            }

            var hinhAnh = await _context.HinhAnh.FindAsync(id);
            if (hinhAnh == null)
            {
                return NotFound();
            }
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID", hinhAnh.SanPhamID);
            return View(hinhAnh);
        }

        // POST: Admin/HinhAnhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormFile file, int id, [Bind("HinhAnhID,Anh,SanPhamID")] HinhAnh hinhAnh)
        {
            if (id != hinhAnh.HinhAnhID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(file != null)
                    {
                        hinhAnh.Anh = Upload(file);
                    }
                    _context.Update(hinhAnh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HinhAnhExists(hinhAnh.HinhAnhID))
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
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "SanPhamID", "SanPhamID", hinhAnh.SanPhamID);
            return View(hinhAnh);
        }

        // GET: Admin/HinhAnhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HinhAnh == null)
            {
                return NotFound();
            }

            var hinhAnh = await _context.HinhAnh
                .Include(h => h.SanPhams)
                .FirstOrDefaultAsync(m => m.HinhAnhID == id);
            if (hinhAnh == null)
            {
                return NotFound();
            }

            return View(hinhAnh);
        }

        // POST: Admin/HinhAnhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HinhAnh == null)
            {
                return Problem("Entity set 'webbanlaptopContext.HinhAnh'  is null.");
            }
            var hinhAnh = await _context.HinhAnh.FindAsync(id);
            if (hinhAnh != null)
            {
                _context.HinhAnh.Remove(hinhAnh);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HinhAnhExists(int id)
        {
          return _context.HinhAnh.Any(e => e.HinhAnhID == id);
        }

        public string Upload(IFormFile file)
        {
            string fn = null;

            if (file != null)
            {
                // Phát sinh tên mới cho file để tránh trùng tên
                fn = Guid.NewGuid().ToString() + "_" + file.FileName;
                var path = $"wwwroot\\images\\{fn}"; // đường dẫn lưu file
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
