//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsuarioPreferencia
    {
        public UsuarioPreferencia()
        {
            this.Usuario = new HashSet<Usuario>();
            this.Preferencia = new HashSet<Preferencia>();
        }
    
        public int IdUsuario { get; set; }
        public string idPreferencia { get; set; }
    
        public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual ICollection<Preferencia> Preferencia { get; set; }
    }
}
