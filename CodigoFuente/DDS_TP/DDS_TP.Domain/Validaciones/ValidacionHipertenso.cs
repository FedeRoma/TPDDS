using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Domain.Validaciones
{
    public class ValidacionHipertenso : ValidacionUsuario
    {
        public void Validar(Usuario usuario) 
        {
		    if(usuario.CondicionesPreexistentes.Exists(condicion => condicion.EsHipertenso) 
                && !usuario.TienePreferencias())
            {
                throw new BusinessException("Si es Hipertenso debe indicar preferencias");
	    	}
    	}
    }
}
