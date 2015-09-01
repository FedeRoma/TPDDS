using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Models
{
    public class Procedimiento
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }

        public Procedimiento(int numero, string nombre, string imagen)
        {
            Numero = numero;
            Nombre = nombre;
            Imagen = imagen;
        }
    }
}
