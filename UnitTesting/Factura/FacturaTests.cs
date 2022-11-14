using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Factura
{
    [TestClass]
    public class FacturaTests
    {
        [TestMethod]
        public void Factura_Inicializacion_IDEsIgual()
        {
            //Arrange
            var factura = new Entities_POJO.Factura();
            //Act
            factura.ID = 10;
            //Asert
            Assert.AreEqual(10, factura.ID);
        }

        [TestMethod]
        public void Factura_Inicializacion_ID_Transaccion_EsIgual()
        {
            //Arrange
            var factura = new Entities_POJO.Factura();
            //Act
            factura.ID_Transaccion = 10;
            //Asert
            Assert.AreEqual(10, factura.ID_Transaccion);
        }

        [TestMethod]
        public void Factura_Inicializacion_FechaEsIgual()
        {
            //Arrange
            var factura = new Entities_POJO.Factura();
            //Act
            factura.Fecha = new DateTime(2020,04,09);
            //Asert
            Assert.AreEqual(new DateTime(2020, 04, 09), factura.Fecha);
        }

        [TestMethod]
        public void Factura_Inicializacion_ID_ProveedorEsIgual()
        {
            //Arrange
            var factura = new Entities_POJO.Factura();
            //Act
            factura.ID_Proveedor = "117640741";
            //Asert
            Assert.AreEqual("117640741", factura.ID_Proveedor);
        }
    }
}
