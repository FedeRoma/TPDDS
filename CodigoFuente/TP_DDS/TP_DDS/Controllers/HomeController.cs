﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP_DDS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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