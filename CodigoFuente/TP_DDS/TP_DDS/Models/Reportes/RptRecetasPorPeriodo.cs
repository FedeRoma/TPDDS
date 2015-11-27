using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS.DAL;

namespace TP_DDS.Models
{
    public class RptRecetasPorPeriodo : IGenerarReporte
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
        public DateTime FechaHora { get; set; }

        public object ObtenerReporte(object filtroIni, object filtroFin, int usuarioId)
        {
            TPDDSContext db = new TPDDSContext();

            string[] arrini = ((IEnumerable)filtroIni).Cast<object>()
                                 .Select(x => x.ToString())
                                 .ToArray();

            string[] arrfin = ((IEnumerable)filtroFin).Cast<object>()
                     .Select(x => x.ToString())
                     .ToArray();

            DateTime fechaIni = DateTime.Parse(arrini[0]);
            DateTime fechaFin = DateTime.Parse(arrfin[0]);

            return db.GetRecetasPorPeriodo(fechaIni, fechaFin, usuarioId);
        }
    }
}