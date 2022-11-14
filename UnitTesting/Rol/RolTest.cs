using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class RolTests
    {
        [TestMethod]
        public void Rol_Inicializacion_NombreEsIgual()
        {
            //Arrange
            var rol = new Rol();
            //Act
            rol.Nombre = "Reparacion";
            //Asert
            Assert.AreEqual("Reparacion", rol.Nombre);

        }
        [TestMethod]
        public void Rol_Inicializacion_DescripcionEsIgual()
        {
            //Arrange
            var rol = new Rol();
            //Act
            rol.Descripcion = "Muebles";
            //Asert
            Assert.AreEqual("Muebles", rol.Descripcion);

        }

        [TestMethod]
        public void Rol_Inicializacion_IDEsIgual()
        {
            //Arrange
            var rol = new Rol();
            //Act
            rol.Id = 0;
            //Asert
            Assert.AreEqual(0, rol.Id);

        }
    }
}
