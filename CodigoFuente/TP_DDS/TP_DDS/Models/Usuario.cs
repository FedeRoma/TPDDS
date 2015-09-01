using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public String Pass { get; set; }
        public String Email { get; set; }
        public String Nombre { get; set; }
        public String Sexo { get; set; }
	    public DateTime FechaNacimiento { get; set; }
        public DateTime FechaAltaPerfil { get; set; }
	    public double Peso { get; set; }
	    public double Altura { get; set; }
	    public Rutina? Rutina { get; set; }
        public CondicionPreexistente CondicionPreexistente { get; set; }
        public ICollection<Dieta> Dieta { get; set; }
        public ICollection<Preferencia> PreferenciasAlimenticias { get; set; }
        public ICollection<Receta> Recetas { get; set; }
        public ICollection<Grupo> Grupos { get; set; }

        private List<ValidacionUsuario> validaciones;
	    
	    public Usuario() 
        {
		    Initialize();
	    }

        public Usuario(String nombre, String sexo, Rutina rutina, double peso, double altura, DateTime fechaNacimiento, CondicionPreexistente condicionPreexistente) 
        {
		    Initialize();
		    this.Nombre = nombre;
		    this.Sexo = sexo;
		    this.Rutina = rutina;
		    this.Peso = peso;
		    this.Altura = altura;
		    this.FechaNacimiento = fechaNacimiento;
            this.CondicionPreexistente = condicionPreexistente;
	    }

	    public void Initialize() 
        {
            //PreferenciasAlimenticias = new List<Preferencia>();
            validaciones = new List<ValidacionUsuario>();
            //Recetas = new List<Receta>();
            //Grupos = new List<Grupo>();

            CargarValidadores();
	    }

        private void CargarValidadores()
        {
            validaciones.Add(new ValidacionDatos());
            validaciones.Add(new ValidacionFechaNacimiento());
            validaciones.Add(new ValidacionNombre());
        }
	
	    public void Validar() 
        {
		    validaciones.ForEach(validacion => validacion.Validar(this));
	    }		
	
	    public void AgregarReceta(Receta receta)
        {
		    receta.ValidarReceta();
            
            receta.Creador = this;
            Recetas.Add(receta);
	    }

	    public void AgregarPreferencia(Preferencia preferencia)
        {
            PreferenciasAlimenticias.Add(preferencia);
	    }

        public void QuitarPreferencia(Preferencia preferencia)
        {
            PreferenciasAlimenticias.Remove(preferencia);
        }
	
	    public void AgregarGrupo(Grupo grupo)
        {
		    Grupos.Add(grupo);
		    grupo.agregameALista(this);
	    }

        public bool ComparteGrupoCon(Usuario creadorReceta)
        {
            //return Grupos.Exists(grupo => grupo.perteneceUsuarioAlGrupo(creadorReceta));
            throw new NotImplementedException();
        }

        public void ActualizarPerfil(String nombre, Sexo sexo, Rutina rutina, double peso, double altura, DateTime fechaNacimiento)
        {
            this.Rutina = rutina;
            this.Peso = peso;
            this.Altura = altura;
        }
    }
}
