using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class Receta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Dificultad { get; set; }
        public float TotalCalorias { get; set; }

        public int PiramideId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Creador { get; set; }
        public virtual PiramideAlimenticia Piramide { get; set; }

        public virtual ICollection<Temporada> Temporadas { get; set; }
        public virtual ICollection<Calificacion> Calificaciones { get; set; }
        public virtual ICollection<Clasificacion> Clasificaciones { get; set; }

        public virtual ICollection<IngredienteReceta> Ingredientes { get; set; }
        public virtual ICollection<Condimento> Condimentos { get; set; }
        public virtual ICollection<Procedimiento> Procedimientos { get; set; }




        //public Receta()
        //{
        //    Initialize();
        //}

        //public Receta(string nombre, int dificultad, int totalCalorias, string sectorPiramide, Usuario creador)
        //{
        //    Initialize();
        //    Nombre = nombre;
        //    Dificultad = dificultad;
        //    TotalCalorias = totalCalorias;
        //    SectorPiramide = sectorPiramide;
        //    Creador = creador;
        //    Calificacion = null;
        //    Clasificacion = null;
        //}

        //public Receta(string nombre, int dificultad, int totalCalorias, string sectorPiramide) 
        //{
        //    Initialize();
        //    Nombre = nombre;
        //    Dificultad = dificultad;
        //    TotalCalorias = totalCalorias;
        //    SectorPiramide = sectorPiramide;
        //    Creador = null;
        //    Calificacion = null;
        //    Clasificacion = null;
        //}

        //public void Initialize() 
        //{
        //    //Ingredientes = new List<IngredienteReceta>();
        //    //Condimentos = new List<Condimento>();
        //    //Procedimientos = new List<Procedimiento>();
        //    //Temporadas = new List<Temporada>();
        //}

        //public void Clasificar(Clasificacion clasificacion) 
        //{
        //    Clasificacion.Add(clasificacion);
        //}

        //public void Calificar(Calificacion calificacion)
        //{
        //    Calificacion.Add(calificacion);
        //}

        //public void AgregarIngrediente(IngredienteReceta ingrediente)
        //{
        //    Ingredientes.Add(ingrediente);
        //}

        //public void QuitarIngrediente(IngredienteReceta ingrediente)
        //{
        //    Ingredientes.Remove(ingrediente);
        //}

        //public void AgregarCondimento(Condimento condimento)
        //{
        //    Condimentos.Add(condimento);
        //}

        //public void QuitarCondimento(Condimento condimento)
        //{
        //    Condimentos.Remove(condimento);
        //}

        //public void AgregarProcedimiento(Procedimiento procedimiento)
        //{
        //    Procedimientos.Add(procedimiento);
        //}

        //public void QuitarProcedimiento(Procedimiento procedimiento)
        //{
        //    Procedimientos.Remove(procedimiento);
        //}

        //public void AgregarTemporada(Temporada temporada)
        //{
        //    Temporadas.Add(temporada);
        //}

        //public void QuitarTemporada(Temporada temporada)
        //{
        //    Temporadas.Remove(temporada);
        //}

        //public bool TienePermisoVisibilidad(Usuario usuario)
        //{
        //    return (Creador == usuario || Creador == null || usuario.ComparteGrupoCon(Creador));
        //}

        //public void ValidarReceta()
        //{
        //    if (Ingredientes.Count == 0 || TotalCalorias < 10 || TotalCalorias > 5000)
        //        throw new BusinessException("La receta no puede ser agregada");
        //}

        //public void ValidarVisibilidad(Usuario usuario) 
        //{
        //    if (!TienePermisoVisibilidad(usuario))
        //        throw new BusinessException("El usuario no puede ver esta receta");
        //}

        //public void ValidarModificabilidad(Usuario usuario)
        //{
        //    if (!(Creador == usuario || Creador == null))
        //        throw new BusinessException("El usuario no puede modificar esta receta");
        //}

        //public void Modificar(Receta receta)
        //{
        //    ActualizarReceta(receta);
        //}

        //public void ActualizarReceta(Receta receta) 
        //{
        //    Initialize();
		    
        //    if(receta.Nombre != null) 
        //        Nombre = receta.Nombre;

        //    if(receta.Dificultad != 0) 
        //        Dificultad = receta.Dificultad;

        //    if(receta.Creador != null) 
        //        Creador = receta.Creador;

        //    TotalCalorias = receta.TotalCalorias;
        //}
    }
}
