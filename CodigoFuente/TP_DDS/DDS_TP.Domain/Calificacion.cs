using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Domain
{
    public class Calificacion
    {
        public int Valor { get; protected set; }

        public Calificacion(int valor)
        {
            Valor = valor;
        }
    }
}
