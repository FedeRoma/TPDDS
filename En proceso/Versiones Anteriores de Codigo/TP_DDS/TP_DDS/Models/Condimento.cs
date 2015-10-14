using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class Condimento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Receta> Recetas { get; set; }

        //public Condimento(string nombre, string tipo)
        //{
        //    Nombre = nombre;
        //    Tipo = tipo;
        //}
    }
}
