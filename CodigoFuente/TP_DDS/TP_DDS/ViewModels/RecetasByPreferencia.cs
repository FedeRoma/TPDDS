using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DDS.ViewModels
{
    public class RecetasByPreferencia
    {
        public int PreferenciaId { get; set; }
        public IEnumerable<RecetasByPreferencia_Result> Results { get; set; }
    }

    public class RecetasByPreferencia_Result
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Dificultad { get; set; }
        public decimal TotalCalorias { get; set; }
        public int PiramideId { get; set; }
        public int UsuarioId { get; set; }
        public int CalificacionPromedio { get; set; }
        public string SectorPiramide { get; set; }
        public string Creador { get; set; }
    }
}