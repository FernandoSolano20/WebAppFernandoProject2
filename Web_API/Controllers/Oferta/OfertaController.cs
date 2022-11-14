using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoreAPI.OfertaManager;
using CoreAPI.SolicitudManager;
using Entities_POJO;
using Excepciones;
using Web_API.AppCode.Extension;

namespace Web_API.Controllers.Oferta
{
    public class OfertaController : ApiController
    {
        private ApiResponse apiResponse;
        [HttpGet]
        [Route("api/Oferta/GetByEmpresa")]
        public IHttpActionResult GetByEmpresa(string idEmpresa)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var mng = new OfertaManager();
                apiResponse = new ApiResponse();
                apiResponse.Data = mng.RetrieveAllByEmpresa(new Entities_POJO.Oferta()
                {
                    IdEmpresa = idEmpresa
                });

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpPost]
        [Route("api/Oferta")]
        public IHttpActionResult Post(Entities_POJO.Oferta oferta)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var mng = new OfertaManager();
                apiResponse = new ApiResponse();
                mng.Create(oferta);
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";


                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpGet]
        [Route("api/Oferta/GetAverage")]
        public IHttpActionResult GetAverageOferta(string idSolicitud)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var mng = new OfertaManager();
                apiResponse = new ApiResponse();
                apiResponse.Data = mng.RetrieveAverage(new Entities_POJO.Oferta()
                {
                    IdSolicitud = Int32.Parse(idSolicitud)
                });

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpGet]
        [Route("api/Oferta/GetLow")]
        public IHttpActionResult GetLowestOferta(string idSolicitud)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var mng = new OfertaManager();
                apiResponse = new ApiResponse();
                apiResponse.Data = mng.RetrieveLowest(new Entities_POJO.Oferta()
                {
                    IdSolicitud = Int32.Parse(idSolicitud)
                });

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpPut]
        [Route("api/Oferta")]
        public IHttpActionResult Put(Entities_POJO.Oferta entity)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var mng = new OfertaManager();
                apiResponse = new ApiResponse();
                mng.Update(entity);
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpDelete]
        [Route("api/Oferta")]
        public IHttpActionResult Delete(Entities_POJO.Oferta entity)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var mng = new OfertaManager();
                apiResponse = new ApiResponse();
                mng.Delete(entity);
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpPut]
        [Route("api/Oferta/UpdateStatus")]
        public IHttpActionResult UpdateStatus(Entities_POJO.Oferta entity)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var mng = new OfertaManager();
                apiResponse = new ApiResponse();
                mng.UpdateStatus(entity);
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpGet]
        [Route("api/Oferta/ObtenerPorSolicitud")]
        public IHttpActionResult GetBySolicitudId(int ID_Solicitud)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var mng = new OfertaManager();
                apiResponse = new ApiResponse();
                apiResponse.Data = mng.RetrieveAllBySolicitudId(new Entities_POJO.Oferta()
                {
                    IdSolicitud = ID_Solicitud
                });

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpGet]
        [Route("api/Oferta/ObtenerConEmpresa")]
        public IHttpActionResult GetWithCompanyData(string ID_Empresa, int ID_Solicitud)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var mng = new OfertaManager();
                apiResponse = new ApiResponse();
                apiResponse.Data = mng.RetrieveConEmpresa(new Entities_POJO.Oferta()
                {
                    IdSolicitud = ID_Solicitud,
                    IdEmpresa = ID_Empresa
                });

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }
    }
}
