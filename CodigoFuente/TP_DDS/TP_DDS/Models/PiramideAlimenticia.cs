using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DDS.Models
{
    public class PiramideAlimenticia
    {
        public int Id { get; set; }
        public string NombreGrupo { get; set; }
        public string DescripcionGrupo { get; set; }
        public string Contraindicaciones { get; set; }
    }
}