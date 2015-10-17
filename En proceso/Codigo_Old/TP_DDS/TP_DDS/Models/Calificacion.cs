using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class Calificacion
    {
        public int Id { get; set; }
        public int RecetaId { get; set; }
        public int Valor { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Receta Receta { get; set; }




        //public Calificacion(int valor, Usuario usuario)
        //{
        //    Valor = valor;
        //    Usuario = usuario;
        //}
    }
}
