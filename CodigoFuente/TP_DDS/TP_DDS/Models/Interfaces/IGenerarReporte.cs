using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public interface IGenerarReporte
    {
        object ObtenerReporte(object filtroIni, object filtroFin, int usuarioId);
    }
}
