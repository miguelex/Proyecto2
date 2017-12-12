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
    public class PoblacionController : Controller
    {
        private DBTFGContext db = new DBTFGContext();

        // GET: Poblacions
        public ActionResult Index(int? pagina)
        {
            var NumeroPagina = pagina ?? 1;
            var TamañoPagina = 25;
            var poblacion = db.Poblacion.Include(p => p.Provincia).OrderBy(x => x.id).ToPagedList(NumeroPagina, TamañoPagina);
            return View(poblacion);
        }

        // GET: Poblacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poblacion poblacion = db.Poblacion.Find(id);
            if (poblacion == null)
            {
                return HttpNotFound();
            }
            return View(poblacion);
        }

        // GET: Poblacions/Create
        public ActionResult Create()
        {
            ViewBag.idProvincia = new SelectList(db.Provincia, "id", "NombreProvincia");
            return View();
        }

        // POST: Poblacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,NombrePoblacion,idProvincia")] Poblacion poblacion)
        {
            if (ModelState.IsValid)
            {
                db.Poblacion.Add(poblacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProvincia = new SelectList(db.Provincia, "id", "NombreProvincia", poblacion.idProvincia);
            return View(poblacion);
        }

        // GET: Poblacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poblacion poblacion = db.Poblacion.Find(id);
            if (poblacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProvincia = new SelectList(db.Provincia, "id", "NombreProvincia", poblacion.idProvincia);
            return View(poblacion);
        }

        // POST: Poblacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,NombrePoblacion,idProvincia")] Poblacion poblacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poblacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProvincia = new SelectList(db.Provincia, "id", "NombreProvincia", poblacion.idProvincia);
            return View(poblacion);
        }

        // GET: Poblacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poblacion poblacion = db.Poblacion.Find(id);
            if (poblacion == null)
            {
                return HttpNotFound();
            }
            return View(poblacion);
        }

        // POST: Poblacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poblacion poblacion = db.Poblacion.Find(id);
            db.Poblacion.Remove(poblacion);
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
