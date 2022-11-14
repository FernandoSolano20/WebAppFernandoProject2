using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.OptionList
{
    /// <summary>
    /// Summary description for OptionListTest
    /// </summary>
    [TestClass]
    public class OptionListTest
    {
        [TestMethod]
        public void Inicializacion_ID()
        {
            //Arrange
            var entity = new POJO_Entities.Entities.OptionList();
            //Act
            entity.ListId = "10";
            //Asert
            Assert.AreEqual("10", entity.ListId);
        }
        [TestMethod]
        public void Inicializacion_Apellido()
        {
            //Arrange
            var entity = new POJO_Entities.Entities.OptionList();
            //Act
            entity.Description = "Sol";
            //Asert
            Assert.AreEqual("Sol", entity.Description);
        }

        [TestMethod]
        public void Inicializacion_Canton()
        {
            //Arrange
            var entity = new POJO_Entities.Entities.OptionList();
            //Act
            entity.Value = "San Jose";
            //Asert
            Assert.AreEqual("San Jose", entity.Value);
        }
    }
}
