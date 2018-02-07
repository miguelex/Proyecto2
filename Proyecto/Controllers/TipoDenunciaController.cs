using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelos;
using PagedList;

namespace Proyecto.Controllers
{
    public class TipoDenunciaController : Controller
    {
        private DBTFGContext db = new DBTFGContext();

        // GET: TipoDenuncia
        public ActionResult Index(int? pagina)
        {
            var NumeroPagina = pagina ?? 1;
            var TamañoPagina = 10;
            var lista = db.TipoDenuncia.OrderBy(x => x.id).ToPagedList(NumeroPagina, TamañoPagina);
            return View(lista);
        }

        // GET: TipoDenuncia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDenuncia tipoDenuncia = db.TipoDenuncia.Find(id);
            if (tipoDenuncia == null)
            {
                return HttpNotFound();
            }
            return View(tipoDenuncia);
        }

        // GET: TipoDenuncia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDenuncia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] TipoDenuncia tipoDenuncia)
        {
            if (ModelState.IsValid)
            {
                db.TipoDenuncia.Add(tipoDenuncia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDenuncia);
        }

        // GET: TipoDenuncia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDenuncia tipoDenuncia = db.TipoDenuncia.Find(id);
            if (tipoDenuncia == null)
            {
                return HttpNotFound();
            }
            return View(tipoDenuncia);
        }

        // POST: TipoDenuncia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] TipoDenuncia tipoDenuncia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDenuncia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDenuncia);
        }

        // GET: TipoDenuncia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDenuncia tipoDenuncia = db.TipoDenuncia.Find(id);
            if (tipoDenuncia == null)
            {
                return HttpNotFound();
            }
            return View(tipoDenuncia);
        }

        // POST: TipoDenuncia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDenuncia tipoDenuncia = db.TipoDenuncia.Find(id);
            db.TipoDenuncia.Remove(tipoDenuncia);
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
