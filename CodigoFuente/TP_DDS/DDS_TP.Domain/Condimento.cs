using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Domain
{
    public class Condimento
    {
        public string Nombre { get; protected set; }
        public string Tipo { get; protected set; }

        public Condimento(string nombre, string tipo)
        {
            Nombre = nombre;
            Tipo = tipo;
        }
    }
}
