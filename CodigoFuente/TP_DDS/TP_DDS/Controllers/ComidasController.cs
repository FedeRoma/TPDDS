using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TP_DDS.ViewModels;
using TP_DDS.Models;
using TP_DDS.DAL;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TP_DDS.Controllers
{
    public class ComidasController : BaseController
    {
        private TPDDSContext db = new TPDDSContext();

        // GET: /Comidas
        public ActionResult Index()
        {
            return RedirectToAction("Me");
        }

        // GET: /Comidas/Me
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
                return RedirectToAction("Index", "Home");
            }

            DateTime hoy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            var comidas = db.Comidas.Include(c => c.Clasificacion)
                .Include(c => c.Usuario)
                .Where(c => !c.Eliminada && c.Fecha >= hoy);

            return View(comidas.ToList());
        }

        // GET: /Comidas/Historico
        public ActionResult Historico()
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

            DateTime hoy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            var comidas = db.Comidas.Include(c => c.Clasificacion)
                .Include(c => c.Usuario)
                .Where(c => !c.Eliminada && c.Fecha < hoy)
                .OrderBy(c => c.Fecha);

            return View(comidas.ToList());
        }

        // GET: /Comidas/Details/5
        public ActionResult Details(int? id, bool? hist)
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

            var historico = true;

            if (hist == null)
                historico = false;
            else
                historico = (bool)hist;

            Comida comida;
            DateTime hoy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            if(historico)
                comida = db.Comidas.FirstOrDefault(c => !c.Eliminada
                    && c.Id == id
                    && c.Fecha < hoy);
            else
                comida = db.Comidas.FirstOrDefault(c => !c.Eliminada
                    && c.Id == id
                    && c.Fecha >= hoy);

            if (comida == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Historico = historico;

            return View(comida);
        }

        // GET: /Comidas/Create
        public ActionResult Create()
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

            ViewBag.ClasificacionId = new SelectList(db.Clasificaciones, "Id", "Nombre");

            Comida oComida = new Comida();
            oComida.Usuario = usuario;
            oComida.UsuarioId = usuario.Id;
            oComida.Fecha = DateTime.Now;

            return View(oComida);
        }

        // POST: /Comidas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comida comida)
        {
            if (ModelState.IsValid)
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

                //Validar Fecha >= a hoy.

                //Actualizo BD
                db.Comidas.Add(comida);
                db.SaveChanges();

                //Todo OK
                Success(string.Format("<b>{0}!!</b> Su Planificación se creo correctamente.", usuario.Nombre), true);
                return RedirectToAction("Index", "Recetas");
            }

            ViewBag.ClasificacionId = new SelectList(db.Clasificaciones, "Id", "Nombre", comida.ClasificacionId);

            return View(comida);
        }

        // GET: /Comidas/SeleccionarReceta
        public ActionResult SeleccionarReceta(int? id)
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

            Receta receta = db.Recetas.Find(id);

            if (receta == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ClasificacionId = new SelectList(db.Clasificaciones, "Id", "Nombre");

            ComidaReceta item = new ComidaReceta();
            item.Receta = receta;
            item.RecetaId = receta.Id;
            item.Comida = new Comida();
            item.Comida.Fecha = DateTime.Now;

            return View(item);
        }

        // POST: /Comidas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SeleccionarReceta(ComidaReceta item)
        {
            if (ModelState.IsValid)
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

                //Validar Fecha >= a HOY

                bool booExiste = false;

                Comida comida = db.Comidas.
                    FirstOrDefault(c => c.UsuarioId == usuario.Id
                        && !c.Eliminada
                        && c.Fecha == item.Comida.Fecha
                        && c.ClasificacionId == item.Comida.ClasificacionId);

                //Valido si existe la Planificacion
                if (comida == null)
                {
                    comida = new Comida();
                    comida.ClasificacionId = item.Comida.ClasificacionId;
                    comida.Fecha = item.Comida.Fecha;
                    comida.UsuarioId = usuario.Id;
                }
                else
                {
                    ComidaReceta itemOrig = db.ComidasRecetas
                        .FirstOrDefault(cr => cr.ComidaId == comida.Id
                            && !cr.Eliminada
                            && cr.RecetaId == item.RecetaId);

                    //Valido si ya fue planifiacada
                    if (itemOrig == null)
                    {
                        booExiste = false;
                    }
                    else
                    {
                        booExiste = true;
                    }
                }

                if (booExiste)
                {
                    //Ya existe
                    Warning(string.Format("<b>{0}!!</b> La Receta ya fue Seleccionada anteriormente.", usuario.Nombre), true);
                    return RedirectToAction("Me", "Comidas");
                }
                else
                {
                    item.Comida = comida;

                    //Actualizo BD
                    db.ComidasRecetas.Add(item);
                    db.SaveChanges();

                    //Todo OK
                    Success(string.Format("<b>{0}!!</b> La Receta fue Seleccionada correctamente.", usuario.Nombre), true);
                    return RedirectToAction("Me", "Comidas");
                }
            }

            ViewBag.ClasificacionId = new SelectList(db.Clasificaciones, "Id", "Nombre", item.Comida.ClasificacionId);

            item.Receta = db.Recetas.Find(item.RecetaId);

            return View(item);
        }

        // GET: /Comidas/Delete/5
        public ActionResult Delete(int? id)
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

            Comida comida = db.Comidas.Find(id);

            if (comida == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(comida);
        }

        // POST: /Comidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comida comida = db.Comidas.Find(id);
            comida.Eliminada = true;
            db.Entry(comida).State = EntityState.Modified;
            db.SaveChanges();
            Success(string.Format("<b>{0}!!</b> La Planificación se elimino correctamente.", comida.Usuario.Nombre), true);
            return RedirectToAction("Me");
        }

        // GET: /Comidas/Delete/5
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

            ComidaReceta item = db.ComidasRecetas.Find(id);

            if (item == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(item);
        }

        // POST: /Comidas/Delete/5
        [HttpPost, ActionName("DeleteReceta")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecetaConfirmed(int id)
        {
            ComidaReceta item = db.ComidasRecetas.Find(id);
            item.Eliminada = true;
            item.FechaBaja = DateTime.Now;
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            Success(string.Format("<b>{0}!!</b> La Receta se elimino correctamente de la Planificación.", item.Comida.Usuario.Nombre), true);
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
