using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class Temporada
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [NotMapped]
        public bool Sel { get; set; }

        public virtual ICollection<Receta> Recetas { get; set; }

        //public Temporada(string nombre)
        //{
        //    Nombre = nombre;
        //}
    }
}
