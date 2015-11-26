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
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                DateTime hoy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                var comidas = db.Comidas.Include(c => c.Clasificacion)
                    .Include(c => c.Usuario)
                    .Where(c => c.UsuarioId == usuario.Id
                        && !c.Eliminada 
                        && c.Fecha >= hoy);

                return View(comidas.ToList());
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: /Comidas/Historico
        public ActionResult Historico()
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                DateTime hoy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                var comidas = db.Comidas.Include(c => c.Clasificacion)
                    .Include(c => c.Usuario)
                    .Where(c => c.UsuarioId == usuario.Id 
                        &&!c.Eliminada 
                        && c.Fecha < hoy)
                    .OrderBy(c => c.Fecha);

                return View(comidas.ToList());
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: /Comidas/Details/5
        public ActionResult Details(int? id, bool? hist)
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

                var historico = true;

                if (hist == null)
                    historico = false;
                else
                    historico = (bool)hist;

                Comida comida;
                DateTime hoy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                if (historico)
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
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: /Comidas/Create
        public ActionResult Create()
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

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
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: /Comidas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comida comida)
        {
            try
            {
                ValidarComida(ModelState, comida);

                if (ModelState.IsValid)
                {
                    string userEmail = User.Identity.GetUserName();

                    if (string.IsNullOrEmpty(userEmail))
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                    if (usuario == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }

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
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        private void ValidarComida(ModelStateDictionary ModelState, Comida comida)
        {
            foreach (var item in ModelState.Keys)
            {
                ModelState[item].Errors.Clear();
            }

            DateTime hoy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

            if (comida.Fecha == null || comida.Fecha == DateTime.MinValue)
            {
                ModelState.AddModelError("Fecha", "Ingrese una Fecha");
            }
            else
            {
                if (comida.Fecha < hoy)
                {
                    ModelState.AddModelError("Fecha", "La Fecha debe ser mayor o igual a hoy " + hoy.ToString("dd/MM/yyyy"));
                }
            }

            if (comida.ClasificacionId == null || comida.ClasificacionId == 0)
            {
                ModelState.AddModelError("ClasificacionId", "Seleccione una Clasificacion");
            }
        }

        // GET: /Comidas/SeleccionarReceta
        public ActionResult SeleccionarReceta(int? id)
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

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
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Recetas");
            }
        }

        // POST: /Comidas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SeleccionarReceta(ComidaReceta item)
        {
            try
            {
                ValidarComida(ModelState, item.Comida);

                if (ModelState.IsValid)
                {
                    Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                    if (usuario == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }

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
                        Information(string.Format("<b>{0}!!</b> La Receta ya fue Seleccionada anteriormente.", usuario.Nombre), true);
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
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: /Comidas/Delete/5
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

                Comida comida = db.Comidas.Find(id);

                if (comida == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                return View(comida);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: /Comidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Comida comida = db.Comidas.Find(id);
                comida.Eliminada = true;
                db.Entry(comida).State = EntityState.Modified;
                db.SaveChanges();

                Success(string.Format("<b>{0}!!</b> La Planificación se elimino correctamente.", comida.Usuario.Nombre), true);
                return RedirectToAction("Me");
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: /Comidas/Delete/5
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

                ComidaReceta item = db.ComidasRecetas.Find(id);

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

        // POST: /Comidas/Delete/5
        [HttpPost, ActionName("DeleteReceta")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecetaConfirmed(int id)
        {
            try
            {
                ComidaReceta item = db.ComidasRecetas.Find(id);
                item.Eliminada = true;
                item.FechaBaja = DateTime.Now;
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();

                Success(string.Format("<b>{0}!!</b> La Receta se elimino correctamente de la Planificación.", item.Comida.Usuario.Nombre), true);
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
