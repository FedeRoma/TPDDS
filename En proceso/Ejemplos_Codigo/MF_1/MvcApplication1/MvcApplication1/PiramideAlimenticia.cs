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
    
    public partial class PiramideAlimenticia
    {
        public int Id { get; set; }
        public string nombreGrupo { get; set; }
        public string descripcionGrupo { get; set; }
        public string contraindicaciones { get; set; }
    
        public virtual Grupo Grupo { get; set; }
    }
}
