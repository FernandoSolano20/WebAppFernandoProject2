using CoreAPI.ReportesManager;
using Entities_POJO;
using Entities_POJO.Reportes.IngresosPeriodoPlataforma;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Web_API.AppCode.Extension;

namespace Web_API.Controllers.Reportes
{
    public class ReportesController : ApiController
    {
        [HttpGet, Route("api/Reportes/IngresosDiarios")]
        public async Task<IHttpActionResult> ReporteIngresosDiarios()
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var response = await Task.Run(() =>
                {
                    ReportesManager manager = new ReportesManager();
                    ApiResponse apiResponse = new ApiResponse();

                    apiResponse.Data = manager.ReporteIngresosDiarios();
                    apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";
                    return apiResponse;
                });

                return Content(HttpStatusCode.OK, response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpGet, Route("api/Reportes/IngresosMensualesPlataforma")]
        public async Task<IHttpActionResult> ReporteIngresosMensualesPlataforma(int PeriodoMeses)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var response = await Task.Run(() =>
                {
                    ReportesManager manager = new ReportesManager();
                    ApiResponse apiResponse = new ApiResponse();

                    var reporte = new IngresosMensuales()
                    {
                        PeriodoMeses = PeriodoMeses,
                        TipoMovimiento = TipoMovimiento.EntrantePlataforma
                    };

                    apiResponse.Data = manager.ReporteIngresosMensualesPlataforma(reporte);
                    apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";
                    return apiResponse;
                });

                return Content(HttpStatusCode.OK, response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }
    }
}
