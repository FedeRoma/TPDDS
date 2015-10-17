﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class Clasificacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Receta> Recetas { get; set; }

        //public Clasificacion(string nombre)
        //{
        //    Nombre = nombre;
        //}
    }
}
