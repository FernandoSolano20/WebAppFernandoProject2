using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.Empresa
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class Empresa
    {
        [TestMethod]
        public void Inicializacion_ID()
        {
            //Arrange
            var entity = new Entities_POJO.Empresa();
            //Act
            entity.Cedula = "10";
            //Asert
            Assert.AreEqual("10", entity.Cedula);
        }

        [TestMethod]
        public void Inicializacion_Canton()
        {
            //Arrange
            var entity = new Entities_POJO.Empresa();
            //Act
            entity.Canton = "San Jose";
            //Asert
            Assert.AreEqual("San Jose", entity.Canton);
        }

        [TestMethod]
        public void Inicializacion_Direccion()
        {
            //Arrange
            var entity = new Entities_POJO.Empresa();
            //Act
            entity.Direccion = "San Jose";
            //Asert
            Assert.AreEqual("San Jose", entity.Canton);
        }

        [TestMethod]
        public void Inicializacion_lATITUD()
        {
            //Arrange
            var entity = new Entities_POJO.Empresa();
            //Act
            entity.Latitud = "90";
            //Asert
            Assert.AreEqual("90", entity.Canton);
        }

        [TestMethod]
        public void Inicializacion_Longitud()
        {
            //Arrange
            var entity = new Entities_POJO.Empresa();
            //Act
            entity.Longitud = "90";
            //Asert
            Assert.AreEqual("90", entity.Longitud);
        }

        [TestMethod]
        public void Inicializacion_RazonSocial()
        {
            //Arrange
            var entity = new Entities_POJO.Empresa();
            //Act
            entity.RazonSocial = "90";
            //Asert
            Assert.AreEqual("90", entity.RazonSocial);
        }
    }
}
