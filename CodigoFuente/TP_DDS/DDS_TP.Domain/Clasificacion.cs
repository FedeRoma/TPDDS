﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Domain
{
    public class Clasificacion
    {
        public string Nombre { get; protected set; }

        public Clasificacion(string nombre)
        {
            Nombre = nombre;
        }
    }
}
