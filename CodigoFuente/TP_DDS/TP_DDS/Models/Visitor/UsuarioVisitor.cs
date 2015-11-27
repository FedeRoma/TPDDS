using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_DDS.Models
{
    public interface IUsuarioVisitor
    {
        void Visit(Celiaco usuario);
        void Visit(Diabetico usuario);
        void Visit(Hipertenso usuario);
    }
}