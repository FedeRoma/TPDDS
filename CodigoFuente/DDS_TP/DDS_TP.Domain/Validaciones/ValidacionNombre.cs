using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Domain.Validaciones
{
    public class ValidacionNombre : ValidacionUsuario
    {
        public void Validar(Usuario usuario) 
        {
            if (String.IsNullOrEmpty(usuario.Nombre) || usuario.Nombre.Length <= 4)
                throw new BusinessException("El Nombre debe tener al menos 4 caracteres");
	    }
    }
}
