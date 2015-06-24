using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Domain.Validaciones
{
    public class ValidacionDiabetico : ValidacionUsuario
    {
        public void Validar(Usuario usuario) 
        {
		    if(usuario.CondicionesPreexistentes.Exists(condicion => condicion.EsDiabetico)
                && !usuario.TienePreferencias()
                && usuario.Sexo == null)
            {
                throw new BusinessException("No cumple validez de Diabético");
	    	}
    	}
    }
}
