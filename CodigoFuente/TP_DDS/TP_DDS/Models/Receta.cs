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
        public int DificultadId { get; set; }
        public decimal TotalCalorias { get; set; }
        public int CalificacionPromedio { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltModif { get; set; }

        public bool Eliminada { get; set; }

        public int PiramideId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Creador { get; set; }
        public virtual PiramideAlimenticia Piramide { get; set; }
        public virtual Dificultad Dificultad { get; set; }

        public virtual ICollection<Temporada> Temporadas { get; set; }
        public virtual ICollection<Calificacion> Calificaciones { get; set; }
        public virtual ICollection<Clasificacion> Clasificaciones { get; set; }

        public virtual ICollection<IngredienteReceta> Ingredientes { get; set; }
        public virtual ICollection<Condimento> Condimentos { get; set; }
        public virtual ICollection<Procedimiento> Procedimientos { get; set; }
    }
}
