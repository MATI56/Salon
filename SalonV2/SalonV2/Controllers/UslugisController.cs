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
    public class UslugisController : Controller
    {
        private readonly SalonV2Context _context;

        public UslugisController(SalonV2Context context)
        {
            _context = context;
        }

        // GET: Uslugis
        public async Task<IActionResult> Index(int intid)
        {
            var salonV2Context = _context.Uslugi.Include(u => u.Klienci);
            if (intid != 0)
            {
                return View(await salonV2Context.Where(n => n.KlienciId == intid).ToListAsync());
            }
            else
            {
                return View(await salonV2Context.ToListAsync());
            }
        }


        // GET: Uslugis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uslugi = await _context.Uslugi
                .Include(u => u.Klienci)
                .FirstOrDefaultAsync(m => m.UslugiId == id);
            if (uslugi == null)
            {
                return NotFound();
            }

            return View(uslugi);
        }

        // GET: Uslugis/Create
        public IActionResult Create()
        {
            ViewData["KlienciId"] = new SelectList(_context.Klienci, "KlienciId", "Nazwisko");
            return View();
        }

        // POST: Uslugis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UslugiId,Nazwa,Cena,DataRozpo,DataZak,Produkty,Uwagi,KlienciId")] Uslugi uslugi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uslugi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlienciId"] = new SelectList(_context.Klienci, "KlienciId", "Nazwisko", uslugi.KlienciId);
            return View(uslugi);
        }

        // GET: Uslugis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uslugi = await _context.Uslugi.FindAsync(id);
            if (uslugi == null)
            {
                return NotFound();
            }
            ViewData["KlienciId"] = new SelectList(_context.Klienci, "KlienciId", "Nazwisko", uslugi.KlienciId);
            return View(uslugi);
        }

        // POST: Uslugis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UslugiId,Nazwa,Cena,DataRozpo,DataZak,Produkty,Uwagi,KlienciId")] Uslugi uslugi)
        {
            if (id != uslugi.UslugiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uslugi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UslugiExists(uslugi.UslugiId))
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
            ViewData["KlienciId"] = new SelectList(_context.Klienci, "KlienciId", "Imie", uslugi.KlienciId);
            return View(uslugi);
        }

        // GET: Uslugis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uslugi = await _context.Uslugi
                .Include(u => u.Klienci)
                .FirstOrDefaultAsync(m => m.UslugiId == id);
            if (uslugi == null)
            {
                return NotFound();
            }

            return View(uslugi);
        }

        // POST: Uslugis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uslugi = await _context.Uslugi.FindAsync(id);
            _context.Uslugi.Remove(uslugi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UslugiExists(int id)
        {
            return _context.Uslugi.Any(e => e.UslugiId == id);
        }
    }
}
