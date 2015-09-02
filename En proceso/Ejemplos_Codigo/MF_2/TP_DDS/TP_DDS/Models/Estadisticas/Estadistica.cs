﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class Estadistica
    {
        public String Tipo { get; set; }

        public void Ejecutar()
        { 
            //Aplicar Patron Strategi(?)
            if(Tipo =="Sexo")
            {
                EstadisticaSexo oEst = new EstadisticaSexo();
                oEst.ObtenerEstadistica();
            }
            else if (Tipo == "Dificultad")
            {
                EstadisticaDificultad oEst = new EstadisticaDificultad();
                oEst.ObtenerEstadistica();
            }
            else if (Tipo == "Ranking")
            {
                EstadisticaRanking oEst = new EstadisticaRanking();
                oEst.ObtenerEstadistica();
            }
                
        }
    }
}
