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
    public class FacilitadorController :  BaseController
    {
        private DBTFGContext db = new DBTFGContext();

        // GET: Facilitador
        public ActionResult Index(int? pagina)
        {
            var NumeroPagina = pagina ?? 1;
            var TamañoPagina = 10;
            var lista = db.Facilitador.OrderBy(x => x.id).ToPagedList(NumeroPagina, TamañoPagina);
            return View(lista);
        }

        // GET: Facilitador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facilitador facilitador = db.Facilitador.Find(id);
            if (facilitador == null)
            {
                return HttpNotFound();
            }
            return View(facilitador);
        }

        // GET: Facilitador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Facilitador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] Facilitador facilitador)
        {
            if (ModelState.IsValid)
            {
                db.Facilitador.Add(facilitador);
                db.SaveChanges();
                Success("El facilitador se ha creado correctamente", true);
                return RedirectToAction("Index");
            }
            Danger("El facilitador no se ha creado " , true);
            return View(facilitador);
        }

        // GET: Facilitador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facilitador facilitador = db.Facilitador.Find(id);
            if (facilitador == null)
            {
                return HttpNotFound();
            }
            return View(facilitador);
        }

        // POST: Facilitador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] Facilitador facilitador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facilitador).State = EntityState.Modified;
                db.SaveChanges();
                Success("El facilitador se ha modificado correctamente", true);
                return RedirectToAction("Index");
            }
            Danger("El facilitador no se ha modificado ", true);
            return View(facilitador);
        }

        // GET: Facilitador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facilitador facilitador = db.Facilitador.Find(id);
            if (facilitador == null)
            {
                return HttpNotFound();
            }
            return View(facilitador);
        }

        // POST: Facilitador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Facilitador facilitador = db.Facilitador.Find(id);
            db.Facilitador.Remove(facilitador);
            db.SaveChanges();
            Success("El facilitador se ha borrado correctamente", true);
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
