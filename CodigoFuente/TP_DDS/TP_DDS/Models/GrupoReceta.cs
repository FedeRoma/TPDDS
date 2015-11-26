using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class GrupoReceta
    {
        public int Id { get; set; }
        public int GrupoId { get; set; }
        public int RecetaId { get; set; }
        public int UsuarioId { get; set; }
        public bool Eliminada { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? UsuarioBajaId { get; set; }

        public virtual Grupo Grupo { get; set; }
        public virtual Receta Receta { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario UsuarioBaja { get; set; }
    }
}