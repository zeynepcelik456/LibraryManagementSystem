using KutuphanePaneli.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphanePaneli.Controllers
{
    [IsLogin]
    public class KategoriController : Controller
    {
        Models.DbKutuphaneProjesiContext db = new Models.DbKutuphaneProjesiContext();
        public ActionResult KategoriIndex()
        {
            var kategoriler = db.TblKategoris.ToList();
            return View(kategoriler);
        }
        public ActionResult KategoriEkle()
        {

            return View();

        }
        [HttpPost]
        public ActionResult KategoriEkle(Models.TblKategori kategori)
        {

            db.TblKategoris.Add(kategori);
            db.SaveChanges();
            return RedirectToAction("KategoriIndex", "Kategori");

        }
        public ActionResult KategoriSil(int id)
        {

            if (id > 0)
            {
                Models.TblKategori ktg = new Models.TblKategori();
                ktg = db.TblKategoris.Find(Convert.ToByte(id));
                if (ktg != null)
                {

                    db.TblKategoris.Remove(ktg);
                }
                db.SaveChanges();
            }

            return RedirectToAction("KategoriIndex", "Kategori");
        }

        public IActionResult KategoriGetir(int id)
        {
            Models.TblKategori ktg = new Models.TblKategori();
            ktg = db.TblKategoris.Find(Convert.ToByte(id));

            return View("KategoriGetir", ktg);

        }

        [HttpPost]
        public ActionResult KategoriGuncelle(Models.TblKategori y)
        {
            Models.TblKategori ktg = new Models.TblKategori();

            ktg = db.TblKategoris.Find(y.Id);
            ktg.Ad = y.Ad;

            db.SaveChanges();
            return RedirectToAction("KategoriIndex", "Kategori");

        }
    }
}
