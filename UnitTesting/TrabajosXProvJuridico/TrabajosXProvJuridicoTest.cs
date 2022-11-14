using Entities_POJO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class TrabajosXProvJuridicoTest
    {
        //Id_TipoTrabajo
        [TestMethod]
        public void TrabajosXProvJuridico_Inicializacion_Id_TipoTrabajo_EsIgual()
        {
            //Arrange
            var trabajosProvJuridico = new TipoTrabajoTrabajador();
            //Act
            trabajosProvJuridico.Id_TipoTrabajo = 1;
            //Asert
            Assert.AreEqual(1, trabajosProvJuridico.Id_TipoTrabajo);
        }

        //Id_Trabajador
        [TestMethod]
        public void TrabajosXProvJuridico_Inicializacion_Id_Trabajador_EsIgual()
        {
            //Arrange
            var trabajosProvJuridico = new TipoTrabajoTrabajador();
            //Act
            trabajosProvJuridico.Id_Trabajador = "12345";
            //Asert
            Assert.AreEqual("12345", trabajosProvJuridico.Id_Trabajador);
        }

        //Precio_Hora
        [TestMethod]
        public void TrabajosXProvJuridico_Inicializacion_Precio_Hora_EsIgual()
        {
            //Arrange
            var trabajosProvJuridico = new TipoTrabajoTrabajador();
            //Act
            trabajosProvJuridico.Precio_Hora = 520;
            //Asert
            Assert.AreEqual(520, trabajosProvJuridico.Precio_Hora);
        }

        //Fecha
        [TestMethod]
        public void TrabajosXProvJuridico_Inicializacion_Fecha_EsIgual()
        {
            //Arrange
            var trabajosProvJuridico = new TipoTrabajoTrabajador();
            //Act
            trabajosProvJuridico.Fecha = new DateTime(2011, 05, 02);
            //Asert
            Assert.AreEqual(new DateTime(2011, 05, 02), trabajosProvJuridico.Fecha);
        }

        //Estado
        [TestMethod]
        public void TrabajosXProvJuridico_Inicializacion_Estado_EsIgual()
        {
            //Arrange
            var trabajosProvJuridico = new TipoTrabajoTrabajador();
            //Act
            trabajosProvJuridico.Estado = "ACT";
            //Asert
            Assert.AreEqual("ACT", trabajosProvJuridico.Estado);
        }

        //nombreTrabajador
        [TestMethod]
        public void TrabajosXProvJuridico_Inicializacion_nombreTrabajador_EsIgual()
        {
            //Arrange
            var trabajosProvJuridico = new TipoTrabajoTrabajador();
            //Act
            trabajosProvJuridico.nombreTrabajador = "Juan";
            //Asert
            Assert.AreEqual("Juan", trabajosProvJuridico.nombreTrabajador);
        }

        //apellidosTrabajador
        [TestMethod]
        public void TrabajosXProvJuridico_Inicializacion_apellidosTrabajador_EsIgual()
        {
            //Arrange
            var trabajosProvJuridico = new TipoTrabajoTrabajador();
            //Act
            trabajosProvJuridico.apellidosTrabajador = "Perez";
            //Asert
            Assert.AreEqual("Perez", trabajosProvJuridico.apellidosTrabajador);
        }

        //tipoTrabajo
        [TestMethod]
        public void TrabajosXProvJuridico_Inicializacion_tipoTrabajo_EsIgual()
        {
            //Arrange
            var trabajosProvJuridico = new TipoTrabajoTrabajador();
            //Act
            trabajosProvJuridico.tipoTrabajo = "Electricista";
            //Asert
            Assert.AreEqual("Electricista", trabajosProvJuridico.tipoTrabajo);
        }
    }
}
