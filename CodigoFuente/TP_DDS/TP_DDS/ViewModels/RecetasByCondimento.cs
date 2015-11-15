using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DDS.ViewModels
{
    public class RecetasByCondimento
    {
        public int CondimentoId { get; set; }
        public IEnumerable<RecetasByCondimento_Result> Results { get; set; }
    }

    public class RecetasByCondimento_Result
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