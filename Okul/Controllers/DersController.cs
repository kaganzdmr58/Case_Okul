using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Okul.Models;

namespace Okul.Controllers
{
    public class DersController : Controller
    {
        private OkulContext _context = new OkulContext();

        // GET: Ders
        public async Task<IActionResult> Index()
        {
              return View(await _context.Dersler.Where(x => x.IsDeleted == false).ToListAsync());
        }

        // GET: Ders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dersler == null)
            {
                return NotFound();
            }

            var ders = await _context.Dersler
                .FirstOrDefaultAsync(m => m.DersID == id);
            if (ders == null)
            {
                return NotFound();
            }

            return View(ders);
        }

        // GET: Ders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DersID,DersName")] Ders ders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ders);
        }

        // GET: Ders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dersler == null)
            {
                return NotFound();
            }

            var ders = await _context.Dersler.FindAsync(id);
            if (ders == null)
            {
                return NotFound();
            }
            return View(ders);
        }

        // POST: Ders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DersID,DersName")] Ders ders)
        {
            if (id != ders.DersID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DersExists(ders.DersID))
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
            return View(ders);
        }

        // GET: Ders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dersler == null)
            {
                return NotFound();
            }

            var ders = await _context.Dersler
                .FirstOrDefaultAsync(m => m.DersID == id);
            if (ders == null)
            {
                return NotFound();
            }

            return View(ders);
        }

        // POST: Ders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dersler == null)
            {
                return Problem("Entity set 'OkulContext.Dersler'  is null.");
            }
            var ders = await _context.Dersler.FindAsync(id);
            if (ders != null)
            {
                // _context.Dersler.Remove(ders);

                var changeDers = ders;
                changeDers.IsDeleted = true;
                changeDers.DeletedTime = DateTime.Now;
                
                _context.Dersler.Update(changeDers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DersExists(int id)
        {
          return _context.Dersler.Any(e => e.DersID == id);
        }
    }
}
