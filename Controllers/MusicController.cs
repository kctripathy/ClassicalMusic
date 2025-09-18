using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassicalMusicApp.Models;


namespace ClassicalMusicApp.Controllers
{
    public class MusicController : Controller
    {
        private IndianClassicalMusicEntities db = new IndianClassicalMusicEntities();

        // GET: Music
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Thaat()
        {
            var thaats = db.Thaats.Where(t => t.MusicTypeID == 1).ToList();
            return View(thaats);
        }

        public ActionResult Raagas(int? id)
        {
            dynamic ragas;
            if ((id == null) || (id == 0))
            {
                ragas = db.Raagas.ToList();
            }
            else
            {
                ragas = db.Raagas.Where(r=> r.ID == id).ToList();
            }
            return View(ragas);
        }

        //public ActionResult RaagaDetails(int? id)
        //{

        //    var raga = db.Ragas.Where(r => r.ID == id).SingleOrDefault();
        //    //var compositions = db.Compositions.Where(c => c.RagaID == id).ToList();
        //    var result = db.GetCompositionsByRaagId(id).ToList();
        //    RagaDetailsViewModel radaDetails = new RagaDetailsViewModel
        //    {
        //        Raga = raga,
        //        Compositions = result
        //    };
        //    return View(radaDetails);
        //}

        public ActionResult RaagasOfThaat(int? id)
        {
            var ragas = db.Raagas.Where(r => r.ThaatID == id).ToList();
            return View(ragas);
        }

        public ActionResult Tala()
        {
            //var talas = db.Talas.ToList();
            return View();
        }
    }
}