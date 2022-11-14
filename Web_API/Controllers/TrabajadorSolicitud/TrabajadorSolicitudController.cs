using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CoreAPI.TrabajoSolicitud;
using Entities_POJO;
using Excepciones;
using Web_API.AppCode.Extension;

namespace Web_API.Controllers.TipoTrabajo
{
    public class TrabajadorSolicitudController : ApiController
    {
        private ApiResponse apiResponse;
        [HttpPost]
        [Route("api/TrabajadorSolicitud")]
        public async Task<IHttpActionResult> Post(TrabajadorSolicitud entity)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new TrabajadorSolicitudManager();
                    mng.Create(entity);

                    apiResponse = new ApiResponse();
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

        [HttpGet]
        [Route("api/TrabajadorSolicitud/GetAverage")]
        public async Task<IHttpActionResult> GetAverage(string idSolicitud)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new TrabajadorSolicitudManager();
                    
                    apiResponse = new ApiResponse();
                    apiResponse.Data = mng.Avergae(new TrabajadorSolicitud()
                    {
                        IdSolicitud = Int32.Parse(idSolicitud)
                    });

                    return apiResponse;
                });
                return Content(HttpStatusCode.OK, response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpGet]
        [Route("api/TrabajadorSolicitud/GetLow")]
        public async Task<IHttpActionResult> GetLowest(string idSolicitud)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new TrabajadorSolicitudManager();

                    apiResponse = new ApiResponse();
                    apiResponse.Data = mng.Lowest(new TrabajadorSolicitud()
                    {
                        IdSolicitud = Int32.Parse(idSolicitud)
                    });

                    return apiResponse;
                });
                return Content(HttpStatusCode.OK, response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpDelete]
        [Route("api/TrabajadorSolicitud")]
        public async Task<IHttpActionResult> Delete(TrabajadorSolicitud entity)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new TrabajadorSolicitudManager();
                    mng.Delete(entity);

                    apiResponse = new ApiResponse();
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

        [HttpGet]
        [Route("api/TrabajadorSolicitud/InformacionTrabajadores")]
        public async Task<IHttpActionResult> TrabajadoresData(string ID_Empresa, int ID_Solicitud)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            var trabajadorSolicitud = new TrabajadorSolicitud()
            {
                IdEmpresa = ID_Empresa,
                IdSolicitud = ID_Solicitud
            };

            try
            {
                var response = await Task.Run(() =>
                {
                    apiResponse = new ApiResponse();
                    var mng = new TrabajadorSolicitudManager();
                    apiResponse.Data = mng.RetrieveTrabajadoresData(trabajadorSolicitud);
                    return apiResponse;
                });
                return Ok(response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpPut]
        [Route("api/TrabajadorSolicitud/IngresarHorasTrabajadas")]
        public async Task<IHttpActionResult> IngresarHorasTrabajadas(TrabajadorSolicitud trabajadorSolicitud)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);

            try
            {
                var response = await Task.Run(() =>
                {
                    apiResponse = new ApiResponse();
                    var mng = new TrabajadorSolicitudManager();
                    mng.UpdateHorasTrabajadas(trabajadorSolicitud);
                    apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";
                    return apiResponse;
                });
                return Ok(response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpPut]
        [Route("api/TrabajadorSolicitud/FijarPrecioFinal")]
        public async Task<IHttpActionResult> ObtenerPrecioFinal(TrabajadorSolicitud trabajadorSolicitud)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);

            try
            {
                var response = await Task.Run(() =>
                {
                    apiResponse = new ApiResponse();
                    var mng = new TrabajadorSolicitudManager();
                    mng.FijarPrecioFinal(trabajadorSolicitud);

                    apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                    return apiResponse;
                });
                return Ok(response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }
    }
}
