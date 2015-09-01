using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Models
{
    public class IngredienteReceta
    {
        public int Cantidad { get;  set; }
        public string Tipo { get; set; }
        public Ingrediente Ingrediente { get; set; }

        public IngredienteReceta(int cantidad, string tipo, Ingrediente ingrediente)
        {
            Cantidad = cantidad;
            Tipo = tipo;
            Ingrediente = ingrediente;
        }

        public double CalcularCalorias()
        {
            return Ingrediente.CaloriasPorcion * Cantidad;
        }
    }
}
