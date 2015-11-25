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
        public string Comentario { get; set; }
        public DateTime FechaHora { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Receta Receta { get; set; }
    }
}
