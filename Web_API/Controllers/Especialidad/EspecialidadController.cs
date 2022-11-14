using CoreAPI.EspecialidadManager;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.ActionFilters;
using Web_API.AppCode.Extension;

namespace Web_API.Controllers.Especialidad
{
    public class EspecialidadController : ApiController
    {
        private ApiResponse apiResponse;
        private EspecialidadManager manager;
        public IHttpActionResult Get()
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new EspecialidadManager();
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
        public IHttpActionResult Post(Entities_POJO.Especialidad especialidad)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new EspecialidadManager();
                manager.Create(especialidad);

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
                var especialidad = new Entities_POJO.Especialidad { ID = id };

                manager = new EspecialidadManager();
                especialidad = manager.RetrieveByID(especialidad);

                apiResponse = new ApiResponse();
                apiResponse.Data = especialidad;

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [CatalogosActionFilter]
        public IHttpActionResult Put(Entities_POJO.Especialidad especialidad)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new EspecialidadManager();
                manager.Update(especialidad);

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
        public IHttpActionResult Delete(Entities_POJO.Especialidad especialidad)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new EspecialidadManager();
                manager.Delete(especialidad);

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
        [Route("api/Especialidad/Active")]
        public IHttpActionResult GetActive()
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new EspecialidadManager();

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
        [Route("api/Especialidad/UpdateStatus")]
        public IHttpActionResult UpdateStatus(Entities_POJO.Especialidad especialidad)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new EspecialidadManager();
                manager.UpdateStatus(especialidad);

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
