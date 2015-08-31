using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Models
{
    public class ValidacionFechaNacimiento : ValidacionUsuario
    {
        public void Validar(Usuario usuario) 
        {
            if (usuario.FechaNacimiento.Equals(DateTime.MinValue)
                || usuario.FechaNacimiento.CompareTo(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)) > 0)
            {
                throw new BusinessException("Fecha de nacimiento inválida");
            }
	    }
    }
}
