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
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TP_DDS.Controllers
{
    public class RecetasController : Controller
    {
        private TPDDSContext db = new TPDDSContext();

        // GET: /Recetas/
        public ActionResult Index()
        {
            string userEmail = User.Identity.GetUserName();

            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Index", "Home");
            }

            Usuario usuario = db.Usuarios.FirstOrDefault
                (u => u.Email.Equals(userEmail));

            if (usuario == null)
            {
                return HttpNotFound();
            }

            var recetas = db.Recetas.Include(r => r.Creador).Include(r => r.Piramide).Where(r => r.Creador.DietaId == usuario.DietaId);

            return View(recetas.ToList());
        }

        // GET: /Grupos/Me
        public ActionResult Me()
        {
            string userEmail = User.Identity.GetUserName();

            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Index", "Home");
            }

            Usuario usuario = db.Usuarios.FirstOrDefault
                (u => u.Email.Equals(userEmail));

            if (usuario == null)
            {
                return HttpNotFound();
            }

            var recetas = db.Recetas.Include(r => r.Creador).Include(r => r.Piramide).Where(r => r.UsuarioId == usuario.Id);

            //List<int> IDs = db.GruposUsuarios.Where(gu => gu.UsuarioId == usuario.Id).Select(gu => gu.GrupoId).ToList<int>();

            //var Misgrupos = db.Grupos.Include(g => g.Creador).Include(i => i.Usuarios).Include(r => r.Recetas).Where(x => IDs.Contains(x.Id));

            //ViewBag.MisGrupos = Misgrupos;

            return View(recetas.ToList());
        }

        // GET: /Recetas/Details/5
        public ActionResult Details(int? id)
        {
            string userEmail = User.Identity.GetUserName();

            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receta receta = db.Recetas.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }

            ViewBag.Temps = receta.Temporadas.Count();

            return View(receta);
        }

        // GET: /Recetas/Create
        public ActionResult Create()
        {
            string userEmail = User.Identity.GetUserName();

            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.PiramideId = new SelectList(db.PiramideAlimenticia, "Id", "NombreGrupo");

            ViewBag.Temporadas = db.Temporadas.OrderBy(p => p.Nombre);
            ViewBag.Clasificaciones = db.Clasificaciones.OrderBy(p => p.Nombre);
            ViewBag.Condimentos = db.Condimentos.OrderBy(p => p.Nombre);
            ViewBag.Ingredientes = db.Ingredientes.OrderBy(p => p.Nombre);

            return View();
        }

        // POST: /Recetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nombre,Dificultad,TotalCalorias,CalificacionPromedio,FechaCreacion,FechaUltModif,PiramideId,UsuarioId")] Receta receta)
        {
            if (ModelState.IsValid)
            {
                db.Recetas.Add(receta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PiramideId = new SelectList(db.PiramideAlimenticia, "Id", "NombreGrupo", receta.PiramideId);

            ViewBag.Temporadas = db.Temporadas.OrderBy(p => p.Nombre);
            ViewBag.Clasificaciones = db.Clasificaciones.OrderBy(p => p.Nombre);
            ViewBag.Condimentos = db.Condimentos.OrderBy(p => p.Nombre);
            ViewBag.Ingredientes = db.Ingredientes.OrderBy(p => p.Nombre);

            return View(receta);
        }

        // GET: /Recetas/Edit/5
        public ActionResult Edit(int? id)
        {
            string userEmail = User.Identity.GetUserName();

            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receta receta = db.Recetas.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }

            ViewBag.PiramideId = new SelectList(db.PiramideAlimenticia, "Id", "NombreGrupo", receta.PiramideId);

            ViewBag.Temporadas = db.Temporadas.OrderBy(p => p.Nombre);
            ViewBag.Clasificaciones = db.Clasificaciones.OrderBy(p => p.Nombre);
            ViewBag.Condimentos = db.Condimentos.OrderBy(p => p.Nombre);
            ViewBag.Ingredientes = db.Ingredientes.OrderBy(p => p.Nombre);

            return View(receta);
        }

        // POST: /Recetas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nombre,Dificultad,TotalCalorias,CalificacionPromedio,FechaCreacion,FechaUltModif,PiramideId,UsuarioId")] Receta receta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PiramideId = new SelectList(db.PiramideAlimenticia, "Id", "NombreGrupo", receta.PiramideId);

            ViewBag.Temporadas = db.Temporadas.OrderBy(p => p.Nombre);
            ViewBag.Clasificaciones = db.Clasificaciones.OrderBy(p => p.Nombre);
            ViewBag.Condimentos = db.Condimentos.OrderBy(p => p.Nombre);
            ViewBag.Ingredientes = db.Ingredientes.OrderBy(p => p.Nombre);

            return View(receta);
        }

        // GET: /Recetas/Delete/5
        public ActionResult Delete(int? id)
        {
            string userEmail = User.Identity.GetUserName();

            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receta receta = db.Recetas.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            return View(receta);
        }

        // POST: /Recetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receta receta = db.Recetas.Find(id);
            receta.Eliminada = false;

            db.Entry(receta).State = EntityState.Modified;
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
