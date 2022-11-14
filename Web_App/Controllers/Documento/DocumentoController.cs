using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_App.Controllers.Documento
{
    public class DocumentoController : Controller
    {
        // GET: Documento
        public ActionResult vDocumentoFisico()
        {
            return View();
        }

        public ActionResult vDocumentoJuridico()
        {
            return View();
        }
    }
}