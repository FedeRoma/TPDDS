using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Models
{
    public class Ingrediente
    {
        public string Nombre { get; set; }
        public int Porcion { get; set; }
        public double CaloriasPorcion { get; set; }

        public Ingrediente(string nombre, int porcion, double caloriasPorcion)
        {
            Nombre = nombre;
            Porcion = porcion;
            CaloriasPorcion = caloriasPorcion;
        }
    }
}
