using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ConsultasController : BaseController
    {
        private TPDDSContext db = new TPDDSContext();

        //
        // GET: /ConsultaUno/
        public ActionResult ConsultaUno([Bind(Include = "RutinaId")] CaloriasMaxByRutina param)
        {
            try
            {
                string userEmail = User.Identity.GetUserName();

                if (string.IsNullOrEmpty(userEmail))
                {
                    return RedirectToAction("Index", "Home");
                }

                var viewModel = new CaloriasMaxByRutina();

                ViewBag.Rutinas = new SelectList(db.Rutinas, "Id", "Nombre");

                viewModel.Results = null;
                ViewBag.MsjError = "";

                if (param.RutinaId > 0)
                {
                    viewModel.Results = db.GetCaloriasMaxByRutina(param.RutinaId);
                }
                else
                {
                    ViewBag.MsjError = "Seleccione una Rutina";
                }

                return View(viewModel);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        //
        // GET: /ConsultaDos/
        public ActionResult ConsultaDos([Bind(Include = "TemporadaId,CalificacionId")] RecetasByTempoCalif param)
        {
            try
            {
                string userEmail = User.Identity.GetUserName();

                if (string.IsNullOrEmpty(userEmail))
                {
                    return RedirectToAction("Index", "Home");
                }

                var viewModel = new RecetasByTempoCalif();

                ViewBag.Temporadas = new SelectList(db.Temporadas, "Id", "Nombre");
                ViewBag.Calificaciones = new SelectList(new[]
                                          {
                                              new {Id="1",Valor="1 Estrella"},
                                              new{Id="2",Valor="2 Estrellas"},
                                              new{Id="3",Valor="3 Estrellas"},
                                              new{Id="4",Valor="4 Estrellas"},
                                              new{Id="5",Valor="5 Estrellas"}
                                          },
                                           "Id", "Valor");

                viewModel.Results = null;

                ViewBag.MsjErrorTemp = "";
                ViewBag.MsjErrorCalif = "";

                if ((param.TemporadaId > 0) && (param.CalificacionId > 0))
                {
                    viewModel.Results = db.GetRecetasByTempoCalif(param.TemporadaId, param.CalificacionId);
                }
                else
                {
                    if(!(param.TemporadaId > 0))
                        ViewBag.MsjErrorTemp = "Seleccione una Temporada";

                    if (!(param.CalificacionId > 0))
                        ViewBag.MsjErrorCalif = "Seleccione una Calificacion";
                }

                return View(viewModel);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        //
        // GET: /ConsultaTres/
        public ActionResult ConsultaTres([Bind(Include = "DietaId")] RecetasByDieta param)
        {
            try
            {
                string userEmail = User.Identity.GetUserName();

                if (string.IsNullOrEmpty(userEmail))
                {
                    return RedirectToAction("Index", "Home");
                }

                var viewModel = new RecetasByDieta();

                ViewBag.Dietas = new SelectList(db.Dietas, "Id", "Nombre");

                viewModel.Results = null;
                ViewBag.MsjError = "";

                if (param.DietaId > 0)
                {
                    viewModel.Results = db.GetRecetasByDieta(param.DietaId);
                }
                else
                {
                    ViewBag.MsjError = "Seleccione una Dieta";
                }

                return View(viewModel);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        //
        // GET: /ConsultaCuatro/
        public ActionResult ConsultaCuatro([Bind(Include = "PreferenciaId")] RecetasByPreferencia param)
        {
            try
            {
                string userEmail = User.Identity.GetUserName();

                if (string.IsNullOrEmpty(userEmail))
                {
                    return RedirectToAction("Index", "Home");
                }

                var viewModel = new RecetasByPreferencia();

                ViewBag.Preferencias = new SelectList(db.Preferencias, "Id", "Nombre");

                viewModel.Results = null;
                ViewBag.MsjError = "";

                if (param.PreferenciaId > 0)
                {
                    viewModel.Results = db.GetRecetasByPreferencia(param.PreferenciaId);
                }
                else
                {
                    ViewBag.MsjError = "Seleccione una Preferencia";
                }

                return View(viewModel);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        //
        // GET: /ConsultaCinco/
        public ActionResult ConsultaCinco([Bind(Include = "CondimentoId")] RecetasByCondimento param)
        {
            try
            {
                string userEmail = User.Identity.GetUserName();

                if (string.IsNullOrEmpty(userEmail))
                {
                    return RedirectToAction("Index", "Home");
                }

                var viewModel = new RecetasByCondimento();

                ViewBag.Condimentos = new SelectList(db.Condimentos, "Id", "Nombre");

                viewModel.Results = null;
                ViewBag.MsjError = "";

                if (param.CondimentoId > 0)
                {
                    viewModel.Results = db.GetRecetasByCondimento(param.CondimentoId);
                }
                else
                {
                    ViewBag.MsjError = "Seleccione un Condimento";
                }

                return View(viewModel);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        //
        // GET: /ConsultaSeis/
        public ActionResult ConsultaSeis([Bind(Include = "SexoId,ComplexionId,CalificacionId")] RecetasBySexComplex param)
        {
            try
            {
                string userEmail = User.Identity.GetUserName();

                if (string.IsNullOrEmpty(userEmail))
                {
                    return RedirectToAction("Index", "Home");
                }

                var viewModel = new RecetasBySexComplex();

                ViewBag.Sexo = new SelectList(db.Sexo, "Id", "Nombre");
                ViewBag.Complexiones = new SelectList(db.Complexiones, "Id", "Nombre");

                ViewBag.Calificaciones = new SelectList(new[]
                                          {
                                              new {Id="1",Valor="1 Estrella"},
                                              new{Id="2",Valor="2 Estrellas"},
                                              new{Id="3",Valor="3 Estrellas"},
                                              new{Id="4",Valor="4 Estrellas"},
                                              new{Id="5",Valor="5 Estrellas"}
                                          },
                                           "Id", "Valor");

                viewModel.Results = null;
                ViewBag.MsjErrorSexo = "";
                ViewBag.MsjErrorComplexion = "";
                ViewBag.MsjErrorCalificacionId = "";

                if ((param.SexoId > 0) && (param.ComplexionId > 0) && (param.CalificacionId > 0))
                {
                    viewModel.Results = db.GetRecetasBySexComplex(param.SexoId, param.ComplexionId, param.CalificacionId);
                }
                else
                {
                    if (!(param.SexoId > 0))
                        ViewBag.MsjErrorTemp = "Seleccione un Sexo";

                    if (!(param.ComplexionId > 0))
                        ViewBag.MsjErrorCalif = "Seleccione una Complexion";

                    if (!(param.CalificacionId > 0))
                        ViewBag.MsjErrorCalif = "Seleccione una Calificacion";
                }
                return View(viewModel);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        //
        // GET: /ConsultaSiete/
        public ActionResult ConsultaSiete([Bind(Include = "PiramideId")] RecetasByPiramide param)
        {
            try
            {
                string userEmail = User.Identity.GetUserName();

                if (string.IsNullOrEmpty(userEmail))
                {
                    return RedirectToAction("Index", "Home");
                }

                var viewModel = new RecetasByPiramide();

                ViewBag.PiramideAlimenticia = new SelectList(db.PiramideAlimenticia, "Id", "NombreGrupo");

                viewModel.Results = null;
                ViewBag.MsjError = "";

                if (param.PiramideId > 0)
                {
                    viewModel.Results = db.GetRecetasByPiramide(param.PiramideId);
                }
                else
                {
                    ViewBag.MsjError = "Seleccione un Grupo";
                }

                return View(viewModel);
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }
	}
}