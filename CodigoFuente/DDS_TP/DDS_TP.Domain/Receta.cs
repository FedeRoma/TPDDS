using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDS_TP.Domain.Repositorios;
using DDS_TP.Domain.Condiciones;

namespace DDS_TP.Domain
{
    public class Receta
    {
        public string Nombre { get; protected set; }
        public string Preparacion { get; protected set; }
        public string Dificultad { get; protected set; }
        public int TotalCalorias { get; protected set; }
        public Usuario Creador { get; set; }
        public List<Ingrediente> Ingredientes { get; protected set; }
        public List<string> Temporadas { get; protected set; }
        public List<Receta> Subrecetas { get; protected set; }

        public Receta()
        {
        }
        
        public Receta(string nombre, string preparacion, string dificultad, int totalCalorias, Usuario creador) 
        {
		    Initialize();
		    Nombre = nombre;
		    Preparacion = preparacion;
		    Dificultad = dificultad;
		    TotalCalorias = totalCalorias;
		    Creador = creador;
	    }

        public Receta(string nombre, string preparacion, string dificultad, int totalCalorias) 
        {
		    Initialize();
		    Nombre = nombre;
		    Preparacion = preparacion;
		    Dificultad = dificultad;
		    TotalCalorias = totalCalorias;
		    Creador = null;
	    }

	    public void Initialize() 
        {
		    Ingredientes = new List<Ingrediente>();
		    Temporadas = new List<String>();
            Subrecetas = new List<Receta>();
	    }

        public bool TienePermisoVisibilidad(Usuario usuario)
        {
            return (Creador == usuario || Creador == null || usuario.ComparteGrupoCon(Creador));
        }

        public List<CondicionPreexistente> InadecuadoPara()
        {
            return RepositorioCondiciones.Instance.GetAll()
                        .Where(condicion => condicion.EsInadecuadoPara(this))
                        .Distinct().ToList();
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
            PisarReceta(receta);
        }

        public void PisarReceta(Receta receta) 
        {
		    Initialize();
		    
            if(receta.Nombre != null) 
                Nombre = receta.Nombre;

		    if(receta.Preparacion != null) 
                Preparacion = receta.Preparacion;

		    if(receta.Dificultad != null) 
                Dificultad = receta.Dificultad;

            if(receta.Creador != null) 
                Creador = receta.Creador;

            TotalCalorias = receta.TotalCalorias;
	    }

        internal bool contieneIngrediente(string p)
        {
            throw new NotImplementedException();
        }

        internal bool ContieneIngredienteCantidadMayor(string p1, int p2)
        {
            throw new NotImplementedException();
        }

        internal void puedeSerModificadaPor(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        internal void serModificada(Receta nuevaReceta)
        {
            throw new NotImplementedException();
        }
    }
}
