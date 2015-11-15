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
    public class EstadisticasController : Controller
    {
        //
        // GET: /Estadisticas/PorSexo
        public ActionResult PorSexo([Bind(Include = "Tipo")] Estadistica param)
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

            if (param.Tipo > 0)
            {
                ViewBag.Results = (IEnumerable<EstadisticaSexo>)param.Ejecutar(new EstadisticaSexo()); ;
            }

            return View(viewModel);
        }

        //
        // GET: /Estadisticas/PorDificultad
        public ActionResult PorDificultad([Bind(Include = "Tipo")] Estadistica param)
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

            if (param.Tipo > 0)
            {
                ViewBag.Results = (IEnumerable<EstadisticaDificultad>)param.Ejecutar(new EstadisticaDificultad()); ;
            }

            return View(viewModel);
        }

        //
        // GET: /Estadisticas/Ranking
        public ActionResult Ranking([Bind(Include = "Tipo")] Estadistica param)
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

            if (param.Tipo > 0)
            {
                ViewBag.Results = (IEnumerable<EstadisticaRanking>)param.Ejecutar(new EstadisticaRanking()); ;
            }

            return View(viewModel);
        }
	}
}