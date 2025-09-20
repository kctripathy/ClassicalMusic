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
    public class ArtistsController : Controller
    {
        private IndianClassicalMusicEntities db = new IndianClassicalMusicEntities();

        // GET: Admin/Artists
        public ActionResult Index()
        {
            var artists = db.Artists.Include(a => a.AppResource);
            return View(artists.ToList());
        }

        // GET: Admin/Artists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // GET: Admin/Artists/Create
        public ActionResult Create()
        {
            ViewBag.AppResourceID = new SelectList(db.AppResources, "ID", "AppResource_name");
            return View();
        }

        // POST: Admin/Artists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ArtistName,Biography,Country,AppResourceID,ImageUrl,IsFamous,BirthDeathYear,BriefDesc")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppResourceID = new SelectList(db.AppResources, "ID", "AppResource_name", artist.AppResourceID);
            return View(artist);
        }

        // GET: Admin/Artists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppResourceID = new SelectList(db.AppResources, "ID", "AppResource_name", artist.AppResourceID);
            return View(artist);
        }

        // POST: Admin/Artists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ArtistName,Biography,Country,AppResourceID,ImageUrl,IsFamous,BirthDeathYear,BriefDesc")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppResourceID = new SelectList(db.AppResources, "ID", "AppResource_name", artist.AppResourceID);
            return View(artist);
        }

        // GET: Admin/Artists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Admin/Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
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
