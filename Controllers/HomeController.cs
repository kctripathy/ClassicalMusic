using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassicalMusicApp.Models;

namespace ClassicalMusicApp.Controllers
{
    public class HomeController : Controller
    {
        private IndianClassicalMusicEntities db = new IndianClassicalMusicEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 86400, VaryByParam = "none", VaryByCustom = "Daily")]
        public PartialViewResult RaagaOfTheDay()
        {
            int appResId = LanguageHelper.GetCurrenAppResourceId();

            var random = new Random();
            var raagas = db.Raagas.Where(r=> r.AppResourceID == appResId).ToList();
            if (raagas.Count == 0)
            {
                raagas = db.Raagas.Where(r => r.AppResourceID == 1).ToList();
            }

            var raaga = raagas[random.Next(raagas.Count)];

            return PartialView(raaga);
        }
    }
}