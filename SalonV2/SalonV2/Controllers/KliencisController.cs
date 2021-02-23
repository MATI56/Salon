using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalonV2.Data;
using SalonV2.Models;

namespace SalonV2.Controllers
{
    [Authorize]
    public class KliencisController : Controller
    {
        private readonly SalonV2Context _context;

        public KliencisController(SalonV2Context context)
        {
            _context = context;
        }

        // GET: Kliencis
        public async Task<IActionResult> Index(string searchString)
        {
            var kli = from c in _context.Klienci
                      select c;
            if (!string.IsNullOrEmpty(searchString))
            {
                kli = kli.Where(c => c.Nazwisko.Contains(searchString));
            }

            return View(await kli.ToListAsync());
        }

        // GET: Kliencis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klienci = await _context.Klienci
                .FirstOrDefaultAsync(m => m.KlienciId == id);
            if (klienci == null)
            {
                return NotFound();
            }

            return View(klienci);
        }

        // GET: Kliencis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kliencis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KlienciId,Imie,Nazwisko,NumerTel")] Klienci klienci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klienci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klienci);
        }

        // GET: Kliencis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klienci = await _context.Klienci.FindAsync(id);
            if (klienci == null)
            {
                return NotFound();
            }
            return View(klienci);
        }

        // POST: Kliencis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KlienciId,Imie,Nazwisko,NumerTel")] Klienci klienci)
        {
            if (id != klienci.KlienciId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klienci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlienciExists(klienci.KlienciId))
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
            return View(klienci);
        }

        // GET: Kliencis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klienci = await _context.Klienci
                .FirstOrDefaultAsync(m => m.KlienciId == id);
            if (klienci == null)
            {
                return NotFound();
            }

            return View(klienci);
        }

        // POST: Kliencis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klienci = await _context.Klienci.FindAsync(id);
            _context.Klienci.Remove(klienci);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlienciExists(int id)
        {
            return _context.Klienci.Any(e => e.KlienciId == id);
        }
    }
}
