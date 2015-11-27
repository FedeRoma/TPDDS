using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class Preferencia
    {
        public int Id { get; set; }
        public String Nombre { get; set; }

        [NotMapped]
        public bool Sel { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Grupo> Grupos { get; set; }
        public virtual ICollection<Dieta> Dietas { get; set; }
    }
}
