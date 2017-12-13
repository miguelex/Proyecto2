using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelos;

namespace Proyecto.Controllers
{
    public class TipoContactoController : Controller
    {
        private DBTFGContext db = new DBTFGContext();

        // GET: TipoContacto
        public ActionResult Index()
        {
            return View(db.TipoContacto.ToList());
        }

        // GET: TipoContacto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContacto tipoContacto = db.TipoContacto.Find(id);
            if (tipoContacto == null)
            {
                return HttpNotFound();
            }
            return View(tipoContacto);
        }

        // GET: TipoContacto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoContactoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] TipoContacto tipoContacto)
        {
            if (ModelState.IsValid)
            {
                db.TipoContacto.Add(tipoContacto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoContacto);
        }

        // GET: TipoContacto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContacto tipoContacto = db.TipoContacto.Find(id);
            if (tipoContacto == null)
            {
                return HttpNotFound();
            }
            return View(tipoContacto);
        }

        // POST: TipoContacto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] TipoContacto tipoContacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoContacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoContacto);
        }

        // GET: TipoContacto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContacto tipoContacto = db.TipoContacto.Find(id);
            if (tipoContacto == null)
            {
                return HttpNotFound();
            }
            return View(tipoContacto);
        }

        // POST: TipoContacto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoContacto tipoContacto = db.TipoContacto.Find(id);
            db.TipoContacto.Remove(tipoContacto);
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
