using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassicalMusicApp.Models;

namespace ClassicalMusicApp.Controllers
{
    public class TalaController : Controller
    {
        private IndianClassicalMusicEntities db = new IndianClassicalMusicEntities();

        // GET: Tala
        public ActionResult Index()
        {
            var talas = db.Talas.ToList();
            return View(talas);
        }
    }
}