using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class IngredienteReceta
    {
        public int Id { get; set; }
        public int Cantidad { get;  set; }
        public int TipoIngredienteId { get; set; }
        public int IngredienteId { get; set; }
        public int RecetaId { get; set; }

        public virtual TipoIngrediente TipoIngrediente { get; set; }
        public virtual Ingrediente Ingrediente { get; set; }
        public virtual Receta Receta { get; set; }
    }
}
