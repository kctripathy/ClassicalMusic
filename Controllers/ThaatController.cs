using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassicalMusicApp.Models;
using ClassicalMusicApp.ViewModels;

namespace ClassicalMusicApp.Controllers
{
    public class ThaatController : Controller
    {
        private IndianClassicalMusicEntities db = new IndianClassicalMusicEntities();

        // GET: Thaat
        public ActionResult Index()
        {
            var thaats = db.Thaats.Where(t => t.MusicTypeID == 1).ToList();
            return View(thaats);
        }

        [Route("thaat/{name}")]
        public ActionResult Details(string name)
        {
            ThaatDetailsViewModel thaatDetails = new ThaatDetailsViewModel();
            int? appResourceId = LanguageHelper.GetCurrenAppResourceId();
            var thaat = db.Thaats.Where(t=> t.ThaatName.ToLower() == name.ToLower() && t.AppResourceID == appResourceId).SingleOrDefault();

            thaatDetails.thaat = thaat;
            thaatDetails.raagas = db.Raagas.Where(c => c.IsActive == true && c.AppResourceID == appResourceId && c.ThaatID == thaat.ID).ToList();
            
            return View(thaatDetails);
        }
    }
}