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
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                            
                var grupos = db.Grupos.Include(g => g.Creador)
                    .Include(i => i.Usuarios)
                    .Include(r => r.Recetas)
                    .Where(g => !g.Eliminado 
                        && g.Creador.DietaId == usuario.DietaId);

                return View(grupos.ToList());
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: /Grupos/Me
        public ActionResult Me()
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                var grupos = db.Grupos.Include(g => g.Creador)
                    .Include(i => i.Usuarios)
                    .Include(r => r.Recetas)
                    .Where(g => !g.Eliminado
                        && g.UsuarioId == usuario.Id);

                List<int> IDs = db.GruposUsuarios
                    .Where(gu => !gu.Eliminado
                        && !gu.Grupo.Eliminado
                        && gu.UsuarioId == usuario.Id)
                    .Select(gu => gu.GrupoId).ToList<int>();

                var Misgrupos = db.Grupos.Include(g => g.Creador)
                    .Include(i => i.Usuarios)
                    .Include(r => r.Recetas)
                    .Where(x => IDs.Contains(x.Id));

                ViewBag.MisGrupos = Misgrupos;

                return View(grupos.ToList());
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: /Grupos/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
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

                ViewBag.PuedeEditarRecetas = PuedeEditarRecetas(grupo, usuario);

                //Puede unirse si no esta unido y no es el creador.
                ViewBag.PuedeUnirse = (!(bool)ViewBag.PuedeEditarRecetas && grupo.UsuarioId != usuario.Id);

                //Tiene permisos para Editar - Solo el creador
                ViewBag.PuedeEditar = (grupo.UsuarioId == usuario.Id);

                //Tiene permisos para Eliminar - Solo el creador
                ViewBag.PuedeEliminar = (grupo.UsuarioId == usuario.Id);

                return View(grupo);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }

        }

        private bool PuedeEditarRecetas(Grupo grupo, Usuario usuario)
        {
            try
            {
                GrupoUsuario item = db.GruposUsuarios
                    .FirstOrDefault(gu => gu.GrupoId == grupo.Id
                        && !gu.Eliminado
                        && gu.UsuarioId == usuario.Id);

                return (item != null);
            }
            catch (Exception)
            {
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                throw;
            }
        }

        // GET: /Grupos/Create
        public ActionResult Create()
        {
            try
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
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: /Grupos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Grupo grupo)
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                ValidarGrupo(ModelState, grupo);

                if (ModelState.IsValid)
                {

                    //grupo.Creador = usuario;
                    grupo.UsuarioId = usuario.Id;
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
                    Success(string.Format("<b>{0}!!</b> El grupo <b>{1}</b> se creo correctamente.", usuario.Nombre, grupo.Nombre), true);
                    return RedirectToAction("Me");
                }

                ViewBag.Preferencias = db.Preferencias.OrderBy(p => p.Nombre);
                return View(grupo);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }

        }

        private void ValidarGrupo(ModelStateDictionary ModelState, Grupo grupo)
        {
            foreach (var item in ModelState.Keys)
            {
                ModelState[item].Errors.Clear();
            }

            if (string.IsNullOrEmpty(grupo.Nombre))
            {
                ModelState.AddModelError("Nombre", "Ingrese un Nombre.");
            }
            else
            {
                if (grupo.Nombre.Length > 100)
                {
                    ModelState.AddModelError("Nombre", "Supero los 100 caracteres.");
                }
            }

            if (grupo.Preferencias == null)
            {
                ModelState.AddModelError("Preferencias", "Seleccione al menos una Preferencia.");
            }
            else
            {
                if(grupo.Preferencias.Where(p => p.Sel).Count() == 0)
                    ModelState.AddModelError("Preferencias", "Seleccione al menos una Preferencia.");
            }
        }

        // GET: /Grupos/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
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
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: /Grupos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Grupo grupoNew)
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                ValidarGrupo(ModelState, grupoNew);

                if (ModelState.IsValid)
                {
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
                    Success(string.Format("<b>{0}!!</b> El grupo <b>{1}</b> se actualizó correctamente.", usuario.Nombre, grupoToUpdate.Nombre), true);
                    return RedirectToAction("Me");
                }

                return View(grupoNew);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: /Grupos/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
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
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: /Grupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                Grupo grupo = db.Grupos.Find(id);
                grupo.Eliminado = true;
                grupo.FechaBaja = DateTime.Now;
                db.Entry(grupo).State = EntityState.Modified;
                db.SaveChanges();

                //Todo OK
                Success(string.Format("<b>{0}!!</b> El grupo <b>{1}</b> se elimno correctamente.", grupo.Creador.Nombre, grupo.Nombre), true);
                return RedirectToAction("Me");
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
            
        }

        // GET: /Grupos/DeleteReceta/5
        public ActionResult DeleteReceta(int? id)
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

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
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }

        }

        // POST: /Grupos/DeleteReceta/5
        [HttpPost, ActionName("DeleteReceta")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecetaConfirmed(int id)
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                GrupoReceta item = db.GruposRecetas.Find(id);
                item.Eliminada = true;
                item.FechaBaja = DateTime.Now;
                item.UsuarioBajaId = usuario.Id;
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();

                Success(string.Format("<b>{0}!!</b> La Receta se elimino correctamente de su Grupo.", usuario.Nombre), true);
                return RedirectToAction("Me");
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: /Grupos/UnirUsuario
        public ActionResult UnirUsuario(int? id)
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                Grupo grupo = db.Grupos.Find(id);

                if (grupo == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                GrupoUsuario item = new GrupoUsuario();
                item.Grupo = grupo;
                item.GrupoId = grupo.Id;
                item.Usuario = usuario;
                item.UsuarioId = usuario.Id;

                return View(item);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: /Grupos/UnirUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UnirUsuario(GrupoUsuario item)
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                if (ModelState.IsValid)
                {
                    bool booExiste = false;

                    //Valido si existe la Planificacion
                    GrupoUsuario itemOrig = db.GruposUsuarios
                        .FirstOrDefault(gr => gr.GrupoId == item.GrupoId
                            && !(bool)gr.Eliminado
                            && gr.UsuarioId == item.UsuarioId);

                    //Valido si ya fue agregada
                    if (itemOrig == null)
                    {
                        booExiste = false;
                    }
                    else
                    {
                        booExiste = true;
                    }

                    if (booExiste)
                    {
                        //Ya existe
                        Information(string.Format("<b>{0}!!</b> Usted ya pertence al grupo.", usuario.Nombre), true);
                        return RedirectToAction("Me");
                    }
                    else
                    {
                        item.Eliminado = false;

                        //Actualizo BD
                        db.GruposUsuarios.Add(item);
                        db.SaveChanges();

                        //Todo OK
                        Success(string.Format("<b>{0}!!</b> Se unio correctamente al grupo.", usuario.Nombre), true);
                        return RedirectToAction("Me");
                    }
                }

                item.Usuario = usuario;
                item.UsuarioId = usuario.Id;

                return View(item);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: /Grupos/DeleteUsuario/5
        public ActionResult DeleteUsuario(int? id)
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
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

                GrupoUsuario item = db.GruposUsuarios
                    .FirstOrDefault(gu => !gu.Eliminado
                        && gu.GrupoId == grupo.Id
                        && gu.UsuarioId == usuario.Id);

                return View(item);

            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: /Grupos/DeleteUsuario/5
        [HttpPost, ActionName("DeleteUsuario")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUsuarioConfirmed(int id)
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                Grupo grupo = db.Grupos.Find(id);

                if (grupo == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                GrupoUsuario item = db.GruposUsuarios
                    .FirstOrDefault(gu => !gu.Eliminado
                        && gu.GrupoId == grupo.Id
                        && gu.UsuarioId == usuario.Id);

                item.Eliminado = true;
                item.FechaBaja = DateTime.Now;
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();

                Success(string.Format("<b>{0}!!</b> Usted dejo el Grupo.", usuario.Nombre), true);
                return RedirectToAction("Me");
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
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
