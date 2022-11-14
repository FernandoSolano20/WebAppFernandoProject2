using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Solicitud
{
    [TestClass]
    public class SolicitudTest
    {
        [TestMethod]
        public void TipoTrabajo_Inicializacion_IDEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.ID = 10;
            //Asert
            Assert.AreEqual(10, solicitud.ID);

        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_TituloEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.Titulo = "Test";
            //Asert
            Assert.AreEqual("Test", solicitud.Titulo);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_DescripcionEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.Descripcion = "Test";
            //Asert
            Assert.AreEqual("Test", solicitud.Descripcion);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_ProvinciaEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.Provincia = "Test";
            //Asert
            Assert.AreEqual("Test", solicitud.Provincia);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_CantonEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.Canton = "Test";
            //Asert
            Assert.AreEqual("Test", solicitud.Canton);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_DistritoEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.Distrito = "Test";
            //Asert
            Assert.AreEqual("Test", solicitud.Distrito);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_DireccionEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.Direccion = "Test";
            //Asert
            Assert.AreEqual("Test", solicitud.Direccion);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_LatitudEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.Latitud = "Test";
            //Asert
            Assert.AreEqual("Test", solicitud.Latitud);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_LongitudEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.Longitud = "Test";
            //Asert
            Assert.AreEqual("Test", solicitud.Longitud);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_FechaInicioEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.FechaInicio = new DateTime(1999,10,10);
            //Asert
            Assert.AreEqual(new DateTime(1999, 10, 10), solicitud.FechaInicio);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_FechaFinalEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.FechaFin = new DateTime(1999, 10, 10);
            //Asert
            Assert.AreEqual(new DateTime(1999, 10, 10), solicitud.FechaFin);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_CodigoQREsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.CodigoQR = "Test";
            //Asert
            Assert.AreEqual("Test", solicitud.CodigoQR);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_CalificacionTrabajoEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.CalificacionTrabajo = 5;
            //Asert
            Assert.AreEqual(5, solicitud.CalificacionTrabajo);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_ComentarioTrabajoEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.ComentarioTrabajo = "Test";
            //Asert
            Assert.AreEqual("Test", solicitud.ComentarioTrabajo);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_CalificacionEmpresaEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.CalificacionEmpresa = 5;
            //Asert
            Assert.AreEqual(5, solicitud.CalificacionEmpresa);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_ComentarioEmpresaEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.ComentarioEmpresa = "Test";
            //Asert
            Assert.AreEqual("Test", solicitud.ComentarioEmpresa);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_CalificacionTrabajadorEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.CalificacionTrabajador = 5;
            //Asert
            Assert.AreEqual(5, solicitud.CalificacionTrabajador);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_ComentarioTrabajadorEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.ComentarioTrabajador = "Test";
            //Asert
            Assert.AreEqual("Test", solicitud.ComentarioTrabajador);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_PresupuestoEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.Presupuesto = 500;
            //Asert
            Assert.AreEqual(500, solicitud.Presupuesto);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_EstadoEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.Estado = "Test";
            //Asert
            Assert.AreEqual("Test", solicitud.Estado);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_PrecioFinalEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.PrecioFinal = 100;
            //Asert
            Assert.AreEqual(100, solicitud.PrecioFinal);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_ID_ClienteEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.ID_Cliente = "Test";
            //Asert
            Assert.AreEqual("Test", solicitud.ID_Cliente);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_ID_EmpresaEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.ID_Empresa = "Test";
            //Asert
            Assert.AreEqual("Test", solicitud.ID_Empresa);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_EspecialidadesEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.Especialidades = "Test";
            //Asert
            Assert.AreEqual("Test", solicitud.Especialidades);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_TipoTrabajosEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.TipoTrabajos = "Test";
            //Asert
            Assert.AreEqual("Test", solicitud.TipoTrabajos);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_CedulaEmpresaEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.CedulaEmpresa = "Test";
            //Asert
            Assert.AreEqual("Test", solicitud.CedulaEmpresa);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_NombreComercialEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.NombreComercial = "Test";
            //Asert
            Assert.AreEqual("Test", solicitud.NombreComercial);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_ID_QREsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.ID_QR = 10;
            //Asert
            Assert.AreEqual(10, solicitud.ID_QR);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_CostoTotalEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.CostoTotal = 10;
            //Asert
            Assert.AreEqual(10, solicitud.CostoTotal);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_CostoNetoEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.CostoNeto = 10;
            //Asert
            Assert.AreEqual(10, solicitud.CostoNeto);
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_ImpuestosEsIgual()
        {
            //Arrange
            var solicitud = new Entities_POJO.Solicitud();
            //Act
            solicitud.Impuestos = 10;
            //Asert
            Assert.AreEqual(10, solicitud.Impuestos);
        }

    }
}
