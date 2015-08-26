using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Domain
{
    public class Grupo
    {
        public String Nombre { get; protected set; }
        public List<Preferencia> PreferenciasAlimenticias { get; protected set; }

        public Grupo() 
        {
	    }

        public Grupo(String nombre) 
        {
		    Initialize();
		    this.Nombre = nombre;
	    }

	    public void Initialize() 
        {
            PreferenciasAlimenticias = new List<Preferencia>();
	    }

        public void AgregarPreferencia(Preferencia preferencia)
        {
            PreferenciasAlimenticias.Add(preferencia);
        }

        public void QuitarPreferencia(Preferencia preferencia)
        {
            PreferenciasAlimenticias.Remove(preferencia);
        }

        internal bool perteneceUsuarioAlGrupo(Usuario creadorReceta)
        {
            throw new NotImplementedException();
        }

        internal void agregameALista(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
