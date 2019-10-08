using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ADSBackend.Data;
using ADSBackend.Models.LinksModels;

namespace ADSBackend.Controllers
{
    public class LinksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LinksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Links
        public async Task<IActionResult> Index()
        {
            return View(await _context.LinkItem.ToListAsync());
        }

        // GET: Links/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linkItem = await _context.LinkItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linkItem == null)
            {
                return NotFound();
            }

            return View(linkItem);
        }

        // GET: Links/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Links/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Link")] LinkItem linkItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(linkItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(linkItem);
        }

        // GET: Links/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linkItem = await _context.LinkItem.FindAsync(id);
            if (linkItem == null)
            {
                return NotFound();
            }
            return View(linkItem);
        }

        // POST: Links/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Title,Description,Link")] LinkItem linkItem)
        {
            if (id != linkItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linkItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinkItemExists(linkItem.Id))
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
            return View(linkItem);
        }

        // GET: Links/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linkItem = await _context.LinkItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linkItem == null)
            {
                return NotFound();
            }

            return View(linkItem);
        }

        // POST: Links/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var linkItem = await _context.LinkItem.FindAsync(id);
            _context.LinkItem.Remove(linkItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinkItemExists(string id)
        {
            return _context.LinkItem.Any(e => e.Id == id);
        }
    }
}
