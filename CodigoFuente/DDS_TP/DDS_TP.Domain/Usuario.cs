using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDS_TP.Domain.Condiciones;
using DDS_TP.Domain.Validaciones;

namespace DDS_TP.Domain
{
    public class Usuario : Sugerenciable
    {
        public String Nombre { get; protected set; }
	    public Sexo? Sexo { get; protected set; }
	    public DateTime FechaNacimiento { get; protected set; }
	    public double Peso { get; protected set; }
	    public double Altura { get; protected set; }
	    public Rutina? Rutina { get; protected set; }
	    public List<string> IngredientesDisgustan { get; protected set; }
	    public List<CondicionPreexistente> CondicionesPreexistentes { get; protected set; }
	    public List<Receta> Recetas { get; protected set; }
	    public List<Receta> Favoritos { get; protected set; }
	    public List<Grupo> Grupos { get; protected set; }

        private List<string> preferencias;
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
		    preferencias = new List<String>();
		    IngredientesDisgustan = new List<string>();
		    CondicionesPreexistentes = new List<CondicionPreexistente>();
            validaciones = new List<ValidacionUsuario>();
		    Recetas = new List<Receta>();
		    Favoritos = new List<Receta>();
		    Grupos = new List<Grupo>();

            CargarValidadores();
	    }

        private void CargarValidadores()
        {
            validaciones.Add(new Validaciones.ValidacionDatos());
            validaciones.Add(new Validaciones.ValidacionDiabetico());
            validaciones.Add(new Validaciones.ValidacionFechaNacimiento());
            validaciones.Add(new Validaciones.ValidacionHipertenso());
            validaciones.Add(new Validaciones.ValidacionNombre());
            validaciones.Add(new Validaciones.ValidacionVegano());
        }

	    public double CalcularIMC() {
		    return Math.Round(Peso / Math.Pow(Altura, 2), 3);
	    }
	
	    public void Validar() 
        {
		    validaciones.ForEach(validacion => validacion.Validar(this));
	    }		

	    public bool SigueRutinaSaludable() 
        {
            return (CalcularIMC() >= 18 && CalcularIMC() <= 30
                    && (NoTieneCondicionPreexistente() || !CondicionesPreexistentes.Exists(condicion => !condicion.PuedeSubsanar(this))) );
	    }

        public bool NoTieneCondicionPreexistente() 
        {
            return CondicionesPreexistentes.Count == 0;
        }
	
	    public void AgregarReceta(Receta receta)
        {
		    receta.ValidarReceta();
            
            receta.Creador = this;
            Recetas.Add(receta);
	    }

	    public void AgregarPreferencia(string preferencia)
        {
		    preferencias.Add(preferencia);
	    }
	
	    public void AgregarIngredienteQueDisgusta(string comida)
        {
		    IngredientesDisgustan.Add(comida);
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
	
	    public void AgregarFavorito(Receta receta)
        {
		    Favoritos.Add(receta);
	    }
	
	    public void QuitarFavorito(Receta receta)
        {
		    Favoritos.Remove(receta);
	    }
	
        //public Usuario GetCreador()
        //{
        //    return creador;
        //}
	
	    public bool EsSugerible(Receta receta) 
        {
		    return EsSugeriblePorDisgusto(receta) && EsSugeriblePorCondicionPreExistente(receta);
	    }
	
	    private bool EsSugeriblePorCondicionPreExistente(Receta receta)
        {
            return !receta.InadecuadoPara().Exists(condicionReceta => 
			    CondicionesPreexistentes.Exists(condicionUsuario => 
                    condicionUsuario.Equals(condicionReceta)));
	    }
	
	    private bool EsSugeriblePorDisgusto(Receta receta) 
        {
            return !IngredientesDisgustan.Exists(comidaQueDisgusta => 
                receta.Ingredientes.Exists(ingrediente =>
				    ingrediente.Nombre.Equals(comidaQueDisgusta)));
	    }
	
        //public bool tieneRutina(string rutina) 
        //{
        //    rutina.Equals("intensivo");
        //}

        public bool PesoMenorA(double peso)
        {
            return this.Peso < peso;
        }
	
	    public bool ComparteGrupoCon(Usuario creadorReceta) 
        {
		    return Grupos.Exists(grupo => grupo.perteneceUsuarioAlGrupo(creadorReceta));
	    }
	
	    public bool TieneSobrepeso() 
        {
		    return CalcularIMC() >= 25;
	    }
	
	    public bool EsAdecuadoPara(CondicionPreexistente condicion) {
            return CondicionesPreexistentes.Exists(condicionUsuario => condicionUsuario.Equals(condicion));
	    }

        public bool LeGusta(string preferencia)
        {
            return preferencias.Contains(preferencia);
        }

        public bool TienePreferencias()
        {
            return preferencias.Count > 0;
        }

	    public bool LeDisgusta(Receta receta) 
        {
            return receta.Ingredientes.Exists(ingrediente => LeDisgusta(ingrediente));
	    }
	
	    public bool LeDisgusta(Ingrediente ingrediente) 
        {
            return IngredientesDisgustan.Exists(ingredienteDisgusta => ingrediente.Nombre.Equals(ingredienteDisgusta));
	    }
	
	    public void modificar(Receta receta, Receta nuevaReceta)
        {
		    receta.puedeSerModificadaPor(this);

		    if(receta.Creador == this)
            {
			    receta.serModificada(nuevaReceta);
		    } 
            else 
            {
			    var recetaMia = receta;
			    recetaMia.Creador = this;
			    AgregarReceta(recetaMia);
                recetaMia.serModificada(nuevaReceta);
		    }
	    }
    }
}
