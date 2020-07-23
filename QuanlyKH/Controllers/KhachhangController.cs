using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using QuanlyKH.Data;
using QuanlyKH.Models;
using System.Linq.Dynamic.Core;

namespace QuanlyKH.Controllers
{
    public class KhachhangController : Controller
    {
        private readonly QLkhContext _context;

        public KhachhangController(QLkhContext context)
        {
            _context = context;
        }

        // GET: Khachhangs
        public  IActionResult Index(int page = 1,string orderBy = "MsKH", bool desc = false)
        {
            var model = Paging(page,orderBy,desc);
            ViewData["pages"] = model.pages;
            ViewData["page"] = model.page;

            ViewData["MsKH"] = false;
            ViewData["TenKH"] = false;
            ViewData["Nodau"] = false;

            ViewData[orderBy] = !desc;

            return View( model.khachhangs);
        }

        // GET: Khachhangs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.KhachHang
                .FirstOrDefaultAsync(m => m.MsKH == id);
            if (khachhang == null)
            {
                return NotFound();
            }
            List<Phieuthu> phieuthus = await _context.PhieuThu.Where(m => m.Khachhang == khachhang).ToListAsync();
            if (phieuthus != null)
            {
                int sl = phieuthus.Count();
                ViewData["SLPT"] = sl;

            }
            
            return View(khachhang);
        }
        // GET: KHACHHANG PT
        public async Task<IActionResult> DetailKHPT(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.KhachHang
                .FirstOrDefaultAsync(m => m.MsKH == id);
            if (khachhang == null)
            {
                return NotFound();
            }
            KhachhangPhieuthu KHPT = new KhachhangPhieuthu();
            KHPT.khachhang = khachhang;
           

            return View(KHPT);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateKHPT([Bind("MsKH,MsPT,NgayThu,SoTien")] KhachhangPhieuthu KHPT)
        {
            if (ModelState.IsValid)
            {
                Phieuthu phieuthu = new Phieuthu();
                phieuthu.MsPT = KHPT.MsPT;
                phieuthu.NgayThu = KHPT.NgayThu;
                phieuthu.SoTien = KHPT.SoTien;
                var khachhang = await _context.KhachHang
               .FirstOrDefaultAsync(m => m.MsKH == KHPT.MsKH);
                if (khachhang == null)
                {
                    return NotFound();
                }
                phieuthu.Khachhang = khachhang;
                _context.Add(phieuthu);
                await _context.SaveChangesAsync();

            }
            return RedirectToAction("Details", new RouteValueDictionary(new { controller = "KhachHang", action = "Details", id = KHPT.MsKH }));
        }


        // GET: Khachhangs/Create   
        public IActionResult Create()
        {
            return View();
        }

        // POST: Khachhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MsKH,TenKH,Nodau")] Khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khachhang);
        }

        // GET: Khachhangs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.KhachHang.FindAsync(id);
            if (khachhang == null)
            {
                return NotFound();
            }
            return View(khachhang);
        }

        // POST: Khachhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MsKH,TenKH,Nodau")] Khachhang khachhang)
        {
            if (id != khachhang.MsKH)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachhangExists(khachhang.MsKH))
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
            return View(khachhang);
        }

        // GET: Khachhangs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.KhachHang
                .FirstOrDefaultAsync(m => m.MsKH == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // POST: Khachhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var khachhang = await _context.KhachHang.FindAsync(id);
            _context.KhachHang.Remove(khachhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachhangExists(string id)
        {
            return _context.KhachHang.Any(e => e.MsKH == id);
        }
        //Action Search data KH
        public async Task<IActionResult> Search(string search)
        {
            var s = search.ToLower();
            var kh = _context.KhachHang.Where(
                kh => kh.MsKH.ToLower().Contains( s) ||
                kh.Nodau.ToString() == s ||
                kh.TenKH.ToLower().Contains( s)
                
                );
            return View("Index", await kh.ToListAsync());
        }
        //Action pagination
        public (Khachhang[] khachhangs, int pages, int page) Paging(
            int page, 
            string orderBy = "MsKH", //default sort
            bool dsc = false // flag sort : default sort acsending
            )
        {
           // _context.KhachHang.Where(p =>p.MsKH)
            //So luong item 1 trang
            int size = 2;
            //So luong trang
            int pages = (int) Math.Ceiling((double)_context.KhachHang.Count() / size);
            var khachhangs = _context.KhachHang.Skip((page - 1) * size)
                .Take(size).AsQueryable()
                .OrderBy($"{orderBy} { (dsc ? "descending" : "")}")
                .ToArray();
            return (khachhangs, pages, page);
        }
    }
}
