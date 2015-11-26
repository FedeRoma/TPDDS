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
using System.IO;

namespace TP_DDS.Controllers
{
    public class RecetasController : BaseController
    {
        private TPDDSContext db = new TPDDSContext();

        // GET: /Recetas/
        public ActionResult Index()
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                Dieta normal = db.Dietas.FirstOrDefault(d => d.Nombre.Equals("Normal"));

                //No es Dieta Normal
                if (usuario.DietaId != normal.Id)
                {
                    var recetas = db.Recetas.Include(r => r.Dificultad)
                    .Include(r => r.Creador)
                    .Include(r => r.Piramide)
                    .Where(r => !r.Eliminada && r.Creador.DietaId == usuario.DietaId);

                    return View(recetas.ToList());
                }
                else
                {
                    //Preferencias del usuario
                    List<int> IDs = usuario.Preferencias.ToList().Select(p => p.Id).ToList<int>();

                    //Recetas con esas preferencias
                    List<int> recetasIDs = db.IngredientesRecetas.Include(i => i.Ingrediente)
                        .Where(i => IDs.Contains(i.Ingrediente.Preferencia.Id))
                        .ToList().Select(i => i.RecetaId).Distinct().ToList<int>();

                    //obtenemos las recetas
                    var recetas = db.Recetas.Include(r => r.Dificultad)
                    .Include(r => r.Creador)
                    .Include(r => r.Piramide)
                    .Include(r => r.Ingredientes)
                    .Where(r => !r.Eliminada
                        && recetasIDs.Contains(r.Id)
                    );

                    return View(recetas.ToList());
                }
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }

        }

        // GET: /Recetas/Me
        public ActionResult Me()
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.UsuarioId = usuario.Id;

                RecetasMeViewModel model = new RecetasMeViewModel();

                model.Creadas = db.Recetas.Include(r => r.Dificultad)
                    .Include(r => r.Creador).
                    Include(r => r.Piramide)
                    .Where(r => !r.Eliminada && r.UsuarioId == usuario.Id);

                model.Calificadas = db.Calificaciones.Include(r => r.Receta)
                    .Include(u => u.Usuario)
                    .Where(c => !c.Receta.Eliminada && c.UsuarioId == usuario.Id)
                    .Select(c => c.Receta).Include(r => r.Calificaciones);

                model.Consultadas = db.Estadisticas
                    .Include(r => r.Receta)
                    .Include(u => u.Usuario)
                    .Where(c => !c.Receta.Eliminada && c.UsuarioId == usuario.Id)
                    .Select(r => r.Receta).Distinct();

                return View(model);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: /Recetas/Details/5
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

                Receta receta = db.Recetas.Find(id);

                if (receta == null)
                {
                    return RedirectToAction("Index");
                }

                ActualizarEstadisticas(receta, usuario);

                //Tiene permisos para Calificar
                ViewBag.PuedeCalificar = PuedeCalificar(receta, usuario);
                Calificacion calif = receta.Calificaciones.
                    FirstOrDefault(c => c.RecetaId == receta.Id && c.UsuarioId == usuario.Id);

                if (calif != null)
                    ViewBag.CalifUsuario = calif.Valor.ToString();

                //Tiene permisos para Editar - Solo el creador
                ViewBag.PuedeEditar = (receta.UsuarioId == usuario.Id);

                //Tiene permisos para Eliminar - Solo el creador
                ViewBag.PuedeEliminar = (receta.UsuarioId == usuario.Id);

                return View(receta);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        private void ActualizarEstadisticas(Receta receta, Usuario usuario)
        {
            try
            {
                DateTime hoyMin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                DateTime hoyMax = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

                Estadistica oEst = db.Estadisticas
                    .FirstOrDefault(e => e.FechaHora > hoyMin
                        && e.FechaHora < hoyMax
                        && e.RecetaId == receta.Id
                        && e.UsuarioId == usuario.Id);

                if (oEst == null)
                {
                    oEst = new Estadistica();
                    oEst.RecetaId = receta.Id;
                    oEst.UsuarioId = usuario.Id;
                    oEst.FechaHora = DateTime.Now;

                    db.Estadisticas.Add(oEst);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                throw;
            }
        }

        private bool PuedeCalificar(Receta receta, Usuario usuario)
        {
            try
            {
                //el creador no puede calificar su receta.
                if (receta.UsuarioId == usuario.Id)
                {
                    return false;
                }

                //Si ya califico tampoco
                Calificacion calificacion = db.Calificaciones
                    .FirstOrDefault(c => c.RecetaId == receta.Id && c.UsuarioId == usuario.Id);

                if (calificacion != null)
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                throw;
            }
        }

        [HttpGet]
        public ActionResult AddIngredienteNewRow()
        {
            ViewBag.Ingrediente = new SelectList(db.Ingredientes, "Id", "Nombre");
            ViewBag.TipoIngrediente = new SelectList(db.TipoIngredientes, "Id", "Nombre");
            var model = new IngredienteReceta();
            return PartialView("_IngredienteNewRow", model);
        }

        [HttpGet]
        public ActionResult AddCondimentoNewRow()
        {
            ViewBag.Id = new SelectList(db.Condimentos, "Id", "Nombre");
            var model = new Condimento();
            return PartialView("_CondimentoNewRow", model);
        }

        // GET: /Recetas/Create
        public ActionResult Create()
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.PiramideId = new SelectList(db.PiramideAlimenticia, "Id", "NombreGrupo");
                ViewBag.DificultadId = new SelectList(db.Dificultades, "Id", "Nombre");

                ViewBag.CondimentoId = new SelectList(db.Condimentos, "Id", "Nombre");
                ViewBag.IngredienteId = new SelectList(db.Ingredientes, "Id", "Nombre");
                ViewBag.TipoIngredienteId = new SelectList(db.TipoIngredientes, "Id", "Nombre");

                Receta oReceta = new Receta();
                oReceta.Ingredientes = new List<IngredienteReceta>();
                oReceta.Condimentos = new List<Condimento>();
                oReceta.Temporadas = db.Temporadas.OrderBy(p => p.Nombre).ToList();
                oReceta.Clasificaciones = db.Clasificaciones.OrderBy(p => p.Nombre).ToList();

                oReceta.Procedimientos = new List<Procedimiento>();
                Procedimiento oProc;

                for (var i = 1; i < 6; i++)
                {
                    oProc = new Procedimiento();
                    oProc.Numero = i;
                    oProc.Nombre = "";
                    oProc.Imagen = "";
                    oReceta.Procedimientos.Add(oProc);
                }

                return View(oReceta);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: /Recetas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Receta receta)
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                ValidarReceta(ModelState, receta);

                if (ModelState.IsValid)
                {
                    //receta.Creador = usuario;
                    receta.UsuarioId = usuario.Id;
                    receta.FechaCreacion = DateTime.Now;
                    receta.FechaUltModif = receta.FechaCreacion;

                    //Temporadas
                    var temps = receta.Temporadas.Where(t => t.Sel).ToList();
                    receta.Temporadas.Clear();
                    Temporada temporada;

                    foreach (var item in temps)
                    {
                        temporada = db.Temporadas.Find(item.Id);
                        receta.Temporadas.Add(temporada);
                    }

                    //Clasificaciones
                    var clasif = receta.Clasificaciones.Where(c => c.Sel).ToList();
                    receta.Clasificaciones.Clear();
                    Clasificacion clasificacion;

                    foreach (var item in clasif)
                    {
                        clasificacion = db.Clasificaciones.Find(item.Id);
                        receta.Clasificaciones.Add(clasificacion);
                    }

                    //Procedimientos
                    var i = 1;
                    var proc = receta.Procedimientos.Where(p => !string.IsNullOrEmpty(p.Nombre)).ToList();
                    receta.Procedimientos.Clear();
                    Procedimiento oProc;

                    foreach (var item in proc)
                    {
                        oProc = new Procedimiento();
                        oProc.Numero = i;
                        oProc.Nombre = item.Nombre;
                        oProc.Imagen = "";

                        if (Request.Files.Count > 0)
                        {
                            var file = Request.Files[i - 1];

                            if (file != null && file.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(file.FileName);
                                fileName = DateTime.Now.ToString("yyyyMMddhhmmss") + fileName.Substring(fileName.Length - 4, 4);
                                var path = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                                file.SaveAs(path);
                                //oProc.Imagen = "~/Content/Images/" + fileName;
                                oProc.Imagen = fileName;
                            }
                        }

                        receta.Procedimientos.Add(oProc);
                        i++;
                    }

                    //Ingredientes
                    Ingrediente ingrediente;

                    foreach (var item in receta.Ingredientes)
                    {
                        ingrediente = db.Ingredientes.Find(item.IngredienteId);
                        receta.TotalCalorias = receta.TotalCalorias + item.Cantidad * ingrediente.CaloriasPorcion;
                    }

                    //Codimentos
                    var condi = receta.Condimentos.ToList();
                    receta.Condimentos.Clear();
                    Condimento condimento;

                    foreach (var item in condi)
                    {
                        condimento = db.Condimentos.Find(item.Id);
                        receta.Condimentos.Add(condimento);
                    }

                    //Creacion
                    db.Recetas.Add(receta);
                    db.SaveChanges();

                    //Todo OK
                    Success(string.Format("<b>{0}!!</b> La receta <b>{1}</b> se creo correctamente.", usuario.Nombre, receta.Nombre), true);
                    return RedirectToAction("Me");
                }

                ViewBag.PiramideId = new SelectList(db.PiramideAlimenticia, "Id", "NombreGrupo");
                ViewBag.DificultadId = new SelectList(db.Dificultades, "Id", "Nombre");

                ViewBag.CondimentoId = new SelectList(db.Condimentos, "Id", "Nombre");
                ViewBag.IngredienteId = new SelectList(db.Ingredientes, "Id", "Nombre");
                ViewBag.TipoIngredienteId = new SelectList(db.TipoIngredientes, "Id", "Nombre");

                if (receta.Ingredientes == null)
                    receta.Ingredientes = new List<IngredienteReceta>();

                if (receta.Condimentos == null)
                    receta.Condimentos = new List<Condimento>();

                if (receta.Temporadas == null)
                    receta.Temporadas = db.Temporadas.OrderBy(p => p.Nombre).ToList();

                if (receta.Clasificaciones == null)
                    receta.Clasificaciones = db.Clasificaciones.OrderBy(p => p.Nombre).ToList();

                if (receta.Procedimientos == null)
                {
                    receta.Procedimientos = new List<Procedimiento>();
                    Procedimiento oProc = new Procedimiento();

                    for (var i = 1; i < 6; i++)
                    {
                        oProc = new Procedimiento();
                        oProc.Numero = i;
                        oProc.Nombre = "";
                        oProc.Imagen = "";
                        receta.Procedimientos.Add(oProc);
                    }

                }
                else
                {
                    if (receta.Procedimientos.Where(c => c.Nombre == null || c.Nombre == "").Count() == 5)
                    {
                        receta.Procedimientos.Clear();
                        receta.Procedimientos = new List<Procedimiento>();
                        Procedimiento oProc = new Procedimiento();

                        for (var i = 1; i < 6; i++)
                        {
                            oProc = new Procedimiento();
                            oProc.Numero = i;
                            oProc.Nombre = "";
                            oProc.Imagen = "";
                            receta.Procedimientos.Add(oProc);
                        }
                    }
                }
                return View(receta);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        private void ValidarReceta(ModelStateDictionary ModelState, Receta receta)
        {
            foreach (var item in ModelState.Keys)
            {
                ModelState[item].Errors.Clear();
            }

            if (string.IsNullOrEmpty(receta.Nombre))
            {
                ModelState.AddModelError("Nombre", "Ingrese un Nombre.");
            }

            if (receta.DificultadId == 0)
            {
                ModelState.AddModelError("DificultadId", "Seleccione un valor.");
            }

            if (receta.PiramideId == 0)
            {
                ModelState.AddModelError("PiramideId", "Seleccione un valor.");
            }

            if (receta.Temporadas == null)
            {
                ModelState.AddModelError("Temporadas", "Seleccione al menos una Temporada.");
            }
            else
            {
                if (receta.Temporadas.Where(p => p.Sel).Count() == 0)
                    ModelState.AddModelError("Temporadas", "Seleccione al menos una Temporada.");
            }

            if (receta.Clasificaciones == null)
            {
                ModelState.AddModelError("Clasificaciones", "Seleccione al menos una Clasificacion.");
            }
            else
            {
                if (receta.Clasificaciones.Where(p => p.Sel).Count() == 0)
                    ModelState.AddModelError("Clasificaciones", "Seleccione al menos una Clasificacion.");
            }

            if (receta.Condimentos == null)
            {
                ModelState.AddModelError("Condimentos", "Incorpore al menos un Condimento.");
            }
            else
            {
                if (receta.Condimentos.Where(c => c.Id > 0).Count() == 0)
                    ModelState.AddModelError("Condimentos", "Incorpore al menos un Condimento.");
            }

            if (receta.Ingredientes == null)
            {
                ModelState.AddModelError("Ingredientes", "Incorpore al menos un Ingrediente.");
            }
            else
            {
                if (receta.Ingredientes.Where(c => c.IngredienteId > 0).Count() == 0)
                    ModelState.AddModelError("Ingredientes", "Incorpore al menos un Ingrediente.");
                else if (receta.Ingredientes.Where(c => c.TipoIngredienteId > 0).Count() == 0)
                    ModelState.AddModelError("Ingredientes", "Seleccione el Tipo  de Ingrediente.");
            }

            if (receta.Procedimientos == null)
            {
                ModelState.AddModelError("Procedimientos", "Incorpore al menos un Procedimiento.");
            }
            else
            {
                if (receta.Procedimientos.Where(c => c.Nombre == null || c.Nombre == "").Count() == 5)
                    ModelState.AddModelError("Procedimientos", "Incorpore al menos un Procedimiento.");
            }
        }

        // GET: /Recetas/Edit/5
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

                Receta receta = db.Recetas.Find(id);

                if (receta == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                if (receta.UsuarioId != usuario.Id)
                {
                    return RedirectToAction("Index", "Home");
                }

                var temporadas = receta.Temporadas.ToList();
                receta.Temporadas.Clear();
                Temporada temporada;

                foreach (var item in db.Temporadas.OrderBy(p => p.Nombre))
                {
                    temporada = new Temporada();
                    temporada.Nombre = item.Nombre;
                    temporada.Id = item.Id;
                    temporada.Sel = false;

                    if (temporadas.FirstOrDefault(u => u.Id.Equals(item.Id)) != null)
                        temporada.Sel = true;

                    receta.Temporadas.Add(temporada);
                }

                var clasificaciones = receta.Clasificaciones.ToList();
                receta.Clasificaciones.Clear();
                Clasificacion clasificacion;

                foreach (var item in db.Clasificaciones.OrderBy(p => p.Nombre))
                {
                    clasificacion = new Clasificacion();
                    clasificacion.Nombre = item.Nombre;
                    clasificacion.Id = item.Id;
                    clasificacion.Sel = false;

                    if (clasificaciones.FirstOrDefault(u => u.Id.Equals(item.Id)) != null)
                        clasificacion.Sel = true;

                    receta.Clasificaciones.Add(clasificacion);
                }

                var procedimientos = receta.Procedimientos.ToList();
                Procedimiento procedimiento;

                for (var i = procedimientos.Count + 1; i < 6; i++)
                {
                    procedimiento = new Procedimiento();
                    procedimiento.Numero = i;
                    procedimiento.Nombre = "";
                    procedimiento.Imagen = "";

                    receta.Procedimientos.Add(procedimiento);
                }

                ViewBag.Piramide = new SelectList(db.PiramideAlimenticia, "Id", "NombreGrupo", receta.Piramide.Id);
                ViewBag.Dificultad = new SelectList(db.Dificultades, "Id", "Nombre");

                ViewBag.CondimentoId = new SelectList(db.Condimentos, "Id", "Nombre");
                ViewBag.Ingrediente = new SelectList(db.Ingredientes, "Id", "Nombre");
                ViewBag.TipoIngrediente = new SelectList(db.TipoIngredientes, "Id", "Nombre");

                return View(receta);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: /Recetas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Receta recetaNew)
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                ValidarReceta(ModelState, recetaNew);

                if (ModelState.IsValid)
                {
                    //Receta antes de modificar
                    var recetaToUpdate = db.Recetas
                       .Include(r => r.Creador)
                       .Include(r => r.Dificultad)
                       .Include(r => r.Creador)
                       .Include(r => r.Piramide)
                       .Where(r => r.Id == recetaNew.Id)
                       .Single();

                    //Actualizo datos Encabezado
                    recetaToUpdate.FechaUltModif = DateTime.Now;
                    recetaToUpdate.Nombre = recetaNew.Nombre;
                    recetaToUpdate.Dificultad = db.Dificultades.Find(recetaNew.DificultadId);
                    recetaToUpdate.DificultadId = recetaNew.DificultadId;
                    recetaToUpdate.Piramide = db.PiramideAlimenticia.Find(recetaNew.PiramideId);
                    recetaToUpdate.PiramideId = recetaNew.PiramideId;

                    //Temporadas
                    recetaToUpdate.Temporadas.ToList().ForEach(t => recetaToUpdate.Temporadas.Remove(t));
                    var temporadas = recetaNew.Temporadas.Where(t => t.Sel).ToList();
                    Temporada temporada;

                    foreach (var item in temporadas)
                    {
                        temporada = db.Temporadas.Find(item.Id);
                        recetaToUpdate.Temporadas.Add(temporada);
                    }

                    //Clasificaciones
                    recetaToUpdate.Clasificaciones.ToList().ForEach(c => recetaToUpdate.Clasificaciones.Remove(c));
                    var clasif = recetaNew.Clasificaciones.Where(c => c.Sel).ToList();
                    Clasificacion clasificacion;

                    foreach (var item in clasif)
                    {
                        clasificacion = db.Clasificaciones.Find(item.Id);
                        recetaToUpdate.Clasificaciones.Add(clasificacion);
                    }

                    //Procedimientos
                    foreach (var deleteMe in recetaToUpdate.Procedimientos.ToList())
                    {
                        recetaToUpdate.Procedimientos.Remove(deleteMe);
                        db.Entry(deleteMe).State = EntityState.Deleted;
                    }

                    var proc = recetaNew.Procedimientos.Where(p => !string.IsNullOrEmpty(p.Nombre)).ToList();
                    var numero = 1;
                    Procedimiento oProc;

                    foreach (var item in proc)
                    {
                        oProc = new Procedimiento();
                        oProc.Numero = numero;
                        oProc.Nombre = item.Nombre;
                        oProc.Imagen = item.Imagen != null ? item.Imagen.ToString() : "";

                        if (Request.Files.Count > 0)
                        {
                            var file = Request.Files[numero - 1];

                            if (file != null && file.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(file.FileName);
                                fileName = DateTime.Now.ToString("yyyyMMddhhmmss") + fileName.Substring(fileName.Length - 4, 4);
                                var path = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                                file.SaveAs(path);
                                //oProc.Imagen = "~/Content/Images/" + fileName;
                                oProc.Imagen = fileName;
                            }
                        }

                        recetaToUpdate.Procedimientos.Add(oProc);
                        db.Entry(oProc).State = EntityState.Added;
                        numero++;
                    }

                    //Ingredientes
                    foreach (var deleteMe in recetaToUpdate.Ingredientes.ToList())
                    {
                        recetaToUpdate.Ingredientes.Remove(deleteMe);
                        db.Entry(deleteMe).State = EntityState.Deleted;
                    }

                    recetaToUpdate.TotalCalorias = 0;
                    Ingrediente ingrediente;

                    foreach (var item in recetaNew.Ingredientes)
                    {
                        ingrediente = db.Ingredientes.Find(item.IngredienteId);
                        recetaToUpdate.TotalCalorias = recetaNew.TotalCalorias + item.Cantidad * ingrediente.CaloriasPorcion;

                        recetaToUpdate.Ingredientes.Add(item);
                        db.Entry(item).State = EntityState.Added;
                    }

                    //Codimentos
                    recetaToUpdate.Condimentos.ToList().ForEach(c => recetaToUpdate.Condimentos.Remove(c));
                    var condi = recetaNew.Condimentos.ToList();
                    Condimento condimento;

                    foreach (var item in condi)
                    {
                        condimento = db.Condimentos.Find(item.Id);
                        recetaToUpdate.Condimentos.Add(condimento);
                    }

                    //Actualizo DB
                    db.SaveChanges();

                    //Todo OK
                    Success(string.Format("<b>{0}!!</b> La receta <b>{1}</b> se actualizó correctamente.", usuario.Nombre, recetaToUpdate.Nombre), true);
                    return RedirectToAction("Me");
                }

                ViewBag.Piramide = new SelectList(db.PiramideAlimenticia, "Id", "NombreGrupo");
                ViewBag.Dificultad = new SelectList(db.Dificultades, "Id", "Nombre");

                ViewBag.CondimentoId = new SelectList(db.Condimentos, "Id", "Nombre");
                ViewBag.Ingrediente = new SelectList(db.Ingredientes, "Id", "Nombre");
                ViewBag.TipoIngrediente = new SelectList(db.TipoIngredientes, "Id", "Nombre");

                if (recetaNew.Ingredientes == null)
                    recetaNew.Ingredientes = new List<IngredienteReceta>();

                if (recetaNew.Condimentos == null)
                    recetaNew.Condimentos = new List<Condimento>();

                if (recetaNew.Temporadas == null)
                    recetaNew.Temporadas = db.Temporadas.OrderBy(p => p.Nombre).ToList();

                if (recetaNew.Clasificaciones == null)
                    recetaNew.Clasificaciones = db.Clasificaciones.OrderBy(p => p.Nombre).ToList();

                if (recetaNew.Procedimientos == null)
                {
                    recetaNew.Procedimientos = new List<Procedimiento>();
                    Procedimiento oProc = new Procedimiento();

                    for (var i = 1; i < 6; i++)
                    {
                        oProc = new Procedimiento();
                        oProc.Numero = i;
                        oProc.Nombre = "";
                        oProc.Imagen = "";
                        recetaNew.Procedimientos.Add(oProc);
                    }

                }

                return View(recetaNew);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: /Recetas/Delete/5
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

                Receta receta = db.Recetas.Find(id);

                if (receta == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                return View(receta);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: /Recetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Receta receta = db.Recetas.Find(id);
                receta.Eliminada = true;
                receta.FechaBaja = DateTime.Now;
                db.Entry(receta).State = EntityState.Modified;
                db.SaveChanges();

                //Todo OK
                Success(string.Format("<b>{0}!!</b> La receta <b>{1}</b> se elimino correctamente.", receta.Creador.Nombre, receta.Nombre), true);
                return RedirectToAction("Me");
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: /Recetas/Calificar
        public ActionResult Calificar(int? id)
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

                Receta receta = db.Recetas.Find(id);

                if (receta == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.Calificaciones = new SelectList(new[]
                                          {
                                              new{Id="1",Valor="1 Estrella"},
                                              new{Id="2",Valor="2 Estrellas"},
                                              new{Id="3",Valor="3 Estrellas"},
                                              new{Id="4",Valor="4 Estrellas"},
                                              new{Id="5",Valor="5 Estrellas"}
                                          },
                               "Id", "Valor");

                Calificacion oCalif = new Calificacion();
                oCalif.Usuario = usuario;
                oCalif.UsuarioId = usuario.Id;
                oCalif.Receta = receta;
                oCalif.RecetaId = receta.Id;

                return View(oCalif);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: /Recetas/Calificar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calificar(Calificacion calificacion)
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                ValidarCalificacion(ModelState, calificacion);

                if (ModelState.IsValid)
                {
                    Receta receta = db.Recetas.Find(calificacion.RecetaId);

                    var TotCalif = 0;
                    var CantCalif = 0;

                    receta.Calificaciones.ToList().ForEach(c => TotCalif = TotCalif + c.Valor);
                    CantCalif = receta.Calificaciones.Count();
                    CantCalif = CantCalif + 1;
                    TotCalif = TotCalif + calificacion.Valor;

                    receta.CalificacionPromedio = TotCalif / CantCalif;

                    //calificacion.Receta = receta;
                    //calificacion.Usuario = usuario;
                    calificacion.FechaHora = DateTime.Now;
                    if (string.IsNullOrEmpty(calificacion.Comentario))
                        calificacion.Comentario = "";

                    //Creacion
                    db.Calificaciones.Add(calificacion);

                    //Actualizacion
                    db.Entry(receta).State = EntityState.Modified;

                    db.SaveChanges();

                    //Todo OK
                    Success(string.Format("<b>{0}!!</b> La receta <b>{1}</b> se califico correctamente.", usuario.Nombre, receta.Nombre), true);
                    return RedirectToAction("Me");
                }

                ViewBag.Calificaciones = new SelectList(new[]
                                          {
                                              new{Id="1",Valor="1 Estrella"},
                                              new{Id="2",Valor="2 Estrellas"},
                                              new{Id="3",Valor="3 Estrellas"},
                                              new{Id="4",Valor="4 Estrellas"},
                                              new{Id="5",Valor="5 Estrellas"}
                                          },
                   "Id", "Valor");
                
                calificacion.Receta = db.Recetas.Find(calificacion.RecetaId);

                return View(calificacion);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        private void ValidarCalificacion(ModelStateDictionary ModelState, Calificacion calificacion)
        {
            foreach (var item in ModelState.Keys)
            {
                ModelState[item].Errors.Clear();
            }

            if (calificacion.Valor == 0)
            {
                ModelState.AddModelError("Valor", "Seleccione un valor.");
            }
        }

        // GET: /Recetas/VerCalificaciones
        public ActionResult VerCalificaciones(int? id)
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

                Receta receta = db.Recetas.Find(id);

                if (receta == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                return View(receta);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: /Recetas/CompartirReceta
        public ActionResult CompartirReceta(int? id)
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

                var misGrupos = db.Grupos
                    .Where(g => g.UsuarioId == usuario.Id);

                ViewBag.GrupoId = new SelectList(db.GruposUsuarios.Include(g => g.Grupo).
                    Where(g => g.UsuarioId == usuario.Id)
                    .Select(g => g.Grupo).Union(misGrupos), "Id", "Nombre");

                GrupoReceta item = new GrupoReceta();
                item.Receta = receta;
                item.RecetaId = receta.Id;
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

        // POST: /Recetas/CompartirReceta
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompartirReceta(GrupoReceta item)
        {
            try
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());

                if (usuario == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                ValidarCompartir(ModelState, item);

                if (ModelState.IsValid)
                {
                    bool booExiste = false;

                    //Valido si existe la Planificacion
                    GrupoReceta itemOrig = db.GruposRecetas
                        .FirstOrDefault(gr => gr.GrupoId == item.GrupoId
                            && !gr.Eliminada
                            && gr.RecetaId == item.RecetaId);

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
                        Information(string.Format("<b>{0}!!</b> La Receta ya fue compartida anteriormente.", usuario.Nombre), true);
                        return RedirectToAction("Index", "Recetas");
                    }
                    else
                    {
                        item.Eliminada = false;

                        //Actualizo BD
                        db.GruposRecetas.Add(item);
                        db.SaveChanges();

                        //Todo OK
                        Success(string.Format("<b>{0}!!</b> La Receta fue Seleccionada correctamente.", usuario.Nombre), true);
                        return RedirectToAction("Index", "Recetas");
                    }
                }

                var misGrupos = db.Grupos
                    .Where(g => g.UsuarioId == usuario.Id);

                ViewBag.GrupoId = new SelectList(db.GruposUsuarios.Include(g => g.Grupo).
                    Where(g => g.UsuarioId == usuario.Id)
                    .Select(g => g.Grupo).Union(misGrupos), "Id", "Nombre");

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

        private void ValidarCompartir(ModelStateDictionary ModelState, GrupoReceta item)
        {
            foreach (var key in ModelState.Keys)
            {
                ModelState[key].Errors.Clear();
            }

            if (item.GrupoId == 0)
            {
                ModelState.AddModelError("GrupoId", "Seleccione un Grupo.");
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
