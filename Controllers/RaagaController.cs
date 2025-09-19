using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassicalMusicApp.Models;
using ClassicalMusicApp.ViewModels;

namespace ClassicalMusicApp.Controllers
{
    public class RaagaController : Controller
    {
        private IndianClassicalMusicEntities db = new IndianClassicalMusicEntities();

        // GET: Raaga
        public ActionResult Index()
        {
            int? appResourceId = LanguageHelper.GetCurrenAppResourceId();
            var ragas = db.Raagas.Where(r=>r.IsActive == true && r.AppResourceID == appResourceId).ToList();
            return View(ragas);
        }

        [Route("raaga/{name}")]
        public ActionResult Details(string name)
        {
            RaagaDetailsViewModel ragaDetails = new RaagaDetailsViewModel();
            int? appResourceId = LanguageHelper.GetCurrenAppResourceId();
            //var raga = db.Raagas.Where(r => r.IsActive == true && r.AppResourceID == appResourceId && r.RaagaName.ToLower() == name.ToLower()).SingleOrDefault();
            var raga = db.Raagas.Where(r => r.IsActive == true && r.RaagaName.ToLower() == name.ToLower()).SingleOrDefault();

            ragaDetails.raaga = raga;
            ragaDetails.compositions = db.Compositions.Where(c => c.IsActive == true && c.AppResourceID == appResourceId && c.RagaID == raga.ID).ToList();
            ragaDetails.appImages = db.AppImages.Where(i=> i.Image_For == "Raaga" && i.Image_For_Id == raga.ID).ToList();
            ragaDetails.appDocuments = db.AppDocuments.Where(i => i.Document_For == "Raaga" && i.Document_For_Id == raga.ID).ToList();

            return View(ragaDetails);
        }
        
    }
}