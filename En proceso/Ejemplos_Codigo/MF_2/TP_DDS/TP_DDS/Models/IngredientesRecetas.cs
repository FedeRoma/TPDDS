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
    
    public partial class IngredientesRecetas
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public Nullable<int> Tipo { get; set; }
        public int IngredienteId { get; set; }
        public int RecetaId { get; set; }
    
        public virtual Ingredientes Ingredientes { get; set; }
        public virtual Recetas Recetas { get; set; }
    }
}
