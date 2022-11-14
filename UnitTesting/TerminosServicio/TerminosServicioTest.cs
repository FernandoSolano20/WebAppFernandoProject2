using Entities_POJO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace UnitTesting
{
    [TestClass]
    public class TerminosServicioTest
    {
        //Titulo
        [TestMethod]
        public void TerminosServicio_Inicializacion_Titulo_EsIgual()
        {
            //Arrange
            var terminosServicio = new TerminosServicio();
            //Act
            terminosServicio.Titulo = "Licencias";
            //Asert
            Assert.AreEqual("Licencias", terminosServicio.Titulo);
        }

        //Descripcion
        [TestMethod]
        public void TerminosServicio_Inicializacion_Descripcion_EsIgual()
        {
            //Arrange
            var terminosServicio = new TerminosServicio();
            //Act
            terminosServicio.Descripcion = "TipoComercial";
            //Asert
            Assert.AreEqual("TipoComercial", terminosServicio.Descripcion);
        }

        //Estado
        [TestMethod]
        public void TerminosServicio_Inicializacion_Estado_EsIgual()
        {
            //Arrange
            var terminosServicio = new TerminosServicio();
            //Act
            terminosServicio.Estado = "ACT";
            //Asert
            Assert.AreEqual("ACT", terminosServicio.Estado);
        }

        //Idioma
        [TestMethod]
        public void TerminosServicio_Inicializacion_Idioma_EsIgual()
        {
            //Arrange
            var terminosServicio = new TerminosServicio();
            //Act
            terminosServicio.Idioma = "Espanol";
            //Asert
            Assert.AreEqual("Espanol", terminosServicio.Idioma);
        }


    }
}
