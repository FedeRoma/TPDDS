using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class Reporte
    {
        [NotMapped]
        public object FiltroIni { get; set; }

        [NotMapped]
        public object FiltroFin { get; set; }

        [NotMapped]
        public int UsuarioId { get; set; }

        public object Ejecutar(IGenerarReporte reporte)
        {
            return reporte.ObtenerReporte(this.FiltroIni, this.FiltroFin, this.UsuarioId);
        }
    }
}
