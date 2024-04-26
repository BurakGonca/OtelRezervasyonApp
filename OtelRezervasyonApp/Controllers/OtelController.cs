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
    public class OtelController : Controller
    {
        private readonly OtelRezervasyonDbContext _context;

        public OtelController(OtelRezervasyonDbContext context)
        {
            _context = context;
        }

        // GET: Otel
        public async Task<IActionResult> Index()
        {
            var otelRezervasyonDbContext = _context.Oteller.Include(o => o.OtelTuru).Include(o => o.Sehir).Include(o => o.Ulke);
            return View(await otelRezervasyonDbContext.ToListAsync());
        }

        // GET: Otel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otel = await _context.Oteller
                .Include(o => o.OtelTuru)
                .Include(o => o.Sehir)
                .Include(o => o.Ulke)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (otel == null)
            {
                return NotFound();
            }

            return View(otel);
        }

        // GET: Otel/Create
        public IActionResult Create()
        {
            ViewData["OtelTuruId"] = new SelectList(_context.OtelTurleri, "Id", "Name");
            ViewData["SehirId"] = new SelectList(_context.Sehirler, "Id", "Name");
            ViewData["UlkeId"] = new SelectList(_context.Ulkeler, "Id", "Name");
            return View();
        }

        // POST: Otel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adi,Aciklama,OtelTuruId,Yildizi,Adres,UlkeId,SehirId,Telefon,Email,Logo")] Otel otel)
        {

            ModelState.Remove("OtelTuru");
            ModelState.Remove("Ulke");
            ModelState.Remove("Sehir");


            if (ModelState.IsValid)
            {
                _context.Add(otel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OtelTuruId"] = new SelectList(_context.OtelTurleri, "Id", "Name", otel.OtelTuruId);
            ViewData["SehirId"] = new SelectList(_context.Sehirler, "Id", "Name", otel.SehirId);
            ViewData["UlkeId"] = new SelectList(_context.Ulkeler, "Id", "Name", otel.UlkeId);
            return View(otel);
        }

        // GET: Otel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otel = await _context.Oteller.FindAsync(id);
            if (otel == null)
            {
                return NotFound();
            }
            ViewData["OtelTuruId"] = new SelectList(_context.OtelTurleri, "Id", "Name", otel.OtelTuruId);
            ViewData["SehirId"] = new SelectList(_context.Sehirler, "Id", "Name", otel.SehirId);
            ViewData["UlkeId"] = new SelectList(_context.Ulkeler, "Id", "Name", otel.UlkeId);
            return View(otel);
        }

        // POST: Otel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adi,Aciklama,OtelTuruId,Yildizi,Adres,UlkeId,SehirId,Telefon,Email,Logo")] Otel otel)
        {
            if (id != otel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(otel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtelExists(otel.Id))
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
            ViewData["OtelTuruId"] = new SelectList(_context.OtelTurleri, "Id", "Name", otel.OtelTuruId);
            ViewData["SehirId"] = new SelectList(_context.Sehirler, "Id", "Name", otel.SehirId);
            ViewData["UlkeId"] = new SelectList(_context.Ulkeler, "Id", "Name", otel.UlkeId);
            return View(otel);
        }

        // GET: Otel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otel = await _context.Oteller
                .Include(o => o.OtelTuru)
                .Include(o => o.Sehir)
                .Include(o => o.Ulke)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (otel == null)
            {
                return NotFound();
            }

            return View(otel);
        }

        // POST: Otel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var otel = await _context.Oteller.FindAsync(id);
            if (otel != null)
            {
                _context.Oteller.Remove(otel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OtelExists(int id)
        {
            return _context.Oteller.Any(e => e.Id == id);
        }
    }
}
