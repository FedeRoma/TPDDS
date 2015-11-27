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
using System.Text.RegularExpressions;

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
            try
            {
                ValidarUsuarioLogin(ModelState, user);

                if (ModelState.IsValid)
                {
                    Usuario myUser = db.Usuarios.FirstOrDefault
                                    (u => u.Email.Equals(user.Email) && u.Pass.Equals(user.Pass));

                    if (myUser != null)
                    {
                        FormsAuthentication.SetAuthCookie(myUser.Email, false);

                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Sus Email o Contraseña son incorrectos.");
                    }
                }
                return View(user);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        private void ValidarUsuarioLogin(ModelStateDictionary ModelState, LoginViewModel user)
        {
            foreach (var item in ModelState.Keys)
            {
                ModelState[item].Errors.Clear();
            }

            if (!string.IsNullOrEmpty(user.Email))
            {
                string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(emailRegex);
                if (!re.IsMatch(user.Email))
                {
                    ModelState.AddModelError("Email", "Ingre un email valido.");
                }
            }
            else
            {
                ModelState.AddModelError("Email", "Ingrese su Email.");
            }
            if (string.IsNullOrEmpty(user.Pass))
            {
                ModelState.AddModelError("Pass", "Ingrese su Contraseña.");
            }
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
            try
            {
                ViewBag.ComplexionId = new SelectList(db.Complexiones, "Id", "Nombre");
                ViewBag.CondicionPreexistenteId = new SelectList(db.CondicionesPreexistentes, "Id", "Nombre");
                ViewBag.DietaId = new SelectList(db.Dietas, "Id", "Nombre");
                ViewBag.SexoId = new SelectList(db.Sexo, "Id", "Nombre");
                ViewBag.RutinaId = new SelectList(db.Rutinas, "Id", "Nombre");

                Usuario usuario = new Usuario();
                //usuario.FechaNacimiento = new DateTime(1915, 1, 1);
                usuario.Peso = 0;
                usuario.Altura = 0;
                usuario.Preferencias = db.Preferencias.OrderBy(p => p.Nombre).ToList();

                //UsuarioViewModel model = new UsuarioViewModel();
                //model.Usuario = new Usuario();
                //model.Usuario.FechaNacimiento = new DateTime(1915, 1, 1);
                //model.Usuario.Peso = 5;
                //model.Usuario.Altura = 100;

                //model.PreferenciasList = new List<UsuarioPreferenciasViewModel>();

                //UsuarioPreferenciasViewModel product = null;

                //foreach (var item in db.Preferencias.OrderBy(p => p.Nombre))
                //{
                //    product = new UsuarioPreferenciasViewModel();
                //    product.Nombre = item.Nombre;
                //    product.Id = item.Id;
                //    product.Sel = false;

                //    model.PreferenciasList.Add(product);
                //}

                return View(usuario);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: /User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                ValidarUsuario(ModelState, usuario, false);

                if (ModelState.IsValid)
                {
                    //Preferencias
                    var preferencias = usuario.Preferencias.Where(t => t.Sel).ToList();
                    usuario.Preferencias.Clear();
                    Preferencia preferencia;

                    foreach (var item in preferencias)
                    {
                        preferencia = db.Preferencias.Find(item.Id);
                        usuario.Preferencias.Add(preferencia);
                    }

                    usuario.FechaAltaPerfil = DateTime.Now;
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();

                    Success(string.Format("<b>{0}!!</b> Su registro fue exitoso.", usuario.Nombre), true);
                    return RedirectToAction("LogIn", "User");
                }

                ViewBag.ComplexionId = new SelectList(db.Complexiones, "Id", "Nombre");
                ViewBag.CondicionPreexistenteId = new SelectList(db.CondicionesPreexistentes, "Id", "Nombre");
                ViewBag.DietaId = new SelectList(db.Dietas, "Id", "Nombre");
                ViewBag.SexoId = new SelectList(db.Sexo, "Id", "Nombre");
                ViewBag.RutinaId = new SelectList(db.Rutinas, "Id", "Nombre");

                return View(usuario);
            }
            catch (Exception)
            {
                Danger(string.Format("Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias."), true);
                return RedirectToAction("Index", "Home");
            }
        }

        private void ValidarUsuario(ModelStateDictionary ModelState, Usuario usuario, bool IsEdit)
        {
            foreach (var item in ModelState.Keys)
            {
                ModelState[item].Errors.Clear();
            }

            if (!string.IsNullOrEmpty(usuario.Email))
            {
                string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(emailRegex);
                if (!re.IsMatch(usuario.Email))
                {
                    ModelState.AddModelError("Email", "Ingre un email valido.");
                }
                else
                {
                    if (!IsEdit)
                    {
                        Usuario existeUsu = db.Usuarios.FirstOrDefault(u => u.Email.Equals(usuario.Email));

                        if (existeUsu != null)
                            ModelState.AddModelError("Email", "Ya existe un usuario con este mail.");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("Email", "Ingrese su Email.");
            }

            if (string.IsNullOrEmpty(usuario.Nombre))
            {
                ModelState.AddModelError("Nombre", "Ingrese su Nombre.");
            }
            else
            {
                if (usuario.Nombre.Length > 50)
                {
                    ModelState.AddModelError("Nombre", "Supero los 50 caracteres.");
                }
            }

            if (!IsEdit)
            {
                if (string.IsNullOrEmpty(usuario.Pass))
                {
                    ModelState.AddModelError("Pass", "Ingrese su Contraseña.");
                }
                else
                {
                    if (string.IsNullOrEmpty(usuario.ConfirmPass))
                    {
                        ModelState.AddModelError("ConfirmPass", "Confirme su Contraseña.");
                    }
                    else
                    {
                        if (usuario.Pass != usuario.ConfirmPass)
                        {
                            ModelState.AddModelError("Pass", "Las contraseñas no coinciden.");
                            usuario.Pass = "";
                            usuario.ConfirmPass = "";
                        }
                    }
                }
            }

            if (usuario.SexoId == 0)
            {
                ModelState.AddModelError("SexoId", "Seleccione su Sexo.");
            }

            DateTime hoy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

            if (usuario.FechaNacimiento == null || usuario.FechaNacimiento == DateTime.MinValue)
            {
                ModelState.AddModelError("FechaNacimiento", "Ingrese su Nacimiento");
            }
            else
            {
                if (hoy.Year - usuario.FechaNacimiento.Year < 16)
                {
                    ModelState.AddModelError("FechaNacimiento", "Ustede debe ser mayor de 15 años.");
                }
            }

            if (usuario.Peso == 0 || !(usuario.Peso >= 20 && usuario.Peso <= 250))
            {
                ModelState.AddModelError("Peso", "Ingrese un valor entre 20 y 250.");
            }

            if (usuario.Altura == 0 || !(usuario.Altura >= 100 && usuario.Altura <= 250))
            {
                ModelState.AddModelError("Altura", "Ingrese un valor entre 100 y 250.");
            }

            if (usuario.RutinaId == 0)
            {
                ModelState.AddModelError("RutinaId", "Seleccione su Rutina.");
            }

            if (usuario.DietaId == 0)
            {
                ModelState.AddModelError("DietaId", "Seleccione su Dieta.");
            }

            if (usuario.CondicionPreexistenteId == 0)
            {
                ModelState.AddModelError("CondicionPreexistenteId", "Seleccione su Condicion.");
            }

            if (usuario.ComplexionId == 0)
            {
                ModelState.AddModelError("ComplexionId", "Seleccione su Complexion.");
            }

            if (usuario.Preferencias == null)
            {
                ModelState.AddModelError("Preferencias", "Seleccione al menos una Preferencia.");
            }
            else
            {
                if (usuario.Preferencias.Where(p => p.Sel).Count() == 0)
                    ModelState.AddModelError("Preferencias", "Seleccione al menos una Preferencia.");
            }
        }

        // GET: /User/Edit/5
        public ActionResult Edit()
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                var preferencias = usuario.Preferencias.ToList();
                usuario.Preferencias.Clear();
                Preferencia preferencia;

                foreach (var item in db.Preferencias.OrderBy(p => p.Nombre))
                {
                    preferencia = new Preferencia();
                    preferencia.Nombre = item.Nombre;
                    preferencia.Id = item.Id;
                    preferencia.Sel = false;

                    if (preferencias.FirstOrDefault(u => u.Id.Equals(item.Id)) != null)
                        preferencia.Sel = true;

                    usuario.Preferencias.Add(preferencia);
                }

                //UsuarioViewModel model = new UsuarioViewModel();
                //model.Usuario = new Usuario();
                //model.Usuario = usuario;

                //model.PreferenciasList = new List<UsuarioPreferenciasViewModel>();

                //UsuarioPreferenciasViewModel prefer = null;

                //foreach (var item in db.Preferencias.OrderBy(p => p.Nombre))
                //{
                //    prefer = new UsuarioPreferenciasViewModel();
                //    prefer.Nombre = item.Nombre;
                //    prefer.Id = item.Id;
                //    prefer.Sel = false;

                //    if (usuario.Preferencias.FirstOrDefault(u => u.Id.Equals(item.Id)) != null)
                //        prefer.Sel = true;

                //    model.PreferenciasList.Add(prefer);
                //}

                ViewBag.Complexion = new SelectList(db.Complexiones, "Id", "Nombre");
                ViewBag.CondicionPreexistente = new SelectList(db.CondicionesPreexistentes, "Id", "Nombre");
                ViewBag.Dieta = new SelectList(db.Dietas, "Id", "Nombre");
                ViewBag.Sexo = new SelectList(db.Sexo, "Id", "Nombre");
                ViewBag.Rutina = new SelectList(db.Rutinas, "Id", "Nombre");

                return View(usuario);

            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: /User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuarioNew)
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                ValidarUsuario(ModelState, usuarioNew, true);

                if (ModelState.IsValid)
                {
                    //Usuario antes de modificar
                    var usuarioToUpdate = db.Usuarios
                       .Include(i => i.Preferencias)
                       .Where(i => i.Id == usuarioNew.Id)
                       .Single();

                    //Actualizo datos Encabezado
                    usuarioToUpdate.Nombre = usuarioNew.Nombre;
                    usuarioToUpdate.Peso = usuarioNew.Peso;
                    usuarioToUpdate.Altura = usuarioNew.Altura;
                    usuarioToUpdate.RutinaId = usuarioNew.RutinaId;
                    usuarioToUpdate.DietaId = usuarioNew.DietaId;
                    usuarioToUpdate.CondicionPreexistenteId = usuarioNew.CondicionPreexistenteId;
                    usuarioToUpdate.ComplexionId = usuarioNew.ComplexionId;

                    //Preferencias
                    usuarioToUpdate.Preferencias.ToList().ForEach(p => usuarioToUpdate.Preferencias.Remove(p));
                    var preferencias = usuarioNew.Preferencias.Where(p => p.Sel).ToList();
                    Preferencia preferencia;

                    foreach (var item in preferencias)
                    {
                        preferencia = db.Preferencias.Find(item.Id);
                        usuarioToUpdate.Preferencias.Add(preferencia);
                    }

                    db.SaveChanges();

                    Success(string.Format("<b>{0}!!</b> Su perfil fue actualizado correctamente.", usuarioToUpdate.Nombre), true);

                    return RedirectToAction("Index", "Home");
                }

                ViewBag.Complexion = new SelectList(db.Complexiones, "Id", "Nombre");
                ViewBag.CondicionPreexistente = new SelectList(db.CondicionesPreexistentes, "Id", "Nombre");
                ViewBag.Dieta = new SelectList(db.Dietas, "Id", "Nombre");
                ViewBag.Sexo = new SelectList(db.Sexo, "Id", "Nombre");
                ViewBag.Rutina = new SelectList(db.Rutinas, "Id", "Nombre");

                return View(usuarioNew);
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
