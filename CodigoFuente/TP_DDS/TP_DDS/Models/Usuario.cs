using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public String Nombre { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public String Pass { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme su Contraseña")]
        public string ConfirmPass { get; set; }

        public int SexoId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
	    public DateTime FechaNacimiento { get; set; }

        public DateTime FechaAltaPerfil { get; set; }

        public int Peso { get; set; }
        public int Altura { get; set; }
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
    }
}
