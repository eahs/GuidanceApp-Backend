using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ADSBackend.Data;
using ADSBackend.Models.SummerWork;

namespace ADSBackend.Controllers
{
    public class SummerWorkController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SummerWorkController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SummerWork
        public async Task<IActionResult> Index()
        {
            return View(await _context.SummerWork.ToListAsync());
        }

        // GET: SummerWork/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var summerWork = await _context.SummerWork
                .FirstOrDefaultAsync(m => m.SummerID == id);
            if (summerWork == null)
            {
                return NotFound();
            }

            return View(summerWork);
        }

        // GET: SummerWork/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SummerWork/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SummerID,Class,Classroom,Link")] SummerWork summerWork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(summerWork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(summerWork);
        }

        // GET: SummerWork/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var summerWork = await _context.SummerWork.FindAsync(id);
            if (summerWork == null)
            {
                return NotFound();
            }
            return View(summerWork);
        }

        // POST: SummerWork/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SummerID,Class,Classroom,Link")] SummerWork summerWork)
        {
            if (id != summerWork.SummerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(summerWork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SummerWorkExists(summerWork.SummerID))
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
            return View(summerWork);
        }

        // GET: SummerWork/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var summerWork = await _context.SummerWork
                .FirstOrDefaultAsync(m => m.SummerID == id);
            if (summerWork == null)
            {
                return NotFound();
            }

            return View(summerWork);
        }

        // POST: SummerWork/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var summerWork = await _context.SummerWork.FindAsync(id);
            _context.SummerWork.Remove(summerWork);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SummerWorkExists(string id)
        {
            return _context.SummerWork.Any(e => e.SummerID == id);
        }
    }
}
