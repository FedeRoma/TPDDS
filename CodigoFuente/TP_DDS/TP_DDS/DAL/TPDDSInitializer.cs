using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TP_DDS.Models;

namespace TP_DDS.DAL
{
    public class TPDDSInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TPDDSContext>
    {
        protected override void Seed(TPDDSContext context)
        {
            var CondicionesPreexistentes = new List<CondicionPreexistente>
            {
            new CondicionPreexistente{Id=1,Nombre="Diabetes"},
            new CondicionPreexistente{Id=2,Nombre="Hipertensión"},
            new CondicionPreexistente{Id=3,Nombre="Celíasis"}
            };

            CondicionesPreexistentes.ForEach(s => context.CondicionesPreexistentes.Add(s));
            context.SaveChanges();

            var Complexiones = new List<Complexion>
            {
            new Complexion{Id=1,Nombre="Pequeña"},
            new Complexion{Id=2,Nombre="Media"},
            new Complexion{Id=3,Nombre="Grande"}
            };

            Complexiones.ForEach(s => context.Complexiones.Add(s));
            context.SaveChanges();

            var Dietas = new List<Dieta>
            {//Normal, Ovolactovegetariano, Vegetariano, Vegano
            new Dieta{Id=1,Nombre="Normal"},
            new Dieta{Id=2,Nombre="Ovolactovegetariano"},
            new Dieta{Id=3,Nombre="Vegetariano"},
            new Dieta{Id=4,Nombre="Vegano"}
            };

            Dietas.ForEach(s => context.Dietas.Add(s));
            context.SaveChanges();

            var Usuarios = new List<Usuario>
            {
            new Usuario{Id=1,
                        UserName="Admin", 
                        Pass="1234", 
                        Email="admi@quecomemoshoy.com.ar", 
                        Nombre ="Admin",
                        Sexo=Sexo.Hombre,
                        FechaNacimiento =DateTime.Parse("1990-01-01"),
                        FechaAltaPerfil = DateTime.Now,
                        Altura = 1.80m,
                        Rutina = Rutina.Activa,
                        ComplexionId=2,
                        DietaId=1
                        }
            };

            Usuarios.ForEach(s => context.Usuarios.Add(s));
            context.SaveChanges();

        }
    }
}