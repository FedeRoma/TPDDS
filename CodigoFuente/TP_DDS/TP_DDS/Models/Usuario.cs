using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace TP_DDS.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public String Pass { get; set; }
        public String Email { get; set; }
        public String Nombre { get; set; }
        public int SexoId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
	    public DateTime FechaNacimiento { get; set; }

        public DateTime FechaAltaPerfil { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal Peso { get; set; }

        public decimal Altura { get; set; }
	    public int RutinaId { get; set; }
        public int CondicionPreexistenteId { get; set; }
        public int ComplexionId { get; set; }
        public int DietaId { get; set; }

        public virtual CondicionPreexistente CondicionPreexistente { get; set; }
        public virtual Complexion Complexion { get; set; }
        public virtual Dieta Dieta { get; set; }
        public virtual Sexo Sexo { get; set; }
        public virtual Rutina Rutina { get; set; }

        public virtual ICollection<Preferencia> Preferencias { get; set; }
        public virtual ICollection<Receta> Recetas { get; set; }
        public virtual ICollection<Grupo> Grupos { get; set; }
        //public virtual ICollection<Grupo> GruposUnidos { get; set; }
    }
}
