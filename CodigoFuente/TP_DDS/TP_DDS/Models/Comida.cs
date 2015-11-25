using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class Comida
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
	    public DateTime Fecha { get; set; }
        public int ClasificacionId { get; set; }
        public bool Eliminada { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Clasificacion Clasificacion { get; set; }

        public virtual ICollection<ComidaReceta> Recetas { get; set; }
    }
}
