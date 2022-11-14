using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.Usuario
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void Usuario_Inicializacion_ID()
        {
            //Arrange
            var entity = new Entities_POJO.Usuario();
            //Act
            entity.Identificacion = "10";
            //Asert
            Assert.AreEqual("10", entity.Identificacion);
        }
        [TestMethod]
        public void Usuario_Inicializacion_Apellido()
        {
            //Arrange
            var entity = new Entities_POJO.Usuario();
            //Act
            entity.PrimerApellido = "Sol";
            //Asert
            Assert.AreEqual("Sol", entity.PrimerApellido);
        }

        [TestMethod]
        public void Usuario_Inicializacion_Canton()
        {
            //Arrange
            var entity = new Entities_POJO.Usuario();
            //Act
            entity.Canton = "San Jose";
            //Asert
            Assert.AreEqual("San Jose", entity.Canton);
        }

        [TestMethod]
        public void Usuario_Inicializacion_Direccion()
        {
            //Arrange
            var entity = new Entities_POJO.Usuario();
            //Act
            entity.Direccion = "San Jose";
            //Asert
            Assert.AreEqual("San Jose", entity.Canton);
        }

        [TestMethod]
        public void Usuario_Inicializacion_lATITUD()
        {
            //Arrange
            var entity = new Entities_POJO.Usuario();
            //Act
            entity.Latitud= "90";
            //Asert
            Assert.AreEqual("90", entity.Canton);
        }

        [TestMethod]
        public void Usuario_Inicializacion_Longitud()
        {
            //Arrange
            var entity = new Entities_POJO.Usuario();
            //Act
            entity.Longitud = "90";
            //Asert
            Assert.AreEqual("90", entity.Longitud);
        }
    }
}
