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
using System.Collections;

namespace TP_DDS.Controllers
{
    public class ReportesController : BaseController
    {
        private TPDDSContext db = new TPDDSContext();

        //
        // GET: /Reportes/
        public ActionResult Index()
        {
            string userEmail = User.Identity.GetUserName();

            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        //
        // GET: /Reportes/RecetasPorPeriodo
        public ActionResult RecetasPorPeriodo(Reporte param)
        {
            string userEmail = User.Identity.GetUserName();

            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Index", "Home");
            }

            Usuario usuario = db.Usuarios.FirstOrDefault
                (u => u.Email.Equals(userEmail));

            var viewModel = new Reporte();

            if (param.FiltroIni != null)
            {
                string[] arrini = ((IEnumerable)param.FiltroIni).Cast<object>()
                     .Select(x => x.ToString())
                     .ToArray();

                string[] arrfin = ((IEnumerable)param.FiltroFin).Cast<object>()
                         .Select(x => x.ToString())
                         .ToArray();

                if (string.IsNullOrEmpty(arrini[0]))
                {
                    ViewBag.MsjErrorIni = "Seleccione una fecha.";
                    return View(viewModel);
                }

                if (string.IsNullOrEmpty(arrfin[0]))
                {
                    ViewBag.MsjErrorFin = "Seleccione una fecha.";
                    return View(viewModel);
                }

                DateTime fechaIni = DateTime.Parse(arrini[0]);
                DateTime fechaFin = DateTime.Parse(arrfin[0]);

                if (fechaIni > fechaFin)
                {
                    ViewBag.MsjErrorMayor = "La fecha inicial no puede ser mayor a la final.";
                    return View(viewModel);
                }

                param.UsuarioId = usuario.Id;
                ViewBag.Results = (IEnumerable<RptRecetasPorPeriodo>)param.Ejecutar(new RptRecetasPorPeriodo());
            }

            return View(viewModel);
        }

        //
        // GET: /Reportes/RecetasNuevas
        public ActionResult RecetasNuevas(Reporte param)
        {
            string userEmail = User.Identity.GetUserName();

            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Index", "Home");
            }

            Usuario usuario = db.Usuarios.FirstOrDefault
                (u => u.Email.Equals(userEmail));

            var viewModel = new Reporte();

            param.UsuarioId = usuario.Id;
            param.FiltroIni = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            param.FiltroFin = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.Results = (IEnumerable<RptRecetasNuevas>)param.Ejecutar(new RptRecetasNuevas());

            return View(viewModel);
        }

        //
        // GET: /Reportes/RecetasPorCalorias
        public ActionResult RecetasPorCalorias(Reporte param)
        {
            string userEmail = User.Identity.GetUserName();

            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Index", "Home");
            }

            Usuario usuario = db.Usuarios.FirstOrDefault
                (u => u.Email.Equals(userEmail));

            var viewModel = new Reporte();
            viewModel.FiltroIni = 1;
            viewModel.FiltroFin = 1500;

            if (param.FiltroIni != null)
            {
                string[] arrini = ((IEnumerable)param.FiltroIni).Cast<object>()
                         .Select(x => x.ToString())
                         .ToArray();

                string[] arrfin = ((IEnumerable)param.FiltroFin).Cast<object>()
                         .Select(x => x.ToString())
                         .ToArray();

                if (string.IsNullOrEmpty(arrini[0]))
                {
                    ViewBag.MsjErrorIni = "Ingrese un Valor.";
                    return View(viewModel);
                }

                if (string.IsNullOrEmpty(arrfin[0]))
                {
                    ViewBag.MsjErrorFin = "Ingrese un Valor.";
                    return View(viewModel);
                }

                int caloriasMin = Convert.ToInt32(arrini[0]);
                int caloriasMax = Convert.ToInt32(arrfin[0]);

                if (caloriasMin > caloriasMax)
                {
                    ViewBag.MsjErrorMayor = "Las Calorias Min. no pueden ser Mayor que las Max.";
                    return View(viewModel);
                }

                ViewBag.Results = (IEnumerable<RptRecetasPorCalorias>)param.Ejecutar(new RptRecetasPorCalorias());
            }

            return View(viewModel);
        }
	}
}