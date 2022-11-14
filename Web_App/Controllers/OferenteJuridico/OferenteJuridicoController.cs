using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Entities_POJO;
using Newtonsoft.Json;
using Web_App.App_Start;
using Web_App.AppCode.Helper;
using Web_App.Models;

namespace Web_App.Controllers
{
    public class OferenteJuridicoController : Controller
    {
        string URL_API_LISTs = "https://localhost:44347/api/";
        // GET: OferenteJuridico
        public ActionResult Registrar()
        {
            return View();
        }

        public ActionResult vDashboardOferenteJuridico()
        {
            var endpoint = "Solicitud/ObtenerOferenteSolicitudes?id=" + UserSession.IdEmpresa;
            var client = new HttpClient { BaseAddress = new Uri(URL_API_LISTs + endpoint) };
            var responseMessage = client.GetAsync(URL_API_LISTs + endpoint, HttpCompletionOption.ResponseContentRead);
            var resultAsync = responseMessage.GetAwaiter().GetResult().Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(resultAsync.GetAwaiter().GetResult());
            var solicitudes = JsonConvert.DeserializeObject<List<Entities_POJO.Solicitud>>(apiResponse.Data.ToString());

            var solicitud = new SolicitudCalendar();
            var data = solicitud.ConvertToSolicitudCalendar(solicitudes);

            ViewData["Calendar"] = data.ToJson();
            return View();
        }

        public ActionResult Solicitudes()
        {
            return View();
        }

        public ActionResult AgregarTrabajadores()
        {
            return View();
        }

        public ActionResult RegistrarTrabajador()
        {
            return View();
        }
    }
}