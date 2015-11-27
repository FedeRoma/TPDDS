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
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;


namespace TP_DDS.Models
{
    public class UsuarioProponerVisitor : IUsuarioVisitor
    {
        private IEnumerable<Receta> Recetas = new List<Receta>();
        private TPDDSContext db = new TPDDSContext();

        public void Visit(Celiaco usuario)
        {
            //Recetas con esas preferencias
            List<int> recetasIDs = db.IngredientesRecetas.Include(i => i.Ingrediente)
                .Where(i => i.Ingrediente.Nombre.Equals("Harina"))
                .ToList().Select(i => i.RecetaId).Distinct().ToList<int>();

            //obtenemos las recetas
            Recetas = db.Recetas.Include(r => r.Dificultad)
            .Include(r => r.Creador)
            .Include(r => r.Piramide)
            .Where(r => !r.Eliminada
                && !recetasIDs.Contains(r.Id)
            );
        }

        public void Visit(Diabetico usuario)
        {
            List<string> IngNoPermitidos = new List<string>();
            IngNoPermitidos.Add("Chocolate");
            IngNoPermitidos.Add("Azucar");

            List<string> PrefNoPermitidas = new List<string>();
            PrefNoPermitidas.Add("Cereales");
            PrefNoPermitidas.Add("Frutas");
            PrefNoPermitidas.Add("Pastas");
            PrefNoPermitidas.Add("Carne Roja");

            //Recetas con esas preferencias
            List<int> recetasIDsIng = db.IngredientesRecetas.Include(i => i.Ingrediente)
                .Where(i => IngNoPermitidos.Contains(i.Ingrediente.Nombre))
                .ToList().Select(i => i.RecetaId).Distinct().ToList<int>();

            List<int> recetasIDsPref = db.IngredientesRecetas.Include(i => i.Ingrediente)
                .Where(i => PrefNoPermitidas.Contains(i.Ingrediente.Preferencia.Nombre))
                .ToList().Select(i => i.RecetaId).Distinct().ToList<int>();

            Recetas = db.Recetas.Include(r => r.Dificultad)
                        .Include(r => r.Creador)
                        .Include(r => r.Piramide)
                        .Where(r => !r.Eliminada
                            && !recetasIDsIng.Contains(r.Id)
                            && !recetasIDsPref.Contains(r.Id));
        }

        public void Visit(Hipertenso usuario)
        {
            Recetas = db.Recetas_Hipertensos();
        }

        public IEnumerable<Receta> ProponerRecetas()
        {
            return Recetas;
        }

    }
}