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
    public class RaagasController : Controller
    {
        private IndianClassicalMusicEntities db = new IndianClassicalMusicEntities();

        // GET: Admin/Raagas
        public ActionResult Index()
        {
            var raagas = db.Raagas.Include(r => r.AppResource).Include(r => r.MusicType).Include(r => r.Thaat);
            return View(raagas.ToList());
        }

        // GET: Admin/Raagas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raaga raaga = db.Raagas.Find(id);
            if (raaga == null)
            {
                return HttpNotFound();
            }
            return View(raaga);
        }

        // GET: Admin/Raagas/Create
        public ActionResult Create()
        {
            ViewBag.AppResourceID = new SelectList(db.AppResources, "ID", "AppResource_name");
            ViewBag.MusicTypeID = new SelectList(db.MusicTypes, "ID", "MusicTypeName");
            ViewBag.ThaatID = new SelectList(db.Thaats, "ID", "ThaatName");
            return View();
        }

        // POST: Admin/Raagas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RaagaName,RaagaTime,Mood,Aroh,Avroh,Pakad,Vadi,Samvadi,Swara,ThaatID,MusicTypeID,AppResourceID,RaagaDesc,IsActive,AddedBy,AddedDate,ModifiedBy,ModifiedDate,NyasaSwara,Jati")] Raaga raaga)
        {
            bool isValidated = true;
            var validationResults = db.Entry(raaga).GetValidationResult();
            var fieldValidationResult = ValidateRaaga(raaga);
            List<string> errors = new List<string>();
            if (!validationResults.IsValid)
            {
                var err = validationResults.ValidationErrors.Select(e => e.ErrorMessage).ToList();
                errors.AddRange(err);
                //ViewBag.ValidationErrors = err;
            }
            if (fieldValidationResult.Count > 0)
            {
                errors.AddRange(fieldValidationResult);
            }
            if (errors.Count > 0)
            {
                ViewBag.ValidationErrors = errors;
                isValidated = false;
            }

            if (ModelState.IsValid && isValidated)
            {
                db.Raagas.Add(raaga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppResourceID = new SelectList(db.AppResources, "ID", "AppResource_name", raaga.AppResourceID);
            ViewBag.MusicTypeID = new SelectList(db.MusicTypes, "ID", "MusicTypeName", raaga.MusicTypeID);
            ViewBag.ThaatID = new SelectList(db.Thaats, "ID", "ThaatName", raaga.ThaatID);
            return View(raaga);
        }

        private List<string> ValidateRaaga(Raaga raaga)
        {
            List<string> errors = new List<string>();
            if (string.IsNullOrEmpty(raaga.Aroh))
            {
                errors.Add("Aroh can't be empty");
            }
            if (string.IsNullOrEmpty(raaga.Avroh))
            {
                errors.Add("Avroh can't be empty");
            }
            return errors;
        }

        // GET: Admin/Raagas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raaga raaga = db.Raagas.Find(id);
            if (raaga == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppResourceID = new SelectList(db.AppResources, "ID", "AppResource_name", raaga.AppResourceID);
            ViewBag.MusicTypeID = new SelectList(db.MusicTypes, "ID", "MusicTypeName", raaga.MusicTypeID);
            ViewBag.ThaatID = new SelectList(db.Thaats, "ID", "ThaatName", raaga.ThaatID);
            return View(raaga);
        }

        // POST: Admin/Raagas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RaagaName,RaagaTime,Mood,Aroh,Avroh,Pakad,Vadi,Samvadi,Swara,ThaatID,MusicTypeID,AppResourceID,RaagaDesc,IsActive,AddedBy,AddedDate,ModifiedBy,ModifiedDate,NyasaSwara,Jati")] Raaga raaga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raaga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppResourceID = new SelectList(db.AppResources, "ID", "AppResource_name", raaga.AppResourceID);
            ViewBag.MusicTypeID = new SelectList(db.MusicTypes, "ID", "MusicTypeName", raaga.MusicTypeID);
            ViewBag.ThaatID = new SelectList(db.Thaats, "ID", "ThaatName", raaga.ThaatID);
            return View(raaga);
        }

        // GET: Admin/Raagas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raaga raaga = db.Raagas.Find(id);
            if (raaga == null)
            {
                return HttpNotFound();
            }
            return View(raaga);
        }

        // POST: Admin/Raagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Raaga raaga = db.Raagas.Find(id);
            db.Raagas.Remove(raaga);
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
