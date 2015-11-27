using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DDS.Models
{
    public class Celiaco : Condicion
    {
        public override void Accept(IUsuarioVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}