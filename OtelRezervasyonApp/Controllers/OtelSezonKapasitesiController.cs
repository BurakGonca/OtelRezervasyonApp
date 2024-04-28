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
    public class OtelSezonKapasitesiController : Controller
    {
        private readonly OtelRezervasyonDbContext _context;

        public OtelSezonKapasitesiController(OtelRezervasyonDbContext context)
        {
            _context = context;
        }

        // GET: OtelSezonKapasitesi
        public async Task<IActionResult> Index()
        {
            var otelRezervasyonDbContext = _context.OtelSezonKapasiteleri.Include(o => o.Otel).Include(o => o.Sezon);
            return View(await otelRezervasyonDbContext.ToListAsync());
        }

        // GET: OtelSezonKapasitesi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otelSezonKapasitesi = await _context.OtelSezonKapasiteleri
                .Include(o => o.Otel)
                .Include(o => o.Sezon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (otelSezonKapasitesi == null)
            {
                return NotFound();
            }

            return View(otelSezonKapasitesi);
        }

        // GET: OtelSezonKapasitesi/Create
        public IActionResult Create()
        {
            ViewData["OtelId"] = new SelectList(_context.Oteller, "Id", "Adi");
            ViewData["SezonId"] = new SelectList(_context.Sezonlar, "Id", "SezonAdi");
            return View();
        }

        // POST: OtelSezonKapasitesi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OtelId,SezonId,OtelSezonKapasite")] OtelSezonKapasitesi otelSezonKapasitesi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(otelSezonKapasitesi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OtelId"] = new SelectList(_context.Oteller, "Id", "Id", otelSezonKapasitesi.OtelId);
            ViewData["SezonId"] = new SelectList(_context.Sezonlar, "Id", "SezonAdi", otelSezonKapasitesi.SezonId);
            return View(otelSezonKapasitesi);
        }

        // GET: OtelSezonKapasitesi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otelSezonKapasitesi = await _context.OtelSezonKapasiteleri.FindAsync(id);
            if (otelSezonKapasitesi == null)
            {
                return NotFound();
            }
            ViewData["OtelId"] = new SelectList(_context.Oteller, "Id", "Adi", otelSezonKapasitesi.OtelId);
            ViewData["SezonId"] = new SelectList(_context.Sezonlar, "Id", "SezonAdi", otelSezonKapasitesi.SezonId);
            return View(otelSezonKapasitesi);
        }

        // POST: OtelSezonKapasitesi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OtelId,SezonId,OtelSezonKapasite")] OtelSezonKapasitesi otelSezonKapasitesi)
        {
            if (id != otelSezonKapasitesi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(otelSezonKapasitesi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtelSezonKapasitesiExists(otelSezonKapasitesi.Id))
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
            ViewData["OtelId"] = new SelectList(_context.Oteller, "Id", "Id", otelSezonKapasitesi.OtelId);
            ViewData["SezonId"] = new SelectList(_context.Sezonlar, "Id", "Id", otelSezonKapasitesi.SezonId);
            return View(otelSezonKapasitesi);
        }

        // GET: OtelSezonKapasitesi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otelSezonKapasitesi = await _context.OtelSezonKapasiteleri
                .Include(o => o.Otel)
                .Include(o => o.Sezon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (otelSezonKapasitesi == null)
            {
                return NotFound();
            }

            return View(otelSezonKapasitesi);
        }

        // POST: OtelSezonKapasitesi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var otelSezonKapasitesi = await _context.OtelSezonKapasiteleri.FindAsync(id);
            if (otelSezonKapasitesi != null)
            {
                _context.OtelSezonKapasiteleri.Remove(otelSezonKapasitesi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OtelSezonKapasitesiExists(int id)
        {
            return _context.OtelSezonKapasiteleri.Any(e => e.Id == id);
        }
    }
}
