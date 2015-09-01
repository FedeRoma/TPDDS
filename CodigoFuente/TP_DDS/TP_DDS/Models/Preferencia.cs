using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Models
{
    public class Preferencia
    {
        public String Nombre { get; set; }

        public Preferencia(string nombre)
        {
            Nombre = nombre;
        }
    }
}
