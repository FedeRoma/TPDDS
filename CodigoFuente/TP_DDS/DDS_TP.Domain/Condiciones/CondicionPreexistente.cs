using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Domain.Condiciones
{
    public abstract class CondicionPreexistente
    {
        //Implementar Patron Visitor!!
        //Implementar Patron Visitor!!
        //Implementar Patron Visitor!!
        public abstract bool PuedeSubsanar(Usuario usuario);
        public abstract bool EsInadecuadoPara(Receta receta);

        public virtual bool EsVegano
        { 
            get { return false; } 
        }

        public virtual bool EsDiabetico
        {
            get { return false; } 
        }

        public virtual bool EsHipertenso 
        {
            get { return false; } 
        }

        public virtual bool EsCeliaco
        {
            get { return false; }
        }

        public override bool Equals(object obj)
        {
		    return obj.ToString().Equals(ToString());
	    }
	
	    public override int GetHashCode() 
        {
		    return ToString().GetHashCode();
	    }
    }
}
