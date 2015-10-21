using System;

namespace TP_DDS.Models
{
    //public enum Sexo
    //{
    //    Hombre,
    //    Mujer
    //}

    public class Sexo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal CoefCalcCalorias { get; set; }
        public decimal CoefCalcCalPeso { get; set; }
        public decimal CoefCalcCalAltura { get; set; }
        public decimal CoefCalcCalEdad { get; set; }
    }
}
