using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_DDS.Models
{
    public class Grupo
    {
        public int Id { get; set; }
        public String Nombre { get; set; }

        public virtual ICollection<Preferencia> PreferenciasAlimenticias { get; set; }




        //public Grupo() 
        //{
        //}

        //public Grupo(String nombre) 
        //{
        //    this.Nombre = nombre;
        //}

        //public void AgregarPreferencia(Preferencia preferencia)
        //{
        //    PreferenciasAlimenticias.Add(preferencia);
        //}

        //public void QuitarPreferencia(Preferencia preferencia)
        //{
        //    PreferenciasAlimenticias.Remove(preferencia);
        //}

        //internal bool perteneceUsuarioAlGrupo(Usuario creadorReceta)
        //{
        //    throw new NotImplementedException();
        //}

        //internal void agregameALista(Usuario usuario)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
