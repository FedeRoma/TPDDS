using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Domain
{
    public class Temporada
    {
        public string Nombre { get; protected set; }

        public Temporada(string nombre)
        {
            Nombre = nombre;
        }
    }
}
