using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DDS.Models
{
    public class UsuarioViewModel
    {
        public Usuario Usuario { get; set; }
        public List<UsuarioPreferenciasViewModel> PreferenciasList { get; set; }
    }

    public class UsuarioPreferenciasViewModel
    {
        public bool Sel { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}