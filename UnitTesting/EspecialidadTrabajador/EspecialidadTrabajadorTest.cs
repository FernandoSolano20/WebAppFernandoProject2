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
    public class EspecialidadTrabajadorTest
    {
            [TestMethod]
            public void EspecialidadTrabajador_Inicializacion_NombreEsIgual()
            {
                //Arrange
                var especialidadTrabajador = new EspecialidadTrabajador();
            //Act
            especialidadTrabajador.Nombre = "Juan";
                //Asert
                Assert.AreEqual("Juan", especialidadTrabajador.Nombre);

            }
            [TestMethod]
            public void EspecialidadTrabajador_Inicializacion_ApellidosEsIgual()
            {
                //Arrange
                var especialidadTrabajador = new EspecialidadTrabajador();
            //Act
            especialidadTrabajador.Apellidos = "Mora";
                //Asert
                Assert.AreEqual("Mora", especialidadTrabajador.Apellidos);

            }

            [TestMethod]
            public void EspecialidadTrabajador_Inicializacion_ID_EspecialidadEsIgual()
            {
                //Arrange
                var especialidadTrabajador = new EspecialidadTrabajador();
            //Act
            especialidadTrabajador.ID_Especialidad = 117640441;
                //Asert
                Assert.AreEqual(117640441, especialidadTrabajador.ID_Especialidad);

            }
        [TestMethod]
        public void EspecialidadTrabajador_Inicializacion_ID_TrabajadorEsIgual()
        {
            //Arrange
            var especialidadTrabajador = new EspecialidadTrabajador();
            //Act
            especialidadTrabajador.ID_Trabajador = "0";
            //Asert
            Assert.AreEqual("0", especialidadTrabajador.ID_Trabajador);

        }
        [TestMethod]
        public void EspecialidadTrabajador_Inicializacion_EspecialidadEsIgual()
        {
            //Arrange
            var especialidadTrabajador = new EspecialidadTrabajador();
            //Act
            especialidadTrabajador.Especialidad = "Electricista";
            //Asert
            Assert.AreEqual("Electricista", especialidadTrabajador.Especialidad);

        }
        [TestMethod]
        public void EspecialidadTrabajador_Inicializacion_EstadoEsIgual()
        {
            //Arrange
            var especialidadTrabajador = new EspecialidadTrabajador();
            //Act
            especialidadTrabajador.Estado = "ACT";
            //Asert
            Assert.AreEqual("ACT", especialidadTrabajador.Estado);

        }
    }

 }


