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
    
    public partial class Procedimientos
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public int RecetaId { get; set; }
    
        public virtual Recetas Recetas { get; set; }
    }
}
