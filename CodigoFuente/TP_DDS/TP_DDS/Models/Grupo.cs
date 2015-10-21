using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class Grupo
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Creador { get; set; }
        public virtual ICollection<Preferencia> Preferencias { get; set; }
        //public virtual ICollection<Usuario> UsuariosUnidos { get; set; }
    }
}
