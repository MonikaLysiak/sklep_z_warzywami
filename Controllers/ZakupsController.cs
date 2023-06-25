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
    public class ZakupsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Zakups
        public ActionResult Index()
        {
            var zakupy = db.Zakupy.Include(z => z.Sprzedawca);
            return View(zakupy.ToList());
        }

        // GET: Zakups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakup zakup = db.Zakupy.Find(id);
            if (zakup == null)
            {
                return HttpNotFound();
            }

            ViewBag.Sprzedawca = db.Sprzedawcy.Find(zakup.SprzedawcaId).Imie;

            List<ZakupJednostkowy> ListaZakupow = db.ZakupyJednostkowe.Where(z => z.ZakupId == id).ToList();

            ViewBag.IloscZakupowJednostkowych = ListaZakupow.Count();

            ViewBag.CenaLaczna = new List<string>();

            ViewBag.NazwyWarzywKolejno = new List<string>();

            ViewBag.CenaZaKgKolejno = new List<string>();

            ViewBag.IloscNaStanieKolejno = new List<string>();


            foreach (ZakupJednostkowy _zakupJednostkowy in ListaZakupow)
            {
                ViewBag.NazwyWarzywKolejno.Add(db.Warzywa.Find(_zakupJednostkowy.WarzywoId).Nazwa);

                ViewBag.CenaLaczna.Add(_zakupJednostkowy.Cena.ToString());

                ViewBag.CenaZaKgKolejno.Add(db.Warzywa.Find(_zakupJednostkowy.WarzywoId).CenaZaKg);

                ViewBag.IloscNaStanieKolejno.Add(db.Warzywa.Find(_zakupJednostkowy.WarzywoId).IloscNaStanie);
            }

            return View(zakup);
        }

        // GET: Zakups/Create
        public ActionResult Create()
        {
            ViewBag.SprzedawcaId = new SelectList(db.Sprzedawcy, "SprzedawcaId", "Imie");
            return View();
        }

        // POST: Zakups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZakupId,SprzedawcaId,Data")] Zakup zakup)
        {
            if (ModelState.IsValid)
            {
                db.Zakupy.Add(zakup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SprzedawcaId = new SelectList(db.Sprzedawcy, "SprzedawcaId", "Imie", zakup.SprzedawcaId);
            return View(zakup);
        }

        // GET: Zakups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakup zakup = db.Zakupy.Find(id);
            if (zakup == null)
            {
                return HttpNotFound();
            }
            ViewBag.SprzedawcaId = new SelectList(db.Sprzedawcy, "SprzedawcaId", "Imie", zakup.SprzedawcaId);
            return View(zakup);
        }

        // POST: Zakups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZakupId,SprzedawcaId,Data")] Zakup zakup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zakup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SprzedawcaId = new SelectList(db.Sprzedawcy, "SprzedawcaId", "Imie", zakup.SprzedawcaId);
            return View(zakup);
        }

        // GET: Zakups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakup zakup = db.Zakupy.Find(id);
            if (zakup == null)
            {
                return HttpNotFound();
            }
            return View(zakup);
        }

        // POST: Zakups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zakup zakup = db.Zakupy.Find(id);
            db.Zakupy.Remove(zakup);
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
