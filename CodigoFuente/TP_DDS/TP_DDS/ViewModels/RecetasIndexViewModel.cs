using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DDS.ViewModels
{
    public class RecetasIndexViewModel
    {
        public int IngredienteID { get; set; }
        public int TemporadaID { get; set; }
        public int DificultadId { get; set; }
        public int caloriasMin { get; set; }
        public int caloriasMax { get; set; }
        public int PiramideId { get; set; }
        public int CalificacionPromedio { get; set; }
        public int UsuarioId { get; set; }

        public IEnumerable<RecetasIndexViewModel_Result> Results { get; set; }
    }

    public class RecetasIndexViewModel_Result
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
    }
}