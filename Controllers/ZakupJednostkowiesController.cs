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
    public class ZakupJednostkowiesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: ZakupJednostkowies
        public ActionResult Index()
        {
            var zakupyJednostkowe = db.ZakupyJednostkowe.Include(z => z.Warzywo).Include(z => z.Zakup);
            return View(zakupyJednostkowe.ToList());
        }

        // GET: ZakupJednostkowies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZakupJednostkowy zakupJednostkowy = db.ZakupyJednostkowe.Find(id);
            if (zakupJednostkowy == null)
            {
                return HttpNotFound();
            }

            ViewBag.NazwaWarzywa = db.Warzywa.Find(zakupJednostkowy.WarzywoId).Nazwa;
            return View(zakupJednostkowy);
        }

        // GET: ZakupJednostkowies/Create
        public ActionResult Create()
        {
            ViewBag.WarzywoId = new SelectList(db.Warzywa, "WarzywoId", "Nazwa");
            ViewBag.ZakupId = new SelectList(db.Zakupy, "ZakupId", "ZakupId");
            return View();
        }

        // POST: ZakupJednostkowies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZakupJednostkowyId,Waga,ZakupId,WarzywoId,Cena")] ZakupJednostkowy zakupJednostkowy)
        {
            if (ModelState.IsValid)
            {
                //checking if there is enough of the vegetables, if not changing to all there is of it
                if (double.Parse(db.Warzywa.Find(zakupJednostkowy.WarzywoId).IloscNaStanie) < double.Parse(zakupJednostkowy.Waga))
                    zakupJednostkowy.Waga = db.Warzywa.Find(zakupJednostkowy.WarzywoId).IloscNaStanie;
                
                //actualizing amound of the vegetables in the shop
                db.Warzywa.Find(zakupJednostkowy.WarzywoId).IloscNaStanie = (double.Parse(db.Warzywa.Find(zakupJednostkowy.WarzywoId).IloscNaStanie) - double.Parse(zakupJednostkowy.Waga)).ToString();

                //counting Cena
                zakupJednostkowy.Cena = double.Parse(zakupJednostkowy.Waga) * (double.Parse(db.Warzywa.Find(zakupJednostkowy.WarzywoId).CenaZaKg));

                db.ZakupyJednostkowe.Add(zakupJednostkowy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WarzywoId = new SelectList(db.Warzywa, "WarzywoId", "Nazwa", zakupJednostkowy.WarzywoId);
            ViewBag.ZakupId = new SelectList(db.Zakupy, "ZakupId", "ZakupId", zakupJednostkowy.ZakupId);
            return View(zakupJednostkowy);
        }

        // GET: ZakupJednostkowies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZakupJednostkowy zakupJednostkowy = db.ZakupyJednostkowe.Find(id);
            if (zakupJednostkowy == null)
            {
                return HttpNotFound();
            }
            ViewBag.WarzywoId = new SelectList(db.Warzywa, "WarzywoId", "Nazwa", zakupJednostkowy.WarzywoId);
            ViewBag.ZakupId = new SelectList(db.Zakupy, "ZakupId", "ZakupId", zakupJednostkowy.ZakupId);
            return View(zakupJednostkowy);
        }

        // POST: ZakupJednostkowies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZakupJednostkowyId,Waga,ZakupId,WarzywoId,Cena")] ZakupJednostkowy zakupJednostkowy)
        {
            if (ModelState.IsValid)
            {
                //counting Cena
                zakupJednostkowy.Cena = double.Parse(zakupJednostkowy.Waga) * (double.Parse(db.Warzywa.Find(zakupJednostkowy.WarzywoId).CenaZaKg));
                db.Entry(zakupJednostkowy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WarzywoId = new SelectList(db.Warzywa, "WarzywoId", "Nazwa", zakupJednostkowy.WarzywoId);
            ViewBag.ZakupId = new SelectList(db.Zakupy, "ZakupId", "ZakupId", zakupJednostkowy.ZakupId);
            return View(zakupJednostkowy);
        }

        // GET: ZakupJednostkowies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZakupJednostkowy zakupJednostkowy = db.ZakupyJednostkowe.Find(id);
            if (zakupJednostkowy == null)
            {
                return HttpNotFound();
            }
            return View(zakupJednostkowy);
        }

        // POST: ZakupJednostkowies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZakupJednostkowy zakupJednostkowy = db.ZakupyJednostkowe.Find(id);
            db.ZakupyJednostkowe.Remove(zakupJednostkowy);
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
