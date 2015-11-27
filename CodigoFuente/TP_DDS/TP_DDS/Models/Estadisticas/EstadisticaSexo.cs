using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP_DDS.DAL;

namespace TP_DDS.Models
{
    public class EstadisticaSexo : IProcesarEstadistica
    {
        public string Sexo { get; set; }
        public string Dieta { get; set; }
        public int Consultas { get; set; }

        public object ObtenerEstadistica(int tipo)
        {
            TPDDSContext db = new TPDDSContext();

            return db.GetEstadisticaBySexo(tipo);
        }
    }
}
