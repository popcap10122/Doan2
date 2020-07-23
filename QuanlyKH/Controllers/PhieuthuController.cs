using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanlyKH.Data;
using QuanlyKH.Models;

namespace QuanlyKH.Controllers
{
    public class PhieuthuController : Controller
    {
        private readonly QLkhContext _context;

        public PhieuthuController(QLkhContext context)
        {
            _context = context;
        }

        // GET: Phieuthu
        public IActionResult Index(int page = 1,string orderBy="MsPT",bool dsc = false)
        {
            var model = Paging(page,orderBy,dsc);
            ViewData["pages"] = model.pages;
            ViewData["page"] = model.page;

            ViewData["MsPT"] = false;
            ViewData["NgayThu"] = false;
            ViewData["SoTien"] = false;
            ViewData[orderBy] = !dsc;

            return View(model.phieuthus);
        }

        // GET: Phieuthu/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuthu = await _context.PhieuThu
                .FirstOrDefaultAsync(m => m.MsPT == id);
            if (phieuthu == null)
            {
                return NotFound();
            }

            return View(phieuthu);
        }

        // GET: Phieuthu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Phieuthu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MsPT,NgayThu,SoTien")] Phieuthu phieuthu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phieuthu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phieuthu);
        }

        // GET: Phieuthu/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuthu = await _context.PhieuThu.FindAsync(id);
            if (phieuthu == null)
            {
                return NotFound();
            }
            return View(phieuthu);
        }

        // POST: Phieuthu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MsPT,NgayThu,SoTien")] Phieuthu phieuthu)
        {
            if (id != phieuthu.MsPT)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phieuthu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuthuExists(phieuthu.MsPT))
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
            return View(phieuthu);
        }

        // GET: Phieuthu/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuthu = await _context.PhieuThu
                .FirstOrDefaultAsync(m => m.MsPT == id);
            if (phieuthu == null)
            {
                return NotFound();
            }

            return View(phieuthu);
        }

        // POST: Phieuthu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var phieuthu = await _context.PhieuThu.FindAsync(id);
            _context.PhieuThu.Remove(phieuthu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhieuthuExists(string id)
        {
            return _context.PhieuThu.Any(e => e.MsPT == id);
        }
        // Search
        public IActionResult Search(string search)
        {
            if (search != null)
            {
                var s = search.ToLower();

                var phieuthu = _context.PhieuThu.Where(p =>
                    p.MsPT.ToLower().Contains(s) ||
                    p.Khachhang.MsKH.ToLower().Contains(s) ||
                    p.NgayThu.ToString() == s
                );
                return View("Index", phieuthu.ToArray());
            }
            return RedirectToAction("Index");
        }
        public (Phieuthu[] phieuthus, int pages, int page) Paging(
            int page,
            string orderBy = "MsPT",
            bool dsc = false
            )
        {
            int sizePage = 2;
            int pages = (int)Math.Ceiling((decimal)_context.PhieuThu.Count());
            //Take record from number page
            var phieuthus = _context.PhieuThu.Skip((page - 1) * sizePage)
                .Take(sizePage)
                .OrderBy($"{orderBy} {(dsc ?"descending":" ")}") 
                .ToArray();
            return ( phieuthus,pages, page);
        }
    }
}
