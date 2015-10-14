using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class Procedimiento
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }

        public int RecetaId { get; set; }
        public virtual Receta Receta { get; set; }

        //public Procedimiento(int numero, string nombre, string imagen)
        //{
        //    Numero = numero;
        //    Nombre = nombre;
        //    Imagen = imagen;
        //}
    }
}
