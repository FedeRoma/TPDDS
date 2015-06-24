using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Domain.Validaciones
{
    public class ValidacionVegano : ValidacionUsuario
    {
        public void Validar(Usuario usuario) 
        {
            if (usuario.CondicionesPreexistentes.Exists(condicion => condicion.EsVegano)
                    && (usuario.LeGusta("pollo")
                            || usuario.LeGusta("carne")
                            || usuario.LeGusta("chivito")
                            || usuario.LeGusta("chori")))
            {
                throw new BusinessException("Preferencias inadecuadas para un Vegano");
            }
	    }
    }
}
