﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class Reporte
    {
        public String Tipo { get; set; }

        public void Ejecutar()
        { 
            //Aplicar Patron Strategi(?)
            if(Tipo =="RecetasPorPeriodo")
            {
                RecetasPorPeriodo oRep = new RecetasPorPeriodo();
                oRep.ObtenerReporte();
            }
            else if (Tipo == "RecetasNuevas")
            {
                RecetasNuevas oRep = new RecetasNuevas();
                oRep.ObtenerReporte();
            }
            else if (Tipo == "PreferenciasPorPeriodo")
            {
                PreferenciasPorPeriodo oRep = new PreferenciasPorPeriodo();
                oRep.ObtenerReporte();
            }
            else if (Tipo == "RecetasPorCalorias")
            {
                RecetasPorCalorias oRep = new RecetasPorCalorias();
                oRep.ObtenerReporte();
            }
                
        }
    }
}
