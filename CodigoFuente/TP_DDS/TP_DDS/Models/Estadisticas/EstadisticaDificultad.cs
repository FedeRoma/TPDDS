using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP_DDS.DAL;

namespace TP_DDS.Models
{
    public class EstadisticaDificultad : IProcesarEstadistica
    {
        public string Dificultad { get; set; }
        public int Consultas { get; set; }

        public object ObtenerEstadistica(int tipo)
        {
            TPDDSContext db = new TPDDSContext();

            return db.GetEstadisticaByDificultad(tipo);
        }
    }
}
