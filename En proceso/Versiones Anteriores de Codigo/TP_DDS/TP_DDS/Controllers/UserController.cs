using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TP_DDS.Models;
using TP_DDS.DAL;

namespace TP_DDS.Controllers
{
    public class UserController : Controller
    {
        private TPDDSContext db = new TPDDSContext();

        // GET: /User/
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.Complexion).Include(u => u.CondicionPreexistente).Include(u => u.Dieta);
            return View(usuarios.ToList());
        }

        // GET: /User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            ViewBag.ComplexionId = new SelectList(db.Complexiones, "Id", "Nombre");
            ViewBag.CondicionPreexistenteId = new SelectList(db.CondicionesPreexistentes, "Id", "Nombre");
            ViewBag.DietaId = new SelectList(db.Dietas, "Id", "Nombre");
            ViewBag.Sexo = new SelectList(new[]
                                          {
                                              new {Sexo="0",Name="Hombre"},
                                              new{Sexo="1",Name="Mujer"},
                                          },
                                       "Sexo", "Name", 0);
            return View();
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,UserName,Pass,Email,Nombre,Sexo,FechaNacimiento,Altura,Rutina,CondicionPreexistenteId,ComplexionId,DietaId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.FechaAltaPerfil = DateTime.Now;
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComplexionId = new SelectList(db.Complexiones, "Id", "Nombre", usuario.ComplexionId);
            ViewBag.CondicionPreexistenteId = new SelectList(db.CondicionesPreexistentes, "Id", "Nombre", usuario.CondicionPreexistenteId);
            ViewBag.DietaId = new SelectList(db.Dietas, "Id", "Nombre", usuario.DietaId);
            ViewBag.Sexo = new SelectList(new[]
                                          {
                                              new {Sexo="0",Name="Hombre"},
                                              new{Sexo="1",Name="Mujer"},
                                          },
                                       "Sexo", "Name", 0);
            return View(usuario);
        }

        // GET: /User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComplexionId = new SelectList(db.Complexiones, "Id", "Nombre", usuario.ComplexionId);
            ViewBag.CondicionPreexistenteId = new SelectList(db.CondicionesPreexistentes, "Id", "Nombre", usuario.CondicionPreexistenteId);
            ViewBag.DietaId = new SelectList(db.Dietas, "Id", "Nombre", usuario.DietaId);
            ViewBag.Sexo = new SelectList(new[]
                                          {
                                              new {Sexo="0",Name="Hombre"},
                                              new{Sexo="1",Name="Mujer"},
                                          },
                                       "Sexo", "Name", 0);
            return View(usuario);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,UserName,Pass,Email,Nombre,Sexo,FechaNacimiento,Altura,Rutina,CondicionPreexistenteId,ComplexionId,DietaId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                usuario.FechaAltaPerfil = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComplexionId = new SelectList(db.Complexiones, "Id", "Nombre", usuario.ComplexionId);
            ViewBag.CondicionPreexistenteId = new SelectList(db.CondicionesPreexistentes, "Id", "Nombre", usuario.CondicionPreexistenteId);
            ViewBag.DietaId = new SelectList(db.Dietas, "Id", "Nombre", usuario.DietaId);
            ViewBag.Sexo = new SelectList(new[]
                                          {
                                              new {Sexo="0",Name="Hombre"},
                                              new{Sexo="1",Name="Mujer"},
                                          },
                                       "Sexo", "Name", 0);
            return View(usuario);
        }

        // GET: /User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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
