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
    public class PropietarioController : BaseController
    {
        private DBTFGContext db = new DBTFGContext();

        // GET: Propietario
        public ActionResult Index(int? pagina)
        {
            var NumeroPagina = pagina ?? 1;
            var TamañoPagina = 10;
            var lista = db.Propietario.OrderBy(x => x.id).ToPagedList(NumeroPagina, TamañoPagina);
            return View(lista);
        }

        // GET: Propietario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propietario propietario = db.Propietario.Find(id);
            if (propietario == null)
            {
                return HttpNotFound();
            }
            return View(propietario);
        }

        // GET: Propietario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Propietario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nick,nombre,apellidos,clave,email,direccion,telefono,bloqueado,activado,reseteado")] Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                db.Propietario.Add(propietario);
                db.SaveChanges();
                Success("Nuevo propietario añadido correctamente", true);
                return RedirectToAction("Index");
            }
            Danger("El nuevo propietario no se ha añadido ", true);
            return View(propietario);
        }

        // GET: Propietario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propietario propietario = db.Propietario.Find(id);
            if (propietario == null)
            {
                return HttpNotFound();
            }
            return View(propietario);
        }

        // POST: Propietario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nick,nombre,apellidos,clave,email,direccion,telefono,bloqueado,activado,reseteado")] Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propietario).State = EntityState.Modified;
                db.SaveChanges();
                Success("El propietario se ha modificado correctamente", true);
                return RedirectToAction("Index");
            }
            Danger("El propietario no se ha modificado ", true);
            return View(propietario);
        }

        // GET: Propietario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propietario propietario = db.Propietario.Find(id);
            if (propietario == null)
            {
                return HttpNotFound();
            }
            return View(propietario);
        }

        // POST: Propietario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Propietario propietario = db.Propietario.Find(id);
            db.Propietario.Remove(propietario);
            db.SaveChanges();
            Success("El propietario se ha borrado correctamente", true);
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
