using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DDS.Models
{
    public class Hipertenso : Condicion
    {
        public override void Accept(IUsuarioVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}