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

            var Preferencias = new List<Preferencia>
            {
            new Preferencia{Id=1,Nombre="Pescados"},
            new Preferencia{Id=2,Nombre="Mariscos"},
            new Preferencia{Id=3,Nombre="Carne Roja"},
            new Preferencia{Id=4,Nombre="Carne de Pollo"},
            new Preferencia{Id=5,Nombre="Vegetales"},
            new Preferencia{Id=6,Nombre="Lacteos"},
            new Preferencia{Id=7,Nombre="Cereales"},
            new Preferencia{Id=8,Nombre="Pastas"}
            };

            Preferencias.ForEach(s => context.Preferencias.Add(s));
            context.SaveChanges();

            var Usuarios = new List<Usuario>
            {
            new Usuario{Id=1,
                        //UserName="Admin", 
                        Pass="1234", 
                        Email="admin@quecomemoshoy.com.ar", 
                        Nombre ="Admin",
                        SexoId=1,
                        FechaNacimiento =DateTime.Parse("1990-01-01"),
                        FechaAltaPerfil = DateTime.Now,
                        Altura = 175,
                        RutinaId = 4,
                        ComplexionId=2,
                        DietaId=1
                        },
            new Usuario{Id=2,
                        //UserName="Juan", 
                        Pass="1234", 
                        Email="juan@quecomemoshoy.com.ar", 
                        Nombre ="Juani Tone",
                        SexoId=1,
                        FechaNacimiento =DateTime.Parse("1990-01-01"),
                        FechaAltaPerfil = DateTime.Now,
                        Altura = 176,
                        RutinaId =4,
                        ComplexionId=2,
                        DietaId=1
                        }
            };

            Usuarios.ForEach(s => context.Usuarios.Add(s));
            context.SaveChanges();

            var Clasificaciones = new List<Clasificacion>
            {
            new Clasificacion{Id=1,Nombre="Almuerzo"},
            new Clasificacion{Id=2,Nombre="Cena"}
            };

            Clasificaciones.ForEach(s => context.Clasificaciones.Add(s));
            context.SaveChanges();

            var Condimentos = new List<Condimento>
            {
            new Condimento{Id=1,Nombre="Sal", Tipo=""},
            new Condimento{Id=2,Nombre="Aceite", Tipo=""},
            new Condimento{Id=3,Nombre="Pimienta", Tipo=""},
            new Condimento{Id=4,Nombre="Vinagre", Tipo=""},
            new Condimento{Id=5,Nombre="Mayonesa", Tipo=""},
            new Condimento{Id=6,Nombre="Oregano", Tipo=""},
            new Condimento{Id=7,Nombre="Romero", Tipo=""},
            new Condimento{Id=8,Nombre="Laurel", Tipo=""},
            new Condimento{Id=9,Nombre="Salsa de Soja", Tipo=""},
            new Condimento{Id=10,Nombre="Vainilla", Tipo=""}
            };

            Condimentos.ForEach(s => context.Condimentos.Add(s));
            context.SaveChanges();

            var Ingredientes = new List<Ingrediente>
            {
            new Ingrediente{Id=1,Nombre="Leche", Porcion=1, CaloriasPorcion=10, PreferenciaId=6},
            new Ingrediente{Id=2,Nombre="Queso", Porcion=1, CaloriasPorcion=20, PreferenciaId=6},
            new Ingrediente{Id=3,Nombre="Papa", Porcion=1, CaloriasPorcion=30, PreferenciaId=5},
            new Ingrediente{Id=4,Nombre="Lechuga", Porcion=1, CaloriasPorcion=40, PreferenciaId=5},
            new Ingrediente{Id=5,Nombre="Tomate", Porcion=1, CaloriasPorcion=50, PreferenciaId=5},
            new Ingrediente{Id=6,Nombre="Arroz", Porcion=1, CaloriasPorcion=60, PreferenciaId=7},
            new Ingrediente{Id=7,Nombre="Fideos", Porcion=1, CaloriasPorcion=70, PreferenciaId=8},
            new Ingrediente{Id=8,Nombre="Atun", Porcion=1, CaloriasPorcion=80, PreferenciaId=1},
            new Ingrediente{Id=9,Nombre="Salmon", Porcion=1, CaloriasPorcion=90, PreferenciaId=1},
            new Ingrediente{Id=10,Nombre="Camaron", Porcion=1, CaloriasPorcion=100, PreferenciaId=2},
            new Ingrediente{Id=11,Nombre="Pulpo", Porcion=1, CaloriasPorcion=110, PreferenciaId=2},
            new Ingrediente{Id=12,Nombre="Vaca", Porcion=1, CaloriasPorcion=120, PreferenciaId=3},
            new Ingrediente{Id=13,Nombre="Cordero", Porcion=1, CaloriasPorcion=130, PreferenciaId=3},
            new Ingrediente{Id=14,Nombre="Pollo", Porcion=1, CaloriasPorcion=140, PreferenciaId=4},
            new Ingrediente{Id=15,Nombre="Pavo", Porcion=1, CaloriasPorcion=150, PreferenciaId=4}
            };

            Ingredientes.ForEach(s => context.Ingredientes.Add(s));
            context.SaveChanges();

            var PiramideAlimenticia = new List<PiramideAlimenticia>
            {
            new PiramideAlimenticia{Id=1,NombreGrupo="Grasas y Azucares", DescripcionGrupo="", Contraindicaciones=""},
            new PiramideAlimenticia{Id=2,NombreGrupo="Lacteos, Leguminosas y Animales", DescripcionGrupo="", Contraindicaciones=""},
            new PiramideAlimenticia{Id=3,NombreGrupo="Frutas y Verduras", DescripcionGrupo="", Contraindicaciones=""},
            new PiramideAlimenticia{Id=4,NombreGrupo="Cereales y Tuberculos", DescripcionGrupo="", Contraindicaciones=""}
            };

            PiramideAlimenticia.ForEach(s => context.PiramideAlimenticia.Add(s));
            context.SaveChanges();

            var Temporadas = new List<Temporada>
            {
            new Temporada{Id=1,Nombre="Verano"},
            new Temporada{Id=2,Nombre="Otoño"},
            new Temporada{Id=3,Nombre="Invierno"},
            new Temporada{Id=4,Nombre="Primavera"},
            new Temporada{Id=3,Nombre="Navidad"},
            new Temporada{Id=4,Nombre="Pascuas"}
            };

            Temporadas.ForEach(s => context.Temporadas.Add(s));
            context.SaveChanges();
        }
    }
}