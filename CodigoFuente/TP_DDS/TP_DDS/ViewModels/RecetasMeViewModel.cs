using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS.Models;

namespace TP_DDS.ViewModels
{
    public class RecetasMeViewModel
    {
        public IEnumerable<Receta> Creadas { get; set; }
        public IEnumerable<Receta> Calificadas { get; set; }
        public IEnumerable<Receta> Consultadas { get; set; }
    }
}