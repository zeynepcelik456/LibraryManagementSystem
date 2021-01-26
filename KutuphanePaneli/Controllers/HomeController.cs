using KutuphanePaneli.Helper;
using KutuphanePaneli.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphanePaneli.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       
        Models.DbKutuphaneProjesiContext db = new DbKutuphaneProjesiContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [IsLogin]
        public IActionResult Index()
        {
            var toplamKitap = db.TblKitaps.Count();
            var toplamUye = db.TblUyes.Count();
            var toplamYazar = db.TblYazars.Count();
            var toplamIslem = db.TblHarekets.Count();
            ViewBag.tk = toplamKitap;
            ViewBag.tu = toplamUye;
            ViewBag.ty = toplamYazar;
            ViewBag.tı = toplamIslem;

            var ıslemler = db.TblHarekets.Include(x => x.KitapNavigation).Include(x => x.PersonelNavigation).Include(x => x.UyeNavigation).ToList();

            return View(ıslemler);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Models.TblPersonel admin)
        {
            int result = 0;
            var adminLogin = db.TblPersonels.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            
            result = adminLogin.Id > 0 ? adminLogin.Id : 0;

            if (result != 0 && result > 0)
            {

                HttpContext.Session.SetInt32("LoginKontrol", result);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
