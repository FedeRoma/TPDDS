using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Domain
{
    public class Procedimiento
    {
        public int Numero { get; protected set; }
        public string Nombre { get; protected set; }
        public string Imagen { get; protected set; }

        public Procedimiento(int numero, string nombre, string imagen)
        {
            Numero = numero;
            Nombre = nombre;
            Imagen = imagen;
        }
    }
}
