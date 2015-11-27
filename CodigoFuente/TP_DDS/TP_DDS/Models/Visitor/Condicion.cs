using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DDS.Models
{
    public abstract class Condicion
    {
        public string Text { get; private set; }
        public abstract void Accept(IUsuarioVisitor visitor);
    }
}