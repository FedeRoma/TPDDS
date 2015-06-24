using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDS_TP.Domain.Condiciones;

namespace DDS_TP.Domain.Repositorios
{
    public class RepositorioCondiciones
    {
	    private static RepositorioCondiciones instance = new RepositorioCondiciones();
        private List<CondicionPreexistente> condiciones = new List<CondicionPreexistente>();

        public static RepositorioCondiciones Instance 
        { 
            get { return instance; } 
        }

        private RepositorioCondiciones()
        {
            condiciones = new List<CondicionPreexistente>();
        }
	
	    private void Initialize() 
        {
		    condiciones = new List<CondicionPreexistente>();
		    condiciones.Add(new Celiaco());
		    condiciones.Add(new Diabetico());
		    condiciones.Add(new Hipertenso());
		    condiciones.Add(new Vegano());
	    }

	    public List<CondicionPreexistente> GetAll() 
        {
            return condiciones;
	    }

    }
}
