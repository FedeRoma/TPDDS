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
    public class UserController : Controller
    {
        private TPDDSContext db = new TPDDSContext();

        // GET: /User/
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.Complexion).Include(u => u.CondicionPreexistente).Include(u => u.Dieta).Include(u => u.Sexo).Include(u => u.Rutina);
            return View(usuarios.ToList());
        }

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

        // GET: /User/Details/5
        public ActionResult Details()
        {
            string userEmail = User.Identity.GetUserName();

            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Index", "Home");
            }

            Usuario myUser = db.Usuarios.FirstOrDefault
                (u => u.Email.Equals(userEmail));

            if (myUser == null)
            {
                return HttpNotFound();
            }

            Usuario usuario = db.Usuarios.Find(myUser.Id);
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
            ViewBag.SexoId = new SelectList(db.Sexo, "Id", "Nombre");
            ViewBag.RutinaId = new SelectList(db.Rutinas, "Id", "Nombre");

            ViewBag.Preferencias = db.Preferencias.OrderBy(p => p.Nombre);

            //ViewBag.Sexo = new SelectList(new[]
            //                              {
            //                                  new {Sexo="0",Name="Hombre"},
            //                                  new{Sexo="1",Name="Mujer"},
            //                              },
            //                           "Sexo", "Name", 0);

            return View();
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Pass,Email,Nombre,SexoId,FechaNacimiento,Altura,RutinaId,CondicionPreexistenteId,ComplexionId,DietaId,Peso")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.FechaAltaPerfil = DateTime.Now;
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("LogIn", "User");
            }

            ViewBag.ComplexionId = new SelectList(db.Complexiones, "Id", "Nombre");
            ViewBag.CondicionPreexistenteId = new SelectList(db.CondicionesPreexistentes, "Id", "Nombre");
            ViewBag.DietaId = new SelectList(db.Dietas, "Id", "Nombre");
            ViewBag.SexoId = new SelectList(db.Sexo, "Id", "Nombre");
            ViewBag.RutinaId = new SelectList(db.Rutinas, "Id", "Nombre");

            ViewBag.Preferencias = db.Preferencias.OrderBy(p => p.Nombre);

            return View(usuario);
        }

        // GET: /User/Edit/5
        public ActionResult Edit()
        {
            //int? id

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

            ViewBag.ComplexionId = new SelectList(db.Complexiones, "Id", "Nombre", usuario.ComplexionId);
            ViewBag.CondicionPreexistenteId = new SelectList(db.CondicionesPreexistentes, "Id", "Nombre", usuario.CondicionPreexistenteId);
            ViewBag.DietaId = new SelectList(db.Dietas, "Id", "Nombre", usuario.DietaId);
            ViewBag.SexoId = new SelectList(db.Sexo, "Id", "Nombre", usuario.SexoId);
            ViewBag.RutinaId = new SelectList(db.Rutinas, "Id", "Nombre", usuario.RutinaId);

            ViewBag.Preferencias = db.Preferencias.OrderBy(p => p.Nombre);

            return View(usuario);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Pass,Email,Nombre,SexoId,FechaNacimiento,FechaAltaPerfil,Altura,RutinaId,CondicionPreexistenteId,ComplexionId,DietaId,Peso")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ComplexionId = new SelectList(db.Complexiones, "Id", "Nombre");
            ViewBag.CondicionPreexistenteId = new SelectList(db.CondicionesPreexistentes, "Id", "Nombre");
            ViewBag.DietaId = new SelectList(db.Dietas, "Id", "Nombre");
            ViewBag.SexoId = new SelectList(db.Sexo, "Id", "Nombre");
            ViewBag.RutinaId = new SelectList(db.Rutinas, "Id", "Nombre");

            ViewBag.Preferencias = db.Preferencias.OrderBy(p => p.Nombre);

            return View(usuario);
        }

        //// GET: /User/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Usuario usuario = db.Usuarios.Find(id);
        //    if (usuario == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(usuario);
        //}

        //// POST: /User/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Usuario usuario = db.Usuarios.Find(id);
        //    db.Usuarios.Remove(usuario);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
