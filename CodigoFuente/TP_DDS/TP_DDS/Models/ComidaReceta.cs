using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class ComidaReceta
    {
        public int Id { get; set; }
        public int ComidaId { get; set; }
        public int RecetaId { get; set; }
        public bool Eliminada { get; set; }

        public virtual Comida Comida { get; set; }
        public virtual Receta Receta { get; set; }
    }
}
