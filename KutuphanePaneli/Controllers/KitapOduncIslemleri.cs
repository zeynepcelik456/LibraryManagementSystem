using KutuphanePaneli.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphanePaneli.Controllers
{
    [IsLogin]
    public class KitapOduncIslemleri : Controller
    {
        Models.DbKutuphaneProjesiContext db = new Models.DbKutuphaneProjesiContext();
        public IActionResult OdunVer()
        {
            List<SelectListItem> deger1 = (from i in db.TblUyes.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + " " + i.Soyad,
                                               Value = i.Id.ToString()
                                           }).ToList();


            ViewBag.Uye = deger1;
            List<SelectListItem> deger2 = (from i in db.TblKitaps.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.Kitap = deger2;
            List<SelectListItem> deger3 = (from i in db.TblPersonels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Personel,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.Personel = deger3;
            return View();
        }

        [HttpPost]
        public IActionResult OdunVer(Models.TblHareket h)
        {
            db.TblHarekets.Add(h);
            db.SaveChanges();
            List<SelectListItem> deger1 = (from i in db.TblUyes.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + " " + i.Soyad,
                                               Value = i.Id.ToString()
                                           }).ToList();


            ViewBag.Uye = deger1;
            List<SelectListItem> deger2 = (from i in db.TblKitaps.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.Kitap = deger2;
            List<SelectListItem> deger3 = (from i in db.TblPersonels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Personel,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.Personel = deger3;


            return View();
        }


        public ActionResult KitabıGeriAl()
        {
            var odunckitaplar = db.TblHarekets.Include(x => x.KitapNavigation).Include(x => x.PersonelNavigation).Include(x => x.UyeNavigation).Where(x => x.Islemdurum == false).ToList();
            return View(odunckitaplar);
        }


        public ActionResult OduncIade(int id)
        {
            Models.TblHareket odn = new Models.TblHareket();
            odn = db.TblHarekets.Find(id);
            List<SelectListItem> deger1 = (from i in db.TblUyes.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + " " + i.Soyad,
                                               Value = i.Id.ToString()
                                           }).ToList();


            ViewBag.Uye = deger1;
            List<SelectListItem> deger2 = (from i in db.TblKitaps.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.Kitap = deger2;
            List<SelectListItem> deger3 = (from i in db.TblPersonels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Personel,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.Personel = deger3;


            return View("OduncIade", odn);
        }

        [HttpPost]
        public ActionResult OduncGuncelle(Models.TblHareket h)
        {
            Models.TblHareket hareket = new Models.TblHareket();

            hareket = db.TblHarekets.Find(h.Id);
            hareket.Islemdurum = true;
            db.SaveChanges();
            return RedirectToAction("KitabıGeriAl", "KitapOduncIslemleri");

        }


    }
}
