using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassicalMusicApp.Models;

namespace ClassicalMusicApp.Areas.Admin.Controllers
{
    public class CompositionsController : Controller
    {
        private IndianClassicalMusicEntities db = new IndianClassicalMusicEntities();

        // GET: Admin/Compositions
        public ActionResult Index()
        {
            var compositions = db.Compositions.Include(c => c.AppResource).Include(c => c.Artist).Include(c => c.Language).Include(c => c.Movie).Include(c => c.MusicType).Include(c => c.Raaga).Include(c => c.Tala);
            return View(compositions.ToList());
        }

        // GET: Admin/Compositions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Composition composition = db.Compositions.Find(id);
            if (composition == null)
            {
                return HttpNotFound();
            }
            return View(composition);
        }

        // GET: Admin/Compositions/Create
        public ActionResult Create()
        {
            ViewBag.AppResourceID = new SelectList(db.AppResources, "ID", "AppResource_name");
            ViewBag.ComposerID = new SelectList(db.Artists, "ID", "ArtistName");
            ViewBag.LanguageID = new SelectList(db.Languages, "ID", "LanguageName");
            ViewBag.MovieID = new SelectList(db.Movies, "ID", "MovieName");
            ViewBag.MusicTypeID = new SelectList(db.MusicTypes, "ID", "MusicTypeName");
            ViewBag.RagaID = new SelectList(db.Raagas, "ID", "RaagaName");
            ViewBag.TalaID = new SelectList(db.Talas, "ID", "TalaName");
            return View();
        }

        // POST: Admin/Compositions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Lyrics,LanguageID,RagaID,TalaID,ComposerID,MovieID,MusicTypeID,AppResourceID,IsActive,AddedBy,AddedDate,ModifiedBy,ModifiedDate")] Composition composition)
        {
            if (ModelState.IsValid)
            {
                db.Compositions.Add(composition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppResourceID = new SelectList(db.AppResources, "ID", "AppResource_name", composition.AppResourceID);
            ViewBag.ComposerID = new SelectList(db.Artists, "ID", "ArtistName", composition.ComposerID);
            ViewBag.LanguageID = new SelectList(db.Languages, "ID", "LanguageName", composition.LanguageID);
            ViewBag.MovieID = new SelectList(db.Movies, "ID", "MovieName", composition.MovieID);
            ViewBag.MusicTypeID = new SelectList(db.MusicTypes, "ID", "MusicTypeName", composition.MusicTypeID);
            ViewBag.RagaID = new SelectList(db.Raagas, "ID", "RaagaName", composition.RagaID);
            ViewBag.TalaID = new SelectList(db.Talas, "ID", "TalaName", composition.TalaID);
            return View(composition);
        }

        // GET: Admin/Compositions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Composition composition = db.Compositions.Find(id);
            if (composition == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppResourceID = new SelectList(db.AppResources, "ID", "AppResource_name", composition.AppResourceID);
            ViewBag.ComposerID = new SelectList(db.Artists, "ID", "ArtistName", composition.ComposerID);
            ViewBag.LanguageID = new SelectList(db.Languages, "ID", "LanguageName", composition.LanguageID);
            ViewBag.MovieID = new SelectList(db.Movies, "ID", "MovieName", composition.MovieID);
            ViewBag.MusicTypeID = new SelectList(db.MusicTypes, "ID", "MusicTypeName", composition.MusicTypeID);
            ViewBag.RagaID = new SelectList(db.Raagas, "ID", "RaagaName", composition.RagaID);
            ViewBag.TalaID = new SelectList(db.Talas, "ID", "TalaName", composition.TalaID);
            return View(composition);
        }

        // POST: Admin/Compositions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Lyrics,LanguageID,RagaID,TalaID,ComposerID,MovieID,MusicTypeID,AppResourceID,IsActive,AddedBy,AddedDate,ModifiedBy,ModifiedDate")] Composition composition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(composition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppResourceID = new SelectList(db.AppResources, "ID", "AppResource_name", composition.AppResourceID);
            ViewBag.ComposerID = new SelectList(db.Artists, "ID", "ArtistName", composition.ComposerID);
            ViewBag.LanguageID = new SelectList(db.Languages, "ID", "LanguageName", composition.LanguageID);
            ViewBag.MovieID = new SelectList(db.Movies, "ID", "MovieName", composition.MovieID);
            ViewBag.MusicTypeID = new SelectList(db.MusicTypes, "ID", "MusicTypeName", composition.MusicTypeID);
            ViewBag.RagaID = new SelectList(db.Raagas, "ID", "RaagaName", composition.RagaID);
            ViewBag.TalaID = new SelectList(db.Talas, "ID", "TalaName", composition.TalaID);
            return View(composition);
        }

        // GET: Admin/Compositions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Composition composition = db.Compositions.Find(id);
            if (composition == null)
            {
                return HttpNotFound();
            }
            return View(composition);
        }

        // POST: Admin/Compositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Composition composition = db.Compositions.Find(id);
            db.Compositions.Remove(composition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
