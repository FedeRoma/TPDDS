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
    
    public partial class Usuarios
    {
        public Usuarios()
        {
            this.Calificaciones = new HashSet<Calificaciones>();
            this.Grupos = new HashSet<Grupos>();
            this.Recetas = new HashSet<Recetas>();
            this.Preferencias = new HashSet<Preferencias>();
        }
    
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public System.DateTime FechaAltaPerfil { get; set; }
        public decimal Altura { get; set; }
        public int CondicionPreexistenteId { get; set; }
        public int ComplexionId { get; set; }
        public int DietaId { get; set; }
        public int SexoId { get; set; }
        public int RutinaId { get; set; }
        public Nullable<decimal> Peso { get; set; }
    
        public virtual ICollection<Calificaciones> Calificaciones { get; set; }
        public virtual Complexiones Complexiones { get; set; }
        public virtual CondicionesPreexistentes CondicionesPreexistentes { get; set; }
        public virtual Dietas Dietas { get; set; }
        public virtual ICollection<Grupos> Grupos { get; set; }
        public virtual ICollection<Recetas> Recetas { get; set; }
        public virtual Rutinas Rutinas { get; set; }
        public virtual Sexo Sexo { get; set; }
        public virtual ICollection<Preferencias> Preferencias { get; set; }
    }
}