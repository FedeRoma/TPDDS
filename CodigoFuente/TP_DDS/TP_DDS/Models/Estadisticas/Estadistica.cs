using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class Estadistica
    {
        public int Id { get; set; }
        public int RecetaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaHora { get; set; }

        [NotMapped]
        public int Tipo { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Receta Receta { get; set; }

        //public void Ejecutar()
        //{ 
        //    if(Tipo =="Sexo")
        //    {
        //        EstadisticaSexo oEst = new EstadisticaSexo();
        //        oEst.ObtenerEstadistica();
        //    }
        //    else if (Tipo == "Dificultad")
        //    {
        //        EstadisticaDificultad oEst = new EstadisticaDificultad();
        //        oEst.ObtenerEstadistica();
        //    }
        //    else if (Tipo == "Ranking")
        //    {
        //        EstadisticaRanking oEst = new EstadisticaRanking();
        //        oEst.ObtenerEstadistica();
        //    }
        //}

        public object Ejecutar(IProcesarEstadistica estadistica)
        {
            return estadistica.ObtenerEstadistica(this.Tipo);
        }
    }
}
