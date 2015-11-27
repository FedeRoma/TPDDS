using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DDS.ViewModels
{
    public class CaloriasMaxByRutina
    {
        public int RutinaId { get; set; }
        public IEnumerable<CaloriasMaxByRutina_Result> Results { get; set; }
    }

    public class CaloriasMaxByRutina_Result
    {
        public string Usuario { get; set; }
        public decimal CaloriasMaximas { get; set; }

    }
}