using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DDS.Models
{
    public class Recomendacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int CondicionPreexistenteId { get; set; }

        public virtual CondicionPreexistente CondicionPreexistente { get; set; }
    }
}