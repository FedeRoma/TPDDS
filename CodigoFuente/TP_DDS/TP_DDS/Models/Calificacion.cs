using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Models
{
    public class Calificacion
    {
        public int Valor { get; set; }
        public Usuario Usuario { get; set; }

        public Calificacion(int valor, Usuario usuario)
        {
            Valor = valor;
            Usuario = usuario;
        }
    }
}
