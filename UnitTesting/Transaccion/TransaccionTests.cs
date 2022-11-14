using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Transaccion
{
    [TestClass]
    public class TransaccionTests
    {
        [TestMethod]
        public void Transaccion_Inicializacion_IDEsIgual()
        {
            //Arrange
            var transaccion = new Entities_POJO.Transaccion();
            //Act
            transaccion.ID = 10;
            //Asert
            Assert.AreEqual(10, transaccion.ID);
        }

        [TestMethod]
        public void Transaccion_Inicializacion_MontoEsIgual()
        {
            //Arrange
            var transaccion = new Entities_POJO.Transaccion();
            //Act
            transaccion.Monto = 25;
            //Asert
            Assert.AreEqual(25, transaccion.Monto);
        }

        [TestMethod]
        public void Transaccion_Inicializacion_MovimientoEsIgual()
        {
            //Arrange
            var transaccion = new Entities_POJO.Transaccion();
            //Act
            transaccion.Movimiento = "ENTRANTE";
            //Asert
            Assert.AreEqual("ENTRANTE", transaccion.Movimiento);
        }

        [TestMethod]
        public void Transaccion_Inicializacion_FechaEsIgual()
        {
            //Arrange
            var transaccion = new Entities_POJO.Transaccion();
            //Act
            transaccion.Fecha = new DateTime(2020,04,05);
            //Asert
            Assert.AreEqual(new DateTime(2020,04,05), transaccion.Fecha);
        }

        [TestMethod]
        public void Transaccion_Inicializacion_ID_UsuarioEsIgual()
        {
            //Arrange
            var transaccion = new Entities_POJO.Transaccion();
            //Act
            transaccion.ID_Usuario = "117640741";
            //Asert
            Assert.AreEqual("117640741", transaccion.ID_Usuario);
        }

        [TestMethod]
        public void Transaccion_Inicializacion_ID_TrabajoEsIgual()
        {
            //Arrange
            var transaccion = new Entities_POJO.Transaccion();
            //Act
            transaccion.ID_Trabajo = 10;
            //Asert
            Assert.AreEqual(10, transaccion.ID_Trabajo);
        }

        [TestMethod]
        public void Transaccion_Inicializacion_ID_MembresiaEsIgual()
        {
            //Arrange
            var transaccion = new Entities_POJO.Transaccion();
            //Act
            transaccion.ID_Membresia = 10;
            //Asert
            Assert.AreEqual(10, transaccion.ID_Membresia);
        }
    }
}
