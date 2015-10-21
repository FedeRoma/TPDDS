using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class ValidacionDatos : ValidacionUsuario
    {
        public void Validar(Usuario usuario) 
        {
            if ( usuario.Altura <= 0
                || usuario.Rutina == null)
            {
                throw new BusinessException("Perfil de Usuario inválido.");
            }
	    }
    }
}
