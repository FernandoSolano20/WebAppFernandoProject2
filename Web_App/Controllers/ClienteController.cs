using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Entities_POJO;
using Newtonsoft.Json;
using POJO_Entities.Entities;
using Web_App.App_Start;
using Web_App.AppCode.Helper;
using Web_App.Models;

namespace Web_App.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        string URL_API_LISTs = "https://localhost:44347/api/";
        public ActionResult Registrar()
        {
            return View("~/Views/Cliente/Registrar.cshtml");
        }

        public ActionResult Dashboard()
        {
            var endpoint = "Solicitud/ObtenerClienteSolicitudes?id=" + UserSession.Id; 
            var client = new HttpClient { BaseAddress = new Uri(URL_API_LISTs + endpoint) };
            var responseMessage = client.GetAsync(URL_API_LISTs + endpoint, HttpCompletionOption.ResponseContentRead);
            var resultAsync = responseMessage.GetAwaiter().GetResult().Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(resultAsync.GetAwaiter().GetResult());
            var solicitudes = JsonConvert.DeserializeObject<List<Entities_POJO.Solicitud>>(apiResponse.Data.ToString());

            var solicitud = new SolicitudCalendar();
            var data = solicitud.ConvertToSolicitudCalendar(solicitudes);

            ViewData["Calendar"] = data.ToJson();

            return View("Dashboard");
        }

        
    }
}