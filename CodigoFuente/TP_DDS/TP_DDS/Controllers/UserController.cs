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
    public class UserController : BaseController
    {
        private TPDDSContext db = new TPDDSContext();

        // GET: /User/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: /User/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel user, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                 Usuario myUser = db.Usuarios.FirstOrDefault
                                 (u => u.Email.Equals(user.Email) && u.Pass.Equals(user.Pass));

                if (myUser != null) 
                {
                    FormsAuthentication.SetAuthCookie(myUser.Email, false);

                    if(!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)){
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sus datos son incorrectos.");
                }
            }
            return View(user);
        }

        // GET: /User/LogOff
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            string userEmail = User.Identity.GetUserName();

            if (!string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ComplexionId = new SelectList(db.Complexiones, "Id", "Nombre");
            ViewBag.CondicionPreexistenteId = new SelectList(db.CondicionesPreexistentes, "Id", "Nombre");
            ViewBag.DietaId = new SelectList(db.Dietas, "Id", "Nombre");
            ViewBag.SexoId = new SelectList(db.Sexo, "Id", "Nombre");
            ViewBag.RutinaId = new SelectList(db.Rutinas, "Id", "Nombre");

            UsuarioViewModel model = new UsuarioViewModel();
            model.Usuario = new Usuario();
            model.Usuario.FechaNacimiento = new DateTime(1915, 1, 1);
            model.Usuario.Peso = 5;
            model.Usuario.Altura = 100;

            model.PreferenciasList = new List<UsuarioPreferenciasViewModel>();

            UsuarioPreferenciasViewModel product = null;

            foreach (var item in db.Preferencias.OrderBy(p => p.Nombre))
            {
                product = new UsuarioPreferenciasViewModel();
                product.Nombre = item.Nombre;
                product.Id = item.Id;
                product.Sel = false;

                model.PreferenciasList.Add(product);
            }

            return View(model);
        }

        // POST: /User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var selectedList = model.PreferenciasList.Where(t => t.Sel);

                model.Usuario.Preferencias = new List<Preferencia>();

                foreach (var item in selectedList)
                {
                    if (item.Sel)
                        model.Usuario.Preferencias.Add(db.Preferencias.Find(item.Id));
                }

                model.Usuario.FechaAltaPerfil = DateTime.Now;
                db.Usuarios.Add(model.Usuario);
                db.SaveChanges();

                Success(string.Format("<b>{0}!!</b> Su registro fue exitoso.", model.Usuario.Nombre), true);

                return RedirectToAction("LogIn", "User");
            }

            ViewBag.ComplexionId = new SelectList(db.Complexiones, "Id", "Nombre");
            ViewBag.CondicionPreexistenteId = new SelectList(db.CondicionesPreexistentes, "Id", "Nombre");
            ViewBag.DietaId = new SelectList(db.Dietas, "Id", "Nombre");
            ViewBag.SexoId = new SelectList(db.Sexo, "Id", "Nombre");
            ViewBag.RutinaId = new SelectList(db.Rutinas, "Id", "Nombre");

            return View(model);
        }

        // GET: /User/Edit/5
        public ActionResult Edit()
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

            UsuarioViewModel model = new UsuarioViewModel();
            model.Usuario = new Usuario();
            model.Usuario = usuario;

            model.PreferenciasList = new List<UsuarioPreferenciasViewModel>();

            UsuarioPreferenciasViewModel prefer = null;

            foreach (var item in db.Preferencias.OrderBy(p => p.Nombre))
            {
                prefer = new UsuarioPreferenciasViewModel();
                prefer.Nombre = item.Nombre;
                prefer.Id = item.Id;
                prefer.Sel = false;

                if(usuario.Preferencias.FirstOrDefault(u => u.Id.Equals(item.Id)) != null)
                    prefer.Sel = true;

                model.PreferenciasList.Add(prefer);
            }

            ViewBag.ComplexionId = new SelectList(db.Complexiones, "Id", "Nombre", usuario.ComplexionId);
            ViewBag.CondicionPreexistenteId = new SelectList(db.CondicionesPreexistentes, "Id", "Nombre", usuario.CondicionPreexistenteId);
            ViewBag.DietaId = new SelectList(db.Dietas, "Id", "Nombre", usuario.DietaId);
            ViewBag.SexoId = new SelectList(db.Sexo, "Id", "Nombre", usuario.SexoId);
            ViewBag.RutinaId = new SelectList(db.Rutinas, "Id", "Nombre", usuario.RutinaId);

            return View(model);
        }

        // POST: /User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Usuario logueado
                string userEmail = User.Identity.GetUserName();

                //Usuario antes de modificar
                var usuarioToUpdate = db.Usuarios
                   .Include(i => i.Preferencias)
                   .Where(i => i.Email == userEmail)
                   .Single();

                ActualizaDatosUsuario(model, usuarioToUpdate);

                db.SaveChanges();

                Success(string.Format("<b>{0}!!</b> Su perfil fue actualizado correctamente.", usuarioToUpdate.Nombre), true);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.ComplexionId = new SelectList(db.Complexiones, "Id", "Nombre");
            ViewBag.CondicionPreexistenteId = new SelectList(db.CondicionesPreexistentes, "Id", "Nombre");
            ViewBag.DietaId = new SelectList(db.Dietas, "Id", "Nombre");
            ViewBag.SexoId = new SelectList(db.Sexo, "Id", "Nombre");
            ViewBag.RutinaId = new SelectList(db.Rutinas, "Id", "Nombre");

            return View(model);
        }

        private void ActualizaDatosUsuario(UsuarioViewModel model, Usuario usuarioToUpdate)
        {
            //preferencias antes de modificar
            model.Usuario.Preferencias = usuarioToUpdate.Preferencias;

            //actualizco con los datos de la vista
            usuarioToUpdate = model.Usuario;

            //actualizo preferencias
            var selectedList = new HashSet<int>(model.PreferenciasList.Where(t => t.Sel).Select(c => c.Id));
            var usuarioPreferencias = new HashSet<int>(usuarioToUpdate.Preferencias.Select(c => c.Id));

            foreach (var item in db.Preferencias)
            {
                if (selectedList.Contains(item.Id))
                {
                    if (!usuarioPreferencias.Contains(item.Id))
                    {
                        usuarioToUpdate.Preferencias.Add(item);
                    }
                }
                else
                {
                    if (usuarioPreferencias.Contains(item.Id))
                    {
                        usuarioToUpdate.Preferencias.Remove(item);
                    }
                }
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
