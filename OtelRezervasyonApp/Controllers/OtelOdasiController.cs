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
    public class OtelOdasiController : Controller
    {
        private readonly OtelRezervasyonDbContext _context;

        public OtelOdasiController(OtelRezervasyonDbContext context)
        {
            _context = context;
        }

        // GET: OtelOdasi
        public async Task<IActionResult> Index()
        {
            var otelRezervasyonDbContext = _context.OtelOdalari.Include(o => o.OdaTuru).Include(o => o.Otel);
            return View(await otelRezervasyonDbContext.ToListAsync());
        }

        // GET: OtelOdasi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otelOdasi = await _context.OtelOdalari
                .Include(o => o.OdaTuru)
                .Include(o => o.Otel)
                .FirstOrDefaultAsync(m => m.OdaId == id);
            if (otelOdasi == null)
            {
                return NotFound();
            }

            return View(otelOdasi);
        }

        // GET: OtelOdasi/Create
        public IActionResult Create()
        {
            ViewData["OdaTuruId"] = new SelectList(_context.OdaTurleri, "Id", "OdaTurAdi");
            ViewData["OtelId"] = new SelectList(_context.Oteller, "Id", "Adi");
            return View();
        }

        // POST: OtelOdasi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OdaId,OtelId,OdaNumarasi,BulunduguKat,OdaOlcusuM2,OdaKapasitesi,OdaTuruId")] OtelOdasi otelOdasi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(otelOdasi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OdaTuruId"] = new SelectList(_context.OdaTurleri, "Id", "OdaTurAdi", otelOdasi.OdaTuruId);
            ViewData["OtelId"] = new SelectList(_context.Oteller, "Id", "Adi", otelOdasi.OtelId);
            return View(otelOdasi);
        }

        // GET: OtelOdasi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otelOdasi = await _context.OtelOdalari.FindAsync(id);
            if (otelOdasi == null)
            {
                return NotFound();
            }
            ViewData["OdaTuruId"] = new SelectList(_context.OdaTurleri, "Id", "OdaTurAdi", otelOdasi.OdaTuruId);
            ViewData["OtelId"] = new SelectList(_context.Oteller, "Id", "Adi", otelOdasi.OtelId);
            return View(otelOdasi);
        }

        // POST: OtelOdasi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OdaId,OtelId,OdaNumarasi,BulunduguKat,OdaOlcusuM2,OdaKapasitesi,OdaTuruId")] OtelOdasi otelOdasi)
        {
            if (id != otelOdasi.OdaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(otelOdasi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtelOdasiExists(otelOdasi.OdaId))
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
            ViewData["OdaTuruId"] = new SelectList(_context.OdaTurleri, "Id", "Id", otelOdasi.OdaTuruId);
            ViewData["OtelId"] = new SelectList(_context.Oteller, "Id", "Id", otelOdasi.OtelId);
            return View(otelOdasi);
        }

        // GET: OtelOdasi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otelOdasi = await _context.OtelOdalari
                .Include(o => o.OdaTuru)
                .Include(o => o.Otel)
                .FirstOrDefaultAsync(m => m.OdaId == id);
            if (otelOdasi == null)
            {
                return NotFound();
            }

            return View(otelOdasi);
        }

        // POST: OtelOdasi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var otelOdasi = await _context.OtelOdalari.FindAsync(id);
            if (otelOdasi != null)
            {
                _context.OtelOdalari.Remove(otelOdasi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OtelOdasiExists(int id)
        {
            return _context.OtelOdalari.Any(e => e.OdaId == id);
        }
    }
}
