using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Models
{
    public class Dieta
    {
        public String Nombre { get; protected set; }

        public Dieta(string nombre)
        {
            Nombre = nombre;
        }
    }
}
