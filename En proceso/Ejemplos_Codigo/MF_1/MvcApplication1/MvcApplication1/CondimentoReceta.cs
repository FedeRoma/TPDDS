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
    
    public partial class CondimentoReceta
    {
        public CondimentoReceta()
        {
            this.Receta = new HashSet<Receta>();
            this.Condimento = new HashSet<Condimento>();
        }
    
        public int IdReceta { get; set; }
        public string IdCondimento { get; set; }
    
        public virtual ICollection<Receta> Receta { get; set; }
        public virtual ICollection<Condimento> Condimento { get; set; }
    }
}
