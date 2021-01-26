using KutuphanePaneli.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphanePaneli.Controllers
{
    [IsLogin]
    public class YazarController : Controller
    {
        Models.DbKutuphaneProjesiContext db = new Models.DbKutuphaneProjesiContext();
        public ActionResult YazarIndex()
        {
            var yazarlar = db.TblYazars.ToList();
            return View(yazarlar);
        }
        public ActionResult YazarEkle()
        {


            return View();
        }

        [HttpPost]
        public ActionResult YazarEkle(Models.TblYazar yazar)
        {

            db.TblYazars.Add(yazar);
            db.SaveChanges();
            return RedirectToAction("YazarIndex", "Yazar");

        }

        public ActionResult YazarSil(int id)
        {
            if (id > 0)
            {
                Models.TblYazar yazar = new Models.TblYazar();
                yazar = db.TblYazars.Find(id);
                if (yazar != null)
                {

                    db.TblYazars.Remove(yazar);
                }
                db.SaveChanges();
            }

            return RedirectToAction("YazarIndex", "Yazar");
        }

        public IActionResult YazarGetir(int id)
        {
            Models.TblYazar yazar = new Models.TblYazar();
            yazar = db.TblYazars.Find(id);

            return View("YazarGetir", yazar);

        }

        [HttpPost]
        public ActionResult YazarGuncelle(Models.TblYazar y)
        {
            Models.TblYazar yazar = new Models.TblYazar();

            yazar = db.TblYazars.Find(y.Id);
            yazar.Ad = y.Ad;
            yazar.Soyad = y.Soyad;
            db.SaveChanges();
            return RedirectToAction("YazarIndex", "Yazar");

        }
    }
}
