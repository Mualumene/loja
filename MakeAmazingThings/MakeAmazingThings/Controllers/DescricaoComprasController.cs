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
    public class DescricaoComprasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DescricaoCompras
        public ActionResult Index()
        {
            var descricoesCompras = db.DescricoesCompras.Include(d => d.Compra).Include(d => d.Produto);
            return View(descricoesCompras.ToList());
        }

        // GET: DescricaoCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DescricaoCompra descricaoCompra = db.DescricoesCompras.Find(id);
            if (descricaoCompra == null)
            {
                return HttpNotFound();
            }
            return View(descricaoCompra);
        }

        // GET: DescricaoCompras/Create
        public ActionResult Create()
        {
            ViewBag.CompraFk = new SelectList(db.Compras, "NumFatura", "NumFatura");
            ViewBag.ProdutoFk = new SelectList(db.Produtos, "ID", "NomeProd");
            return View();
        }

        // POST: DescricaoCompras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PrecoVenda,Quantidade,IVA,ProdutoFk,CompraFk")] DescricaoCompra descricaoCompra)
        {
            if (ModelState.IsValid)
            {
                db.DescricoesCompras.Add(descricaoCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompraFk = new SelectList(db.Compras, "NumFatura", "NumFatura", descricaoCompra.CompraFk);
            ViewBag.ProdutoFk = new SelectList(db.Produtos, "ID", "NomeProd", descricaoCompra.ProdutoFk);
            return View(descricaoCompra);
        }

        // GET: DescricaoCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DescricaoCompra descricaoCompra = db.DescricoesCompras.Find(id);
            if (descricaoCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompraFk = new SelectList(db.Compras, "NumFatura", "NumFatura", descricaoCompra.CompraFk);
            ViewBag.ProdutoFk = new SelectList(db.Produtos, "ID", "NomeProd", descricaoCompra.ProdutoFk);
            return View(descricaoCompra);
        }

        // POST: DescricaoCompras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PrecoVenda,Quantidade,IVA,ProdutoFk,CompraFk")] DescricaoCompra descricaoCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(descricaoCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompraFk = new SelectList(db.Compras, "NumFatura", "NumFatura", descricaoCompra.CompraFk);
            ViewBag.ProdutoFk = new SelectList(db.Produtos, "ID", "NomeProd", descricaoCompra.ProdutoFk);
            return View(descricaoCompra);
        }

        // GET: DescricaoCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DescricaoCompra descricaoCompra = db.DescricoesCompras.Find(id);
            if (descricaoCompra == null)
            {
                return HttpNotFound();
            }
            return View(descricaoCompra);
        }

        // POST: DescricaoCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DescricaoCompra descricaoCompra = db.DescricoesCompras.Find(id);
            db.DescricoesCompras.Remove(descricaoCompra);
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
