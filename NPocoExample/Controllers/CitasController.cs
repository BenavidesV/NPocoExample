using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NPocoExample.Models;
using NPoco;

namespace NPocoExample.Controllers
{
    public class CitasController : Controller
    {
        private IDatabase db = new NPoco.Database("DefaultConnection");
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Citas
        public ActionResult Index()
        {
            return View(db.Fetch<Cita>("select* from citas"));
        }

        // GET: Citas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.SingleById<Cita>(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            List<Doctor> doctores = db.Fetch<Doctor>("select * from doctors");
            List<Paciente> pacientes = db.Fetch<Paciente>("select * from pacientes");
            ViewBag.Doctores = doctores;
            ViewBag.Pacientes= pacientes;
            return View();
        }

        // POST: Citas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Hora,Lugar,Doctor_Id,Paciente_Id")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Insert(cita);
                return RedirectToAction("Index");
            }

            return View(cita);
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Doctor> doctores = db.Fetch<Doctor>("select * from doctors");
            List<Paciente> pacientes = db.Fetch<Paciente>("select * from pacientes");
            ViewBag.Doctores = doctores;
            ViewBag.Pacientes = pacientes;
            Cita cita = db.SingleById<Cita>(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: Citas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Hora,Lugar,Doctor_Id,Paciente_Id")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Update(cita);
                return RedirectToAction("Index");
            }
            return View(cita);
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.SingleById<Cita>(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cita cita = db.SingleById<Cita>(id);
            db.Delete(cita);
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
