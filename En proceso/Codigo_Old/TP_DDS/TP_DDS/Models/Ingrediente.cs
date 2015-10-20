using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Porcion { get; set; }
        public decimal CaloriasPorcion { get; set; }
        public int PreferenciaId { get; set; }

        public virtual Preferencia Preferencia { get; set; }

        //public Ingrediente(string nombre, int porcion, double caloriasPorcion)
        //{
        //    Nombre = nombre;
        //    Porcion = porcion;
        //    CaloriasPorcion = caloriasPorcion;
        //}
    }
}
