using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using MakeAmazingThings.Models;

namespace MakeAmazingThings.Controllers
{
    public class CompradoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Compradores
        public ActionResult Index()
        {
            return View(db.Compradores.ToList());
        }

        // GET: Compradores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comprador comprador = db.Compradores.Find(id);
            if (comprador == null)
            {
                return HttpNotFound();
            }
            return View(comprador);
        }

        // GET: Compradores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compradores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Morada,Telemovel,CodPostal,NIF")] Comprador comprador)
        {
            if (ModelState.IsValid)
            {
                db.Compradores.Add(comprador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comprador);
        }

        // GET: Compradores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comprador comprador = db.Compradores.Find(id);
            if (comprador == null)
            {
                return HttpNotFound();
            }
            return View(comprador);
        }

        // POST: Compradores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Morada,Telemovel,CodPostal,NIF")] Comprador comprador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comprador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comprador);
        }

        // GET: Compradores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comprador comprador = db.Compradores.Find(id);
            if (comprador == null)
            {
                return HttpNotFound();
            }
            return View(comprador);
        }

        // POST: Compradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comprador comprador = db.Compradores.Find(id);
            db.Compradores.Remove(comprador);
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
