using KutuphanePaneli.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphanePaneli.Controllers
{
    [IsLogin]
    public class PersonelController : Controller
    {
        Models.DbKutuphaneProjesiContext db = new Models.DbKutuphaneProjesiContext();
        public ActionResult PersonelIndex()
        {
            var personel = db.TblPersonels.ToList();
            return View(personel);
        }
        public ActionResult PersonelEkle()
        {


            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Models.TblPersonel pers)
        {

            db.TblPersonels.Add(pers);
            db.SaveChanges();
            return RedirectToAction("PersonelIndex", "Personel");

        }

        public ActionResult PersonelSil(int id)
        {
            if (id > 0)
            {
                Models.TblPersonel personel = new Models.TblPersonel();
                personel = db.TblPersonels.Find(Convert.ToByte(id));
                if (personel != null)
                {

                    db.TblPersonels.Remove(personel);
                }
                db.SaveChanges();
            }

            return RedirectToAction("PersonelIndex", "Personel");
        }

        public IActionResult PersonelGetir(int id)
        {
            Models.TblPersonel personel = new Models.TblPersonel();
            personel = db.TblPersonels.Find(Convert.ToByte(id));

            return View("PersonelGetir", personel);

        }

        [HttpPost]
        public ActionResult PersonelGuncelle(Models.TblPersonel y)
        {
            Models.TblPersonel personel = new Models.TblPersonel();

            personel = db.TblPersonels.Find(y.Id);
            personel.Personel = y.Personel;
            personel.Username = y.Username;
            personel.Password = y.Password;
            db.SaveChanges();
            return RedirectToAction("PersonelIndex", "Personel");

        }
    }
}
