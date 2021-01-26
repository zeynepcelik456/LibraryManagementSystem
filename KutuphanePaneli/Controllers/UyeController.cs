using KutuphanePaneli.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphanePaneli.Controllers
{
    [IsLogin]
    public class UyeController : Controller
    {


        Models.DbKutuphaneProjesiContext db = new Models.DbKutuphaneProjesiContext();
        public ActionResult UyeIndex()
        {
            var uyeler = db.TblUyes.ToList();
            return View(uyeler);
        }
        public ActionResult UyeEkle()
        {


            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(Models.TblUye uye)
        {

            db.TblUyes.Add(uye);
            db.SaveChanges();
            return RedirectToAction("UyeIndex", "Uye");

        }
        public ActionResult UyeSil(int id)
        {
            if (id > 0)
            {
                Models.TblUye uye = new Models.TblUye();
                uye = db.TblUyes.Find(id);
                if (uye != null)
                {

                    db.TblUyes.Remove(uye);
                }
                db.SaveChanges();
            }

            return RedirectToAction("UyeIndex", "Uye");
        }

        public IActionResult UyeGetir(int id)
        {
            Models.TblUye uye = new Models.TblUye();
            uye = db.TblUyes.Find(id);
            return View("UyeGetir", uye);

        }

        [HttpPost]
        public ActionResult UyeGuncelle(Models.TblUye y)
        {
            Models.TblUye uye = new Models.TblUye();

            uye = db.TblUyes.Find(y.Id);
            uye.Ad = y.Ad;
            uye.Soyad = y.Soyad;
            uye.Maİl = y.Maİl;
            uye.Telefon = y.Telefon;

            db.SaveChanges();
            return RedirectToAction("UyeIndex", "Uye");

        }
    }
}

