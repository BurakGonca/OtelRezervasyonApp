using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OtelRezervasyonApp.Data;
using OtelRezervasyonApp.Data.Entities;

namespace OtelRezervasyonApp.Controllers
{
    public class OtelKapasitesiController : Controller
    {
        private readonly OtelRezervasyonDbContext _context;

        public OtelKapasitesiController(OtelRezervasyonDbContext context)
        {
            _context = context;
        }

        // GET: OtelKapasitesi
        public async Task<IActionResult> Index()
        {
            var otelRezervasyonDbContext = _context.OtelKapasiteleri.Include(o => o.Otel);
            return View(await otelRezervasyonDbContext.ToListAsync());
        }

        // GET: OtelKapasitesi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otelKapasitesi = await _context.OtelKapasiteleri
                .Include(o => o.Otel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (otelKapasitesi == null)
            {
                return NotFound();
            }

            return View(otelKapasitesi);
        }

        // GET: OtelKapasitesi/Create
        public IActionResult Create()
        {
            ViewData["OtelId"] = new SelectList(_context.Oteller, "Id", "Adi");
            return View();
        }

        // POST: OtelKapasitesi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OtelId,OtelToplamKapasite")] OtelKapasitesi otelKapasitesi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(otelKapasitesi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OtelId"] = new SelectList(_context.Oteller, "Id", "Adi", otelKapasitesi.OtelId);
            return View(otelKapasitesi);
        }

        // GET: OtelKapasitesi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otelKapasitesi = await _context.OtelKapasiteleri.FindAsync(id);
            if (otelKapasitesi == null)
            {
                return NotFound();
            }
            ViewData["OtelId"] = new SelectList(_context.Oteller, "Id", "Adi", otelKapasitesi.OtelId);
            return View(otelKapasitesi);
        }

        // POST: OtelKapasitesi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OtelId,OtelToplamKapasite")] OtelKapasitesi otelKapasitesi)
        {
            if (id != otelKapasitesi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(otelKapasitesi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtelKapasitesiExists(otelKapasitesi.Id))
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
            ViewData["OtelId"] = new SelectList(_context.Oteller, "Id", "Id", otelKapasitesi.OtelId);
            return View(otelKapasitesi);
        }

        // GET: OtelKapasitesi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otelKapasitesi = await _context.OtelKapasiteleri
                .Include(o => o.Otel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (otelKapasitesi == null)
            {
                return NotFound();
            }

            return View(otelKapasitesi);
        }

        // POST: OtelKapasitesi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var otelKapasitesi = await _context.OtelKapasiteleri.FindAsync(id);
            if (otelKapasitesi != null)
            {
                _context.OtelKapasiteleri.Remove(otelKapasitesi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OtelKapasitesiExists(int id)
        {
            return _context.OtelKapasiteleri.Any(e => e.Id == id);
        }
    }
}
