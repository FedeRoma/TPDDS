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
    public class GruposController : BaseController
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
                return RedirectToAction("Index", "Home");
            }

            var grupos = db.Grupos.Include(g => g.Creador)
                .Include(i => i.Usuarios).
                Include(r => r.Recetas).
                Where(g => !g.Eliminado 
                    && g.Creador.DietaId == usuario.DietaId);

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

            var grupos = db.Grupos.Include(g => g.Creador)
                .Include(i => i.Usuarios)
                .Include(r => r.Recetas)
                .Where(g => !g.Eliminado && g.UsuarioId == usuario.Id);

            List<int> IDs = db.GruposUsuarios
                .Where(gu => !gu.Grupo.Eliminado && gu.UsuarioId == usuario.Id)
                .Select(gu => gu.GrupoId).ToList<int>();

            var Misgrupos = db.Grupos.Include(g => g.Creador)
                .Include(i => i.Usuarios)
                .Include(r => r.Recetas)
                .Where(x => IDs.Contains(x.Id));

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

            Usuario usuario = db.Usuarios.FirstOrDefault
                (u => u.Email.Equals(userEmail));

            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Grupo grupo = db.Grupos.Find(id);

            if (grupo == null)
            {
                return RedirectToAction("Index", "Home");
            }

            GrupoUsuario item = db.GruposUsuarios
                .FirstOrDefault(gu => gu.GrupoId == grupo.Id 
                    && gu.UsuarioId == usuario.Id);

            ViewBag.PuedeEditarRecetas = true;

            if (item != null)
                ViewBag.PuedeEditarRecetas = false;

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

            Grupo oGrupo = new Grupo();
            oGrupo.Preferencias = db.Preferencias.OrderBy(p => p.Nombre).ToList();

            return View(oGrupo);
        }

        // POST: /Grupos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                string userEmail = User.Identity.GetUserName();

                if (string.IsNullOrEmpty(userEmail))
                {
                    return RedirectToAction("Index", "Home");
                }

                //Usuario Creador = Logueado
                Usuario usuario = db.Usuarios.FirstOrDefault
                    (u => u.Email.Equals(userEmail));

                grupo.Creador = usuario;
                grupo.FechaCreacion = DateTime.Now;
                grupo.FechaUltModif = grupo.FechaCreacion;

                //Preferencias
                var preferencias = grupo.Preferencias.Where(t => t.Sel).ToList();
                grupo.Preferencias.Clear();
                Preferencia preferencia;

                foreach (var item in preferencias)
                {
                    preferencia = db.Preferencias.Find(item.Id);
                    grupo.Preferencias.Add(preferencia);
                }

                //Creacion
                db.Grupos.Add(grupo);
                db.SaveChanges();

                //Todo OK
                Success(string.Format("<b>{0}!!</b> El grupo <b>{1}</b> se creo correctamente.", grupo.Creador.Nombre, grupo.Nombre), true);
                return RedirectToAction("Me");
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
                return RedirectToAction("Index", "Home");
            }

            Grupo grupo = db.Grupos.Find(id);

            if (grupo == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var preferencias = grupo.Preferencias.ToList();
            grupo.Preferencias.Clear();
            Preferencia preferencia;

            foreach (var item in db.Preferencias.OrderBy(p => p.Nombre))
            {
                preferencia = new Preferencia();
                preferencia.Nombre = item.Nombre;
                preferencia.Id = item.Id;
                preferencia.Sel = false;

                if (preferencias.FirstOrDefault(u => u.Id.Equals(item.Id)) != null)
                    preferencia.Sel = true;

                grupo.Preferencias.Add(preferencia);
            }

            return View(grupo);
        }

        // POST: /Grupos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Grupo grupoNew)
        {
            if (ModelState.IsValid)
            {
                string userEmail = User.Identity.GetUserName();

                if (string.IsNullOrEmpty(userEmail))
                {
                    return RedirectToAction("Index", "Home");
                }

                //Usuario Logueado
                Usuario usuario = db.Usuarios.FirstOrDefault
                    (u => u.Email.Equals(userEmail));

                //Grupo antes de modificar
                var grupoToUpdate = db.Grupos
                   .Include(g => g.Creador)
                   .Where(g => g.Id == grupoNew.Id)
                   .Single();

                //Actualizo datos Encabezado
                grupoToUpdate.FechaUltModif = DateTime.Now;
                grupoToUpdate.Nombre = grupoNew.Nombre;

                //Preferencias
                grupoToUpdate.Preferencias.ToList().ForEach(p => grupoToUpdate.Preferencias.Remove(p));
                var preferencias = grupoNew.Preferencias.Where(p => p.Sel).ToList();
                Preferencia preferencia;

                foreach (var item in preferencias)
                {
                    preferencia = db.Preferencias.Find(item.Id);
                    grupoToUpdate.Preferencias.Add(preferencia);
                }

                //Actualizo DB
                db.SaveChanges();

                //Todo OK
                Success(string.Format("<b>{0}!!</b> El grupo <b>{1}</b> se actualizó correctamente.", grupoToUpdate.Creador.Nombre, grupoToUpdate.Nombre), true);
                return RedirectToAction("Me");
            }

            
            return View(grupoNew);
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
                return RedirectToAction("Index", "Home");
            }
            Grupo grupo = db.Grupos.Find(id);
            if (grupo == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(grupo);
        }

        // POST: /Grupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grupo grupo = db.Grupos.Find(id);
            grupo.Eliminado = true;
            db.Entry(grupo).State = EntityState.Modified;
            db.SaveChanges();
            //Todo OK
            Success(string.Format("<b>{0}!!</b> El grupo <b>{1}</b> se elimno correctamente.", grupo.Creador.Nombre, grupo.Nombre), true);
            return RedirectToAction("Me");
        }

        // GET: /Grupos/DeleteReceta/5
        public ActionResult DeleteReceta(int? id)
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
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            GrupoReceta item = db.GruposRecetas.Find(id);

            if (item == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(item);
        }

        // POST: /Grupos/DeleteReceta/5
        [HttpPost, ActionName("DeleteReceta")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecetaConfirmed(int id)
        {
            string userEmail = User.Identity.GetUserName();

            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Index", "Home");
            }

            //Usuario Logueado
            Usuario usuario = db.Usuarios.FirstOrDefault
                (u => u.Email.Equals(userEmail));

            GrupoReceta item = db.GruposRecetas.Find(id);
            item.Eliminada = true;
            item.UsuarioBajaId = usuario.Id;
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            Success(string.Format("<b>{0}!!</b> La Receta se elimino correctamente de su Grupo.", usuario.Nombre), true);
            return RedirectToAction("Me");
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
