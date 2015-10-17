using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Sexo? Sexo { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
	    public DateTime FechaNacimiento { get; set; }
        public DateTime FechaAltaPerfil { get; set; }
        public decimal? Altura { get; set; }
	    public Rutina? Rutina { get; set; }
        public int? CondicionPreexistenteId { get; set; }
        public int ComplexionId { get; set; }
        public int DietaId { get; set; }

        public virtual CondicionPreexistente CondicionPreexistente { get; set; }
        public virtual Complexion Complexion { get; set; }
        public virtual Dieta Dieta { get; set; }

        public virtual ICollection<Preferencia> Preferencias { get; set; }
        public virtual ICollection<Receta> Recetas { get; set; }
        public virtual ICollection<Grupo> Grupos { get; set; }


        //private List<ValidacionUsuario> validaciones;
	    
        //public Usuario() 
        //{
        //    Initialize();
        //}

        //public Usuario(String nombre, String sexo, Rutina rutina, double peso, double altura, DateTime fechaNacimiento, int condicionPreexistenteId) 
        //{
        //    Initialize();
        //    this.Nombre = nombre;
        //    this.Sexo = sexo;
        //    this.Rutina = rutina;
        //    this.Peso = peso;
        //    this.Altura = altura;
        //    this.FechaNacimiento = fechaNacimiento;
        //    this.CondicionPreexistenteId = condicionPreexistenteId;
        //}

        //public void Initialize() 
        //{
        //    //PreferenciasAlimenticias = new List<Preferencia>();
        //    validaciones = new List<ValidacionUsuario>();
        //    //Recetas = new List<Receta>();
        //    //Grupos = new List<Grupo>();

        //    CargarValidadores();
        //}

        //private void CargarValidadores()
        //{
        //    validaciones.Add(new ValidacionDatos());
        //    validaciones.Add(new ValidacionFechaNacimiento());
        //    validaciones.Add(new ValidacionNombre());
        //}
	
        //public void Validar() 
        //{
        //    validaciones.ForEach(validacion => validacion.Validar(this));
        //}		
	
        //public void AgregarReceta(Receta receta)
        //{
        //    receta.ValidarReceta();
            
        //    receta.Creador = this;
        //    Recetas.Add(receta);
        //}

        //public void AgregarPreferencia(Preferencia preferencia)
        //{
        //    PreferenciasAlimenticias.Add(preferencia);
        //}

        //public void QuitarPreferencia(Preferencia preferencia)
        //{
        //    PreferenciasAlimenticias.Remove(preferencia);
        //}
	
        //public void AgregarGrupo(Grupo grupo)
        //{
        //    Grupos.Add(grupo);
        //    grupo.agregameALista(this);
        //}

        //public bool ComparteGrupoCon(Usuario creadorReceta)
        //{
        //    //return Grupos.Exists(grupo => grupo.perteneceUsuarioAlGrupo(creadorReceta));
        //    throw new NotImplementedException();
        //}

        //public void ActualizarPerfil(String nombre, Sexo sexo, Rutina rutina, double peso, double altura, DateTime fechaNacimiento)
        //{
        //    this.Rutina = rutina;
        //    this.Peso = peso;
        //    this.Altura = altura;
        //}
    }
}
