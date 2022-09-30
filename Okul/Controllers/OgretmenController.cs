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
    public class OgretmenController : Controller
    {
        private OkulContext _context = new OkulContext();

        // GET: Ogretmen
        public async Task<IActionResult> Index()
        {
            var okulContext = _context.Ogretmenler.Where(x => x.IsDeleted == false).Include(o => o.Ders);
            return View(await okulContext.ToListAsync());
        }

        // GET: Ogretmen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ogretmenler == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmenler
                .Include(o => o.Ders)
                .FirstOrDefaultAsync(m => m.OgretmenID == id);
            if (ogretmen == null)
            {
                return NotFound();
            }

            return View(ogretmen);
        }

        // GET: Ogretmen/Create
        public IActionResult Create()
        {
            ViewData["DersID"] = new SelectList(_context.Dersler.Where(x => x.IsDeleted == false), "DersID", "DersName");
            return View();
        }

        // POST: Ogretmen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OgretmenID,OgretmenName,OgretmenTcNo,OgretmenDogumTarih,DersID,IsDeleted")] Ogretmen ogretmen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogretmen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DersID"] = new SelectList(_context.Dersler, "DersID", "DersName", ogretmen.DersID);
            return View(ogretmen);
        }

        // GET: Ogretmen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ogretmenler == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmenler.FindAsync(id);
            if (ogretmen == null)
            {
                return NotFound();
            }
            ViewData["DersID"] = new SelectList(_context.Dersler, "DersID", "DersName", ogretmen.DersID);
            return View(ogretmen);
        }

        // POST: Ogretmen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OgretmenID,OgretmenName,OgretmenTcNo,OgretmenDogumTarih,DersID,IsDeleted")] Ogretmen ogretmen)
        {
            if (id != ogretmen.OgretmenID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogretmen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OgretmenExists(ogretmen.OgretmenID))
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
            ViewData["DersID"] = new SelectList(_context.Dersler, "DersID", "DersName", ogretmen.DersID);
            return View(ogretmen);
        }

        // GET: Ogretmen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ogretmenler == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmenler
                .Include(o => o.Ders)
                .FirstOrDefaultAsync(m => m.OgretmenID == id);
            if (ogretmen == null)
            {
                return NotFound();
            }

            return View(ogretmen);
        }

        // POST: Ogretmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ogretmenler == null)
            {
                return Problem("Entity set 'OkulContext.Ogretmenler'  is null.");
            }
            var ogretmen = await _context.Ogretmenler.FindAsync(id);
            if (ogretmen != null)
            {
                //_context.Ogretmenler.Remove(ogretmen);
                var changeOgretmen = ogretmen;
                changeOgretmen.IsDeleted = true;
                changeOgretmen.DeletedTime = DateTime.Now;

                _context.Ogretmenler.Update(changeOgretmen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OgretmenExists(int id)
        {
          return _context.Ogretmenler.Any(e => e.OgretmenID == id);
        }
    }
}
