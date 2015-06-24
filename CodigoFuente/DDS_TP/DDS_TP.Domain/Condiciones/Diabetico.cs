using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Domain.Condiciones
{
    public class Diabetico : CondicionPreexistente
    {
        public override bool EsDiabetico
        {
            get { return true; }
        }

        public override bool PuedeSubsanar(Usuario usuario) 
        {
			return usuario.Rutina == Rutina.Activa || usuario.PesoMenorA(70);
	    }

        public override bool EsInadecuadoPara(Receta receta)
        {
		    return receta.ContieneIngredienteCantidadMayor("azucar", 100); 
	    }
    }
}
