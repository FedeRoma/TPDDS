using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DDS.ViewModels
{
    public class RecetasByPiramide
    {
        public int PiramideId { get; set; }
        public IEnumerable<RecetasByPiramide_Result> Results { get; set; }
    }

    public class RecetasByPiramide_Result
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Dificultad { get; set; }
        public decimal TotalCalorias { get; set; }
        public int PiramideId { get; set; }
        public int UsuarioId { get; set; }
        public int CalificacionPromedio { get; set; }
        public string Creador { get; set; }
    }
}