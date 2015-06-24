using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDS_TP.Domain.Filtros;
using DDS_TP.Domain.Procesamientos;

namespace DDS_TP.Domain.Repositorios
{
    public class RepositorioRecetas
    {
        private static RepositorioRecetas instance = new RepositorioRecetas();
        private List<Receta> recetas = new List<Receta>();

        public static RepositorioRecetas Instance 
        { 
            get { return instance; } 
        }

        private RepositorioRecetas()
        {
            recetas = new List<Receta>();
        }

        public void Agregar(Receta receta)
        {
            recetas.Add(receta);
        }

        public void Quitar(Receta receta)
        {
            recetas.Remove(receta);
        }

        public List<Receta> ObtenerRecetas()
        {
            return recetas;
        }

        public List<Receta> ObtenerRecetasQuePuedeVer(Usuario usuario) 
        {
		    return recetas.FindAll(receta => receta.TienePermisoVisibilidad(usuario));
        }

	    public List<Receta> ObtenerRecetasQuePuedeVer(Usuario usuario, List<Filtro> listaFiltros) 
        {
            throw new Exception();
            //var listaRecetasQuePuedeVer = listarRecetasQuePuedeVer(usuario)
            //for (filtro : listaFiltros) {
            //    listaRecetasQuePuedeVer = filtro.filtrar(listaRecetasQuePuedeVer, usuario)
            //}
            //listaRecetasQuePuedeVer
	    }

        public List<Receta> ObtenerRecetasQuePuedeVer(Usuario usuario, List<Filtro> listaFiltros, 
            List<Procesamiento> listaProcesamientosPosteriores) 
        {
            throw new Exception();
            //var listaRecetasQuePuedeVer = listarRecetasQuePuedeVer(usuario, listaFiltros)
            //for(procPost : listaProcesamientosPosteriores){
            //    listaRecetasQuePuedeVer = procPost.procesar(listaRecetasQuePuedeVer)
            //}
            //listaRecetasQuePuedeVer
	    }
    }
}
