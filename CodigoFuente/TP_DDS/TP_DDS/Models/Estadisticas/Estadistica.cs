using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Models
{
    public class Estadistica
    {
        public String Tipo { get; protected set; }

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
