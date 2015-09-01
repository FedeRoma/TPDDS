using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Models
{
    public class Grupo
    {
        public String Nombre { get; set; }
        public ICollection<Preferencia> PreferenciasAlimenticias { get; set; }

        public Grupo() 
        {
	    }

        public Grupo(String nombre) 
        {
		    this.Nombre = nombre;
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
