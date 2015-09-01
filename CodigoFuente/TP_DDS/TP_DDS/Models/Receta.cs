﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Models
{
    public class Receta
    {
        public string Nombre { get; set; }
        public int Dificultad { get; set; }
        public double TotalCalorias { get; set; }
        public string SectorPiramide { get; set; }
        public Usuario Creador { get; set; }
        public ICollection<IngredienteReceta> Ingredientes { get; set; }
        public ICollection<Condimento> Condimentos { get; set; }
        public ICollection<Procedimiento> Procedimientos { get; set; }
        public ICollection<Temporada> Temporadas { get; set; }
        public ICollection<Calificacion> Calificacion { get; set; }
        public ICollection<Clasificacion> Clasificacion { get; set; }

        public Receta()
        {
            Initialize();
        }

        public Receta(string nombre, int dificultad, int totalCalorias, string sectorPiramide, Usuario creador)
        {
		    Initialize();
		    Nombre = nombre;
		    Dificultad = dificultad;
		    TotalCalorias = totalCalorias;
            SectorPiramide = sectorPiramide;
		    Creador = creador;
            Calificacion = null;
            Clasificacion = null;
	    }

        public Receta(string nombre, int dificultad, int totalCalorias, string sectorPiramide) 
        {
		    Initialize();
            Nombre = nombre;
            Dificultad = dificultad;
            TotalCalorias = totalCalorias;
            SectorPiramide = sectorPiramide;
		    Creador = null;
            Calificacion = null;
            Clasificacion = null;
	    }

	    public void Initialize() 
        {
            //Ingredientes = new List<IngredienteReceta>();
            //Condimentos = new List<Condimento>();
            //Procedimientos = new List<Procedimiento>();
            //Temporadas = new List<Temporada>();
	    }

        public void Clasificar(Clasificacion clasificacion) 
        {
            Clasificacion.Add(clasificacion);
        }

        public void Calificar(Calificacion calificacion)
        {
            Calificacion.Add(calificacion);
        }

        public void AgregarIngrediente(IngredienteReceta ingrediente)
        {
            Ingredientes.Add(ingrediente);
        }

        public void QuitarIngrediente(IngredienteReceta ingrediente)
        {
            Ingredientes.Remove(ingrediente);
        }

        public void AgregarCondimento(Condimento condimento)
        {
            Condimentos.Add(condimento);
        }

        public void QuitarCondimento(Condimento condimento)
        {
            Condimentos.Remove(condimento);
        }

        public void AgregarProcedimiento(Procedimiento procedimiento)
        {
            Procedimientos.Add(procedimiento);
        }

        public void QuitarProcedimiento(Procedimiento procedimiento)
        {
            Procedimientos.Remove(procedimiento);
        }

        public void AgregarTemporada(Temporada temporada)
        {
            Temporadas.Add(temporada);
        }

        public void QuitarTemporada(Temporada temporada)
        {
            Temporadas.Remove(temporada);
        }

        public bool TienePermisoVisibilidad(Usuario usuario)
        {
            return (Creador == usuario || Creador == null || usuario.ComparteGrupoCon(Creador));
        }

        public void ValidarReceta()
        {
            if (Ingredientes.Count == 0 || TotalCalorias < 10 || TotalCalorias > 5000)
                throw new BusinessException("La receta no puede ser agregada");
        }

        public void ValidarVisibilidad(Usuario usuario) 
        {
            if (!TienePermisoVisibilidad(usuario))
                throw new BusinessException("El usuario no puede ver esta receta");
	    }

        public void ValidarModificabilidad(Usuario usuario)
        {
            if (!(Creador == usuario || Creador == null))
                throw new BusinessException("El usuario no puede modificar esta receta");
        }

        public void Modificar(Receta receta)
        {
            ActualizarReceta(receta);
        }

        public void ActualizarReceta(Receta receta) 
        {
		    Initialize();
		    
            if(receta.Nombre != null) 
                Nombre = receta.Nombre;

		    if(receta.Dificultad != 0) 
                Dificultad = receta.Dificultad;

            if(receta.Creador != null) 
                Creador = receta.Creador;

            TotalCalorias = receta.TotalCalorias;
	    }
    }
}
