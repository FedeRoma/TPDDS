using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Domain.Condiciones
{
    public class Hipertenso : CondicionPreexistente
    {
        public override bool EsHipertenso
        {
            get { return true; }
        }

        public override bool PuedeSubsanar(Usuario usuario) 
        {
			return usuario.Rutina == Rutina.Activa_Intensiva; 
	    }

        public override bool EsInadecuadoPara(Receta receta)
        {
            return receta.contieneIngrediente("sal") || receta.contieneIngrediente("caldo");
	    }
	
    }
}
