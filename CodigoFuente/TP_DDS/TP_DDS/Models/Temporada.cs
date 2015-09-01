using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Models
{
    public class Temporada
    {
        public string Nombre { get; set; }

        public Temporada(string nombre)
        {
            Nombre = nombre;
        }
    }
}
