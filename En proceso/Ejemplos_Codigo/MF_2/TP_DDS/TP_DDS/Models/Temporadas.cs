//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TP_DDS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Temporadas
    {
        public Temporadas()
        {
            this.Recetas = new HashSet<Recetas>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
    
        public virtual ICollection<Recetas> Recetas { get; set; }
    }
}
