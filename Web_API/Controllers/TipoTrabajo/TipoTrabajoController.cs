using CoreAPI;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.ActionFilters;
using System.Web;
using Web_API.AppCode.Extension;

namespace Web_API.Controllers
{

    public class TipoTrabajoController : ApiController
    {
        private ApiResponse apiResponse;
        private TipoTrabajoManager manager;
        public IHttpActionResult Get()
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TipoTrabajoManager();
                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveAll();

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [CatalogosActionFilter]
        public IHttpActionResult Post(Entities_POJO.TipoTrabajo tipoTrabajo)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TipoTrabajoManager();
                manager.Create(tipoTrabajo);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        public IHttpActionResult Get(int id)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var tipoTrabajo = new Entities_POJO.TipoTrabajo { ID = id };

                manager = new TipoTrabajoManager();
                tipoTrabajo = manager.RetrieveByID(tipoTrabajo);

                apiResponse = new ApiResponse();
                apiResponse.Data = tipoTrabajo;

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [CatalogosActionFilter]
        public IHttpActionResult Put(Entities_POJO.TipoTrabajo tipoTrabajo)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TipoTrabajoManager();
                manager.Update(tipoTrabajo);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }

        }
        [CatalogosActionFilter]
        public IHttpActionResult Delete(Entities_POJO.TipoTrabajo tipoTrabajo)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TipoTrabajoManager();
                manager.Delete(tipoTrabajo);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpGet]
        [Route("api/TipoTrabajo/Active")]
        public IHttpActionResult GetActive()
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TipoTrabajoManager();

                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveActive();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";



                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [CatalogosActionFilter]
        [HttpPut]
        [Route("api/TipoTrabajo/UpdateStatus")]
        public IHttpActionResult UpdateStatus(Entities_POJO.TipoTrabajo tipoTrabajo)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TipoTrabajoManager();
                manager.UpdateStatus(tipoTrabajo);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }
    }
}
