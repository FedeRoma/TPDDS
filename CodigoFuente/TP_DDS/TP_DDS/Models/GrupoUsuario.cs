using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class GrupoUsuario
    {
        public int Id { get; set; }
        public int GrupoId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Grupo Grupo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}