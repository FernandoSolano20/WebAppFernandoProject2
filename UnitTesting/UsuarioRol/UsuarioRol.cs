using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.UsuarioRol
{
    /// <summary>
    /// Summary description for UsuarioRol
    /// </summary>
    [TestClass]
    public class UsuarioRol
    {
        [TestMethod]
        public void Inicializacion_ID()
        {
            //Arrange
            var entity = new Entities_POJO.UsuarioRol();
            //Act
            entity.IdUsuario = "10";
            //Asert
            Assert.AreEqual("10", entity.IdUsuario);
        }
        [TestMethod]
        public void Inicializacion_Apellido()
        {
            //Arrange
            var entity = new Entities_POJO.UsuarioRol();
            //Act
            entity.IdRol = 20;
            //Asert
            Assert.AreEqual(20, entity.IdRol);
        }
    }
}
