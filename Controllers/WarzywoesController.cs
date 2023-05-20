using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SklepZWarzywami.Models;

namespace SklepZWarzywami.Controllers
{
    public class WarzywoesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Warzywoes
        public ActionResult Index()
        {
            return View(db.Warzywa.ToList());
        }

        // GET: Warzywoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warzywo warzywo = db.Warzywa.Find(id);
            if (warzywo == null)
            {
                return HttpNotFound();
            }
            return View(warzywo);
        }

        // GET: Warzywoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warzywoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WarzywoId,Nazwa,CenaZaKg,IloscNaStanie")] Warzywo warzywo)
        {
            if (ModelState.IsValid)
            {
                db.Warzywa.Add(warzywo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(warzywo);
        }

        // GET: Warzywoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warzywo warzywo = db.Warzywa.Find(id);
            if (warzywo == null)
            {
                return HttpNotFound();
            }
            return View(warzywo);
        }

        // POST: Warzywoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WarzywoId,Nazwa,CenaZaKg,IloscNaStanie")] Warzywo warzywo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warzywo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warzywo);
        }

        // GET: Warzywoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warzywo warzywo = db.Warzywa.Find(id);
            if (warzywo == null)
            {
                return HttpNotFound();
            }
            return View(warzywo);
        }

        // POST: Warzywoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Warzywo warzywo = db.Warzywa.Find(id);
            db.Warzywa.Remove(warzywo);
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
