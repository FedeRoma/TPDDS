using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS.DAL;

namespace TP_DDS.Models
{
    public class RptRecetasNuevas : IGenerarReporte
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Dificultad { get; set; }
        public decimal TotalCalorias { get; set; }
        public int PiramideId { get; set; }
        public int UsuarioId { get; set; }
        public int CalificacionPromedio { get; set; }
        public string SectorPiramide { get; set; }
        public string Creador { get; set; }
        public DateTime FechaCreacion { get; set; }

        public object ObtenerReporte(object filtroIni, object filtroFin, int usuarioId)
        {
            TPDDSContext db = new TPDDSContext();

            DateTime fechaIni = Convert.ToDateTime(filtroIni);
            DateTime fechaFin = Convert.ToDateTime(filtroFin);

            return db.GetRecetasNuevas(fechaIni, fechaFin, usuarioId);
        }
    }
}