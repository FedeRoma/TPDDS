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

namespace TP_DDS.Models
{
    public class UsuarioRecomendarVisitor : IUsuarioVisitor
    {
        private IEnumerable<Recomendacion> Recomendaciones;

        private TPDDSContext db = new TPDDSContext();

        public void Visit(Celiaco usuario)
        {
            Recomendaciones = db.Recomendaciones
                .Include(r => r.CondicionPreexistente)
                .Where(r => r.CondicionPreexistente.Nombre.Equals("Celíasis"));
        }

        public void Visit(Diabetico usuario)
        {
            Recomendaciones = db.Recomendaciones
                .Include(r => r.CondicionPreexistente)
                .Where(r => r.CondicionPreexistente.Nombre.Equals("Diabetes"));
        }

        public void Visit(Hipertenso usuario)
        {
            Recomendaciones = db.Recomendaciones
                .Include(r => r.CondicionPreexistente)
                .Where(r => r.CondicionPreexistente.Nombre.Equals("Hipertensión"));
        }

        public IEnumerable<Recomendacion> MostrarRecomendaciones()
        {
            return Recomendaciones;
        }
    }
}