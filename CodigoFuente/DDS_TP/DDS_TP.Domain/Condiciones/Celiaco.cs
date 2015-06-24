using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Domain.Condiciones
{
    public class Celiaco : CondicionPreexistente
    {
        public override bool EsCeliaco
        {
            get { return true; }
        }

        public override bool PuedeSubsanar(Usuario usuario) 
        {
			return true;
	    }

        public override bool EsInadecuadoPara(Receta receta)
        {
            return receta.contieneIngrediente("harina");
	    }
    }
}
