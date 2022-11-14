using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.Contrasenna
{
    /// <summary>
    /// Summary description for ContrasennaTest
    /// </summary>
    [TestClass]
    public class ContrasennaTest
    {
        [TestMethod]
        public void Inicializacion_ID()
        {
            //Arrange
            var entity = new Entities_POJO.Contrasenna();
            //Act
            entity.Id = 1;
            //Asert
            Assert.AreEqual(1, entity.Id);
        }
        [TestMethod]
        public void Inicializacion_IdUsuario()
        {
            //Arrange
            var entity = new Entities_POJO.Contrasenna();
            //Act
            entity.IdUsuario = "117840834";
            //Asert
            Assert.AreEqual("Sol", entity.IdUsuario);
        }

        [TestMethod]
        public void Inicializacion_Pass()
        {
            //Arrange
            var entity = new Entities_POJO.Contrasenna();
            //Act
            entity.Password = "San Jose";
            //Asert
            Assert.AreEqual("San Jose", entity.Password);
        }

        [TestMethod]
        public void Inicializacion_Fecha()
        {
            //Arrange
            var entity = new Entities_POJO.Contrasenna();
            //Act
            entity.Fecha = new DateTime(2000,10,2);
            //Asert
            Assert.AreNotEqual(new DateTime(2001, 10, 2), entity.Fecha);
        }

        [TestMethod]
        public void Inicializacion_Estado()
        {
            //Arrange
            var entity = new Entities_POJO.Contrasenna();
            //Act
            entity.Estado = "ACT";
            //Asert
            Assert.AreEqual("ACT", entity.Estado);
        }

        [TestMethod]
        public void Inicializacion_Password()
        {
            //Arrange
            var entity = new Entities_POJO.Contrasenna();
            //Act
            entity.Password = "90";
            //Asert
            Assert.AreEqual("90", entity.Password);
        }
    }
}
