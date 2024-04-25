using Microsoft.AspNetCore.Mvc;
using OtelRezervasyonApp.Data;
using OtelRezervasyonApp.Data.Entities;
using OtelRezervasyonApp.Models;
using System.ComponentModel.DataAnnotations;

namespace OtelRezervasyonApp.Controllers
{
    public class OtelController : Controller
    {

        private OtelRezervasyonDbContext _otelDbContext;

        public OtelController(OtelRezervasyonDbContext dbContext)
        {
                _otelDbContext = dbContext;
        }




        public IActionResult Index()
        {
            var oteller = _otelDbContext.Oteller.ToList();

            return View(oteller);
        }




       
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Otel model)
        {
            try
            {
                _otelDbContext.Oteller.Add(model);
                _otelDbContext.SaveChanges();



                //TempData["kayit"] = true;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                //TempData["kayit"] = false;

                return View();
            }
        }




        
        public ActionResult Delete(int id)
        {

            Otel Model = _otelDbContext.Oteller.Single(o => o.Id == id);
            return View(Model);

        }


        




       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                Otel Model = _otelDbContext.Oteller.Single(o => o.Id == id);
                _otelDbContext.Oteller.Remove(Model);
                _otelDbContext.SaveChanges();



                //TempData["sil"] = true;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




        



      
        public ActionResult Edit(int id)
        {
            Otel model = _otelDbContext.Oteller.Single(o => o.Id == id);

            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Otel newModel)
        {
            try
            {
                Otel oldModel = _otelDbContext.Oteller.Single(o => o.Id == id);
                oldModel.Adi = newModel.Adi;
                oldModel.Aciklama = newModel.Aciklama;
                oldModel.Turu = newModel.Turu;
                oldModel.Yildizi = newModel.Yildizi;
                oldModel.Adres = newModel.Adres;
                oldModel.Ulke = newModel.Ulke;
                oldModel.Sehir = newModel.Sehir;
                oldModel.Telefon = newModel.Telefon;
                oldModel.Email = newModel.Email;
                oldModel.Logo = newModel.Logo;
                

                _otelDbContext.Oteller.Update(oldModel);
                _otelDbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        

    }
}
