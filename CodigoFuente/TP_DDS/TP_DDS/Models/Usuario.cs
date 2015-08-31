using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Models
{
    public class Usuario
    {
        public String UserName { get; protected set; }
        public String Pass { get; protected set; }
        public String Email { get; protected set; }
        public String Nombre { get; protected set; }
	    public Sexo? Sexo { get; protected set; }
	    public DateTime FechaNacimiento { get; protected set; }
        public DateTime FechaAltaPerfil { get; protected set; }
	    public double Peso { get; protected set; }
	    public double Altura { get; protected set; }
	    public Rutina? Rutina { get; protected set; }
        public List<Dieta> Dieta { get; protected set; }
        public List<Preferencia> PreferenciasAlimenticias { get; protected set; }
	    public List<CondicionPreexistente> CondicionesPreexistentes { get; protected set; }
	    public List<Receta> Recetas { get; protected set; }
	    public List<Grupo> Grupos { get; protected set; }

        private List<ValidacionUsuario> validaciones;
	    
	    public Usuario() 
        {
		    Initialize();
	    }

	    public Usuario(String nombre, Sexo sexo, Rutina rutina, double peso, double altura, DateTime fechaNacimiento) 
        {
		    Initialize();
		    this.Nombre = nombre;
		    this.Sexo = sexo;
		    this.Rutina = rutina;
		    this.Peso = peso;
		    this.Altura = altura;
		    this.FechaNacimiento = fechaNacimiento;
	    }

	    public void Initialize() 
        {
            PreferenciasAlimenticias = new List<Preferencia>();
		    CondicionesPreexistentes = new List<CondicionPreexistente>();
            validaciones = new List<ValidacionUsuario>();
		    Recetas = new List<Receta>();
		    Grupos = new List<Grupo>();

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

	    public void AgregarCondicion(CondicionPreexistente condicionPreexistente)
        {
		    CondicionesPreexistentes.Add(condicionPreexistente);
	    }
	
	    public void AgregarGrupo(Grupo grupo)
        {
		    Grupos.Add(grupo);
		    grupo.agregameALista(this);
	    }

        public bool ComparteGrupoCon(Usuario creadorReceta)
        {
            return Grupos.Exists(grupo => grupo.perteneceUsuarioAlGrupo(creadorReceta));
        }

        public void ActualizarPerfil(String nombre, Sexo sexo, Rutina rutina, double peso, double altura, DateTime fechaNacimiento)
        {
            this.Rutina = rutina;
            this.Peso = peso;
            this.Altura = altura;
        }
    }
}
