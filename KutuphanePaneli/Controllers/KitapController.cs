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
    public class KitapController : Controller
    {
        Models.DbKutuphaneProjesiContext db = new Models.DbKutuphaneProjesiContext();
        public ActionResult KitapIndex()
        {
            var kitaplar = db.TblKitaps.Include(x => x.KategoriNavigation).Include(x => x.YazarNavigation).ToList();
            return View(kitaplar);
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TblKategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.Id.ToString()
                                           }).ToList();


            ViewBag.Kategori = deger1;
            List<SelectListItem> deger2 = (from i in db.TblYazars.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + " " + i.Soyad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.Yazar = deger2;

            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(Models.TblKitap kitap)
        {

            db.TblKitaps.Add(kitap);
            db.SaveChanges();
            return RedirectToAction("KitapIndex", "Kitap");

        }
        public ActionResult KitapSil(int id)
        {
            if (id > 0)
            {
                Models.TblKitap kitap = new Models.TblKitap();
                kitap = db.TblKitaps.Find(id);
                if (kitap != null)
                {

                    db.TblKitaps.Remove(kitap);
                }
                db.SaveChanges();
            }

            return RedirectToAction("KitapIndex", "Kitap");
        }
        public IActionResult KitapGetir(int id)
        {
            Models.TblKitap kitap = new Models.TblKitap();
            kitap = db.TblKitaps.Find(id);
            List<SelectListItem> deger1 = (from i in db.TblKategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.Id.ToString()
                                           }).ToList();


            ViewBag.Kategori = deger1;
            List<SelectListItem> deger2 = (from i in db.TblYazars.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + " " + i.Soyad,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.Yazar = deger2;

            return View("KitapGetir", kitap);

        }

        [HttpPost]
        public ActionResult KitapGuncelle(Models.TblKitap p)
        {
            Models.TblKitap kitap = new Models.TblKitap();

            kitap = db.TblKitaps.Find(p.Id);
            kitap.Ad = p.Ad;
            kitap.Basimyili = p.Basimyili;
            kitap.Sayfasayisi = p.Sayfasayisi;
            kitap.Yayinevi = p.Yayinevi;
            kitap.Durum = true;
            kitap.Kategori = p.Kategori;
            kitap.Yazar = p.Yazar;
            db.SaveChanges();
            return RedirectToAction("KitapIndex", "Kitap");

        }
    }
}
