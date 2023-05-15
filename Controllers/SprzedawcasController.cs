using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SklepZWarzywami.Models;
using SklepZWarzywami.Models.DbModels;

namespace SklepZWarzywami.Controllers
{
    public class SprzedawcasController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Sprzedawcas
        public ActionResult Index()
        {
            return View(db.Sprzedawcy.ToList());
        }

        // GET: Sprzedawcas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sprzedawca sprzedawca = db.Sprzedawcy.Find(id);
            if (sprzedawca == null)
            {
                return HttpNotFound();
            }
            return View(sprzedawca);
        }

        // GET: Sprzedawcas/Create
        [HttpGet] //nie jest konieczne 
        public ActionResult Create()  
        {
            return View(); 
            //return View(new Sprzedawca());
        }

        // POST: Sprzedawcas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SprzedawcaId,Imie,Nazwisko,ZakupId")] Sprzedawca sprzedawca)
        {
            if (!ModelState.IsValid)
                return View(sprzedawca);

            db.Sprzedawcy.Add(sprzedawca);
            db.SaveChanges();
            return RedirectToAction("Index");

            //if (ModelState.IsValid)
            //{
            //    db.Sprzedawcy.Add(sprzedawca);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(sprzedawca);
        }

        // GET: Sprzedawcas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sprzedawca sprzedawca = db.Sprzedawcy.Find(id);
            if (sprzedawca == null)
            {
                return HttpNotFound();
            }
            return View(sprzedawca);
        }

        // POST: Sprzedawcas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SprzedawcaId,Imie,Nazwisko,ZakupId")] Sprzedawca sprzedawca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sprzedawca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sprzedawca);
        }

        // GET: Sprzedawcas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sprzedawca sprzedawca = db.Sprzedawcy.Find(id);
            if (sprzedawca == null)
            {
                return HttpNotFound();
            }
            return View(sprzedawca);
        }

        // POST: Sprzedawcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sprzedawca sprzedawca = db.Sprzedawcy.Find(id);
            db.Sprzedawcy.Remove(sprzedawca);
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
