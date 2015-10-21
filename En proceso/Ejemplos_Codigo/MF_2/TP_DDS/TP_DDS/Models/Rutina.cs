using System;

namespace TP_DDS.Models
{
    //public enum Rutina
    //{
    //    Sedentaria,
    //    Sedentaria_Leve,
    //    Sedentaria_Mediana,
    //    Activa,
    //    Activa_Intensiva
    //}

    public class Rutina
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal CoefCalcCalorias { get; set; }
    }
}
