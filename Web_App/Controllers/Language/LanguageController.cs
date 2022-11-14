using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_App.App_Start;

namespace Web_App.Controllers.Language
{
    public class LanguageController : Controller
    {
        // GET: Language
        public void CambiarLenguaje(string lenguaje, string id, string idEmpresa)
        {
            UserSession.Language = lenguaje;
            UserSession.Id = id;
            UserSession.IdEmpresa = idEmpresa;
        }
    }
}