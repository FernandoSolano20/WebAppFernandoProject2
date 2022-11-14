using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Especialidad
{
    [TestClass]
    public class EspecialidadTests
    {
        [TestMethod]
        public void Especialidad_Inicializacion_NombreEsIgual()
        {
            //Arrange
            var especialidad = new Entities_POJO.Especialidad();
            //Act
            especialidad.Nombre = "Reparacion";
            //Asert
            Assert.AreEqual("Reparacion", especialidad.Nombre);

        }

        [TestMethod]
        public void Especialidad_Inicializacion_IDEsIgual()
        {
            //Arrange
            var especialidad = new Entities_POJO.Especialidad();
            //Act
            especialidad.ID = 0;
            //Asert
            Assert.AreEqual(0, especialidad.ID);

        }

        [TestMethod]
        public void Especialidad_Inicializacion_EstadoEsIgual()
        {
            //Arrange
            var especialidad = new Entities_POJO.Especialidad();
            //Act
            especialidad.Estado = "ACT";
            //Asert
            Assert.AreEqual("ACT", especialidad.Estado);

        }
    }
}
