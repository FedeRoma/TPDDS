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
    public class HomeController : BaseController
    {
        private TPDDSContext db = new TPDDSContext();

        public ActionResult Index()
        {
            try
            {
                string userEmail = User.Identity.GetUserName();

                if (!string.IsNullOrEmpty(userEmail))
                {
                    Usuario usuario = db.Usuarios.FirstOrDefault
                        (u => u.Email.Equals(userEmail));

                    ViewBag.Usuario = usuario.Nombre;
                    ViewBag.RecetasNuevas = null;

                    DateTime hoy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                    var comidas = db.ComidasRecetas.Include(c => c.Comida)
                        .Include(c => c.Comida.Clasificacion)
                        .Include(c => c.Comida.Usuario)
                        .Include(c => c.Receta)
                        .Include(c => c.Receta.Dificultad)
                        .Include(c => c.Receta.Piramide)
                        .Include(c => c.Receta.Creador)
                        .Where(c => c.Comida.UsuarioId == usuario.Id
                            && !c.Comida.Eliminada 
                            && !c.Eliminada 
                            //&& !c.Receta.Eliminada
                            && c.Comida.Fecha == hoy);

                    if (comidas.ToList().Count() == 0)
                        ViewBag.ComidasRecetas = null;
                    else
                        ViewBag.ComidasRecetas = comidas.ToList();

                    usuario.CargarCondicion();

                    if (usuario.condicion != null)
                    {
                        UsuarioProponerVisitor upv = new UsuarioProponerVisitor();
                        UsuarioRecomendarVisitor urv = new UsuarioRecomendarVisitor();

                        usuario.condicion.Accept(upv);
                        usuario.condicion.Accept(urv);

                        ViewBag.Propuestas = upv.ProponerRecetas().ToList();
                        ViewBag.Recomendaciones = urv.MostrarRecomendaciones().ToList();
                    }
                    else
                    {
                        if (comidas.ToList().Count() == 0)
                        {
                            Reporte param = new Reporte();
                            param.UsuarioId = usuario.Id;
                            param.FiltroIni = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
                            param.FiltroFin = DateTime.Now.ToString("yyyy-MM-dd");
                            ViewBag.RecetasNuevas = (IEnumerable<RptRecetasNuevas>)param.Ejecutar(new RptRecetasNuevas());
                        }
                    }

                }

                return View();
            }
            catch (Exception)
            {
                Usuario usuario = new Usuario().GetUserByEmail(User.Identity.GetUserName());
                Danger(string.Format("<b>{0}!!</b> Ha ocurrido un Error inesperado. Pronto lo solucionaremos. Intenta mas tarde. Gracias.", usuario.Nombre), true);
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Pagina de Inicio.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Pagina de Contacto.";

            return View();
        }
    }
}