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
    public class EstadisticasController : BaseController
    {
        //
        // GET: /Estadisticas/
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Estadisticas/PorSexo
        public ActionResult PorSexo([Bind(Include = "Tipo")] Estadistica param)
        {
            try
            {
                string userEmail = User.Identity.GetUserName();

                if (string.IsNullOrEmpty(userEmail))
                {
                    return RedirectToAction("Index", "Home");
                }

                var viewModel = new Estadistica();

                ViewBag.Tipos = new SelectList(new[]
                                          {
                                              new {Id="1",Valor="Mensual"},
                                              new {Id="2",Valor="Semanal"}
                                          },
                                           "Id", "Valor");
                ViewBag.MsjError = "";

                if (param.Tipo > 0)
                {
                    ViewBag.Results = (IEnumerable<EstadisticaSexo>)param.Ejecutar(new EstadisticaSexo()); ;
                }
                else
                {
                    ViewBag.MsjError = "Seleccione un Tipo";
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
        // GET: /Estadisticas/PorDificultad
        public ActionResult PorDificultad([Bind(Include = "Tipo")] Estadistica param)
        {
            try
            {
                string userEmail = User.Identity.GetUserName();

                if (string.IsNullOrEmpty(userEmail))
                {
                    return RedirectToAction("Index", "Home");
                }

                var viewModel = new Estadistica();

                ViewBag.Tipos = new SelectList(new[]
                                          {
                                              new {Id="1",Valor="Mensual"},
                                              new {Id="2",Valor="Semanal"}
                                          },
                                           "Id", "Valor");
                ViewBag.MsjError = "";

                if (param.Tipo > 0)
                {
                    ViewBag.Results = (IEnumerable<EstadisticaDificultad>)param.Ejecutar(new EstadisticaDificultad()); ;
                }
                else
                {
                    ViewBag.MsjError = "Seleccione un Tipo";
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
        // GET: /Estadisticas/Ranking
        public ActionResult Ranking([Bind(Include = "Tipo")] Estadistica param)
        {
            try
            {
                string userEmail = User.Identity.GetUserName();

                if (string.IsNullOrEmpty(userEmail))
                {
                    return RedirectToAction("Index", "Home");
                }

                var viewModel = new Estadistica();

                ViewBag.Tipos = new SelectList(new[]
                                          {
                                              new {Id="1",Valor="Mensual"},
                                              new {Id="2",Valor="Semanal"}
                                          },
                                           "Id", "Valor");
                ViewBag.MsjError = "";

                if (param.Tipo > 0)
                {
                    ViewBag.Results = (IEnumerable<EstadisticaRanking>)param.Ejecutar(new EstadisticaRanking()); ;
                }
                else
                {
                    ViewBag.MsjError = "Seleccione un Tipo";
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