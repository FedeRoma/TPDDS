using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDS_TP.Domain;

namespace DDS_TP.Tests
{
    /// <summary>
    /// Se realizan los test sobre la clase Usuario
    /// </summary>
    [TestClass]
    public class UsuarioTest
    {
        Usuario usuarioInvalido;
        Usuario usuarioValido;
        Usuario juani;
        
        [TestInitialize()]
        public void Initialize() 
        {
            usuarioInvalido = new Usuario();
            usuarioValido = new Usuario("usuario", Sexo.Hombre, Rutina.Activa, 70, 1.65, new DateTime(1990, 5, 10));
            juani = new Usuario("juani", Sexo.Hombre, Rutina.Activa, 75, 1.80, new DateTime(1990, 5, 10));
        }
        
        [TestCleanup()]
        public void Cleanup() 
        { 
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void UsuarioInvalido()
        {
            usuarioInvalido.Validar();
        }

        [TestMethod]
        public void UsuarioValido()
        {
            usuarioValido.Validar();
        }

        [TestMethod]
        public void CalculoIMC()
        {
            Assert.AreEqual(23.148, juani.CalcularIMC());
        }
    }
}
