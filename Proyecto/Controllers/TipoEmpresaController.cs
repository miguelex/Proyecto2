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
    public class TipoEmpresaController : Controller
    {
        private DBTFGContext db = new DBTFGContext();

        // GET: TipoEmpresa
        public ActionResult Index(int? pagina)
        {
            var NumeroPagina = pagina ?? 1;
            var TamañoPagina = 10;
            var lista = db.TipoEmpresa.OrderBy(x => x.id).ToPagedList(NumeroPagina, TamañoPagina);
            return View(lista);
        }

        // GET: TipoEmpresa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEmpresa tipoEmpresa = db.TipoEmpresa.Find(id);
            if (tipoEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpresa);
        }

        // GET: TipoEmpresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEmpresa/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] TipoEmpresa tipoEmpresa)
        {
            if (ModelState.IsValid)
            {
                db.TipoEmpresa.Add(tipoEmpresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEmpresa);
        }

        // GET: TipoEmpresa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEmpresa tipoEmpresa = db.TipoEmpresa.Find(id);
            if (tipoEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpresa);
        }

        // POST: TipoEmpresa/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] TipoEmpresa tipoEmpresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEmpresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEmpresa);
        }

        // GET: TipoEmpresa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEmpresa tipoEmpresa = db.TipoEmpresa.Find(id);
            if (tipoEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpresa);
        }

        // POST: TipoEmpresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEmpresa tipoEmpresa = db.TipoEmpresa.Find(id);
            db.TipoEmpresa.Remove(tipoEmpresa);
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
