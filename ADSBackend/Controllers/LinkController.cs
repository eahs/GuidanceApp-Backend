﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ADSBackend.Data;
using ADSBackend.Models.LinksModels;
using ADSBackend.Models.Identity;


namespace ADSBackend.Controllers
{
    public class LinkController : Controller
    {
        private readonly ApplicationDbContext _context;
   

        public LinkController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Link
        public async Task<IActionResult> Index()
        {
           
            return View(await _context.LinkItem.ToListAsync());
        }

        // GET: Link/Details/5
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

        // GET: Link/Create
        public async Task<IActionResult> Create()
        {
           
            return View();
        }

        // POST: Link/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Link,Type")] LinkItem linkItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(linkItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
         
            return View(linkItem);
        }

        // GET: Link/Edit/5
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

        // POST: Link/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Title,Description,Link,Type")] LinkItem linkItem)
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

        // GET: Link/Delete/5
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

        // POST: Link/Delete/5
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
