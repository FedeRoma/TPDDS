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
    
    public partial class ClasificacionReceta
    {
        public ClasificacionReceta()
        {
            this.Receta = new HashSet<Receta>();
        }
    
        public int IdClasificacion { get; set; }
        public string IdReceta { get; set; }
    
        public virtual Calificacion Calificacion { get; set; }
        public virtual ICollection<Receta> Receta { get; set; }
    }
}
