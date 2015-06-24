using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Domain
{
    public class Ingrediente
    {
        public string Nombre { get; protected set; }
        public int Cantidad { get; protected set; }
        public double Costo { get; protected set; }

        public bool EsCaro
        {
            get { return Costo > 75; }
	    }

        public bool IgualNombre(string ingredienteNombre) {
            return Nombre.Equals(ingredienteNombre);
	    }
    }
}
