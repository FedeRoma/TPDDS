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
    public class GruposController : Controller
    {
        private TPDDSContext db = new TPDDSContext();

        // GET: /Grupos/
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

            var grupos = db.Grupos.Include(g => g.Creador).Include(i => i.Usuarios).Include(r => r.Recetas).Where(g => g.Creador.DietaId == usuario.DietaId);

            return View(grupos.ToList());
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

            var grupos = db.Grupos.Include(g => g.Creador).Include(i => i.Usuarios).Include(r => r.Recetas).Where(g => g.UsuarioId == usuario.Id);

            List<int> IDs = db.GruposUsuarios.Where(gu => gu.UsuarioId == usuario.Id).Select(gu => gu.GrupoId).ToList<int>();

            var Misgrupos = db.Grupos.Include(g => g.Creador).Include(i => i.Usuarios).Include(r => r.Recetas).Where(x => IDs.Contains(x.Id));           

            ViewBag.MisGrupos = Misgrupos;

            return View(grupos.ToList());
        }

        // GET: /Grupos/Details/5
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
            Grupo grupo = db.Grupos.Find(id);

            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        // GET: /Grupos/Create
        public ActionResult Create()
        {
            string userEmail = User.Identity.GetUserName();

            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Preferencias = db.Preferencias.OrderBy(p => p.Nombre);

            return View();
        }

        // POST: /Grupos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nombre,Eliminado,UsuarioId")] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                db.Grupos.Add(grupo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Preferencias = db.Preferencias.OrderBy(p => p.Nombre);
            return View(grupo);
        }

        // GET: /Grupos/Edit/5
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
            Grupo grupo = db.Grupos.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Preferencias = db.Preferencias.OrderBy(p => p.Nombre);
            return View(grupo);
        }

        // POST: /Grupos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nombre,Eliminado,UsuarioId")] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Preferencias = db.Preferencias.OrderBy(p => p.Nombre);
            return View(grupo);
        }

        // GET: /Grupos/Delete/5
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
            Grupo grupo = db.Grupos.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        // POST: /Grupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grupo grupo = db.Grupos.Find(id);
            grupo.Eliminado = false;

            db.Entry(grupo).State = EntityState.Modified;
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
