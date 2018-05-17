using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MakeAmazingThings.Models;

namespace MakeAmazingThings.Controllers
{
    public class FotosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Fotos
        public ActionResult Index()
        {
            var fotos = db.Fotos.Include(f => f.Produto);
            return View(fotos.ToList());
        }

        // GET: Fotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fotos fotos = db.Fotos.Find(id);
            if (fotos == null)
            {
                return HttpNotFound();
            }
            return View(fotos);
        }

        // GET: Fotos/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoFK = new SelectList(db.Produtos, "ID", "NomeProd");
            return View();
        }

        // POST: Fotos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ordem,NomeFoto,ProdutoFK")] Fotos fotos)
        {
            if (ModelState.IsValid)
            {
                db.Fotos.Add(fotos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoFK = new SelectList(db.Produtos, "ID", "NomeProd", fotos.ProdutoFK);
            return View(fotos);
        }

        // GET: Fotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fotos fotos = db.Fotos.Find(id);
            if (fotos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoFK = new SelectList(db.Produtos, "ID", "NomeProd", fotos.ProdutoFK);
            return View(fotos);
        }

        // POST: Fotos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ordem,NomeFoto,ProdutoFK")] Fotos fotos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fotos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoFK = new SelectList(db.Produtos, "ID", "NomeProd", fotos.ProdutoFK);
            return View(fotos);
        }

        // GET: Fotos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fotos fotos = db.Fotos.Find(id);
            if (fotos == null)
            {
                return HttpNotFound();
            }
            return View(fotos);
        }

        // POST: Fotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fotos fotos = db.Fotos.Find(id);
            db.Fotos.Remove(fotos);
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
