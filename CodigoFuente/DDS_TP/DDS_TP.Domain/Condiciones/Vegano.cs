using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Domain.Condiciones
{
    public class Vegano : CondicionPreexistente
    {
        public override bool EsVegano
        {
            get { return true; }
        }

        public override bool PuedeSubsanar(Usuario usuario) 
        {
			return usuario.LeGusta("fruta"); 
	    }
	
        public override bool EsInadecuadoPara(Receta receta)
        {
            return receta.contieneIngrediente("pollo")
                || receta.contieneIngrediente("carne")
                || receta.contieneIngrediente("chivito")
                || receta.contieneIngrediente("chori");
        }
    }
}
