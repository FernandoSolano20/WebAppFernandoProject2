using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Detalle
{
    [TestClass]
    public class DetalleTests
    {
        [TestMethod]
        public void Detalle_Inicializacion_IDEsIgual()
        {
            //Arrange
            var detalle = new Entities_POJO.Detalle();
            //Act
            detalle.ID = 10;
            //Asert
            Assert.AreEqual(10, detalle.ID);
        }

        [TestMethod]
        public void Detalle_Inicializacion_NombreEsIgual()
        {
            //Arrange
            var detalle = new Entities_POJO.Detalle();
            //Act
            detalle.Nombre = "Compra membresia";
            //Asert
            Assert.AreEqual("Compra membresia", detalle.Nombre);
        }

        [TestMethod]
        public void Detalle_Inicializacion_PrecioEsIgual()
        {
            //Arrange
            var detalle = new Entities_POJO.Detalle();
            //Act
            detalle.Precio = 10;
            //Asert
            Assert.AreEqual(10, detalle.Precio);
        }

        [TestMethod]
        public void Detalle_Inicializacion_CantidadEsIgual()
        {
            //Arrange
            var detalle = new Entities_POJO.Detalle();
            //Act
            detalle.Cantidad = 10;
            //Asert
            Assert.AreEqual(10, detalle.Cantidad);
        }

        [TestMethod]
        public void Detalle_Inicializacion_ID_FacturaEsIgual()
        {
            //Arrange
            var detalle = new Entities_POJO.Detalle();
            //Act
            detalle.ID_Factura = 10;
            //Asert
            Assert.AreEqual(10, detalle.ID_Factura);
        }

        [TestMethod]
        public void Detalle_Inicializacion_DescripcionEsIgual()
        {
            //Arrange
            var detalle = new Entities_POJO.Detalle();
            //Act
            detalle.Descripcion = "Compra";
            //Asert
            Assert.AreEqual("Compra", detalle.Descripcion);
        }


    }
}
