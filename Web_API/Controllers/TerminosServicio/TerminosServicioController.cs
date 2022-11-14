using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoreAPI;
using Entities_POJO;
using Excepciones;
using Web_API.ActionFilters;
using Web_API.AppCode.Extension;


namespace Web_API.Controllers
{
    public class TerminosServicioController : ApiController
    {
        private ApiResponse apiResponse;
        private TerminosServicioManager manager;

        //Get all
        public IHttpActionResult Get()
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TerminosServicioManager();
                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveAll();

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }


        //Post
        [CatalogosActionFilter]
        public IHttpActionResult Post(TerminosServicio terminosServicio)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TerminosServicioManager();
                manager.Create(terminosServicio);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        //Get by: Titulo
        public IHttpActionResult Get(string titulo)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var terminosServicio = new TerminosServicio { Titulo = titulo };

                manager = new TerminosServicioManager();
                terminosServicio = manager.RetrieveByTitulo(terminosServicio);

                apiResponse = new ApiResponse();
                apiResponse.Data = terminosServicio;

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        //Put
        [CatalogosActionFilter]
        public IHttpActionResult Put(TerminosServicio terminosServicio)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TerminosServicioManager();
                manager.Update(terminosServicio);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        //Delete
        [CatalogosActionFilter]
        public IHttpActionResult Delete(TerminosServicio terminosServicio)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TerminosServicioManager();
                manager.Delete(terminosServicio);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        //Retrieve Estado
        [HttpGet]
        [Route("api/TerminosServicio/Active")]
        public IHttpActionResult GetActive()
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TerminosServicioManager();

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

        //Update Estado
        [CatalogosActionFilter]
        [HttpPut]
        [Route("api/TerminosServicio/UpdateStatus")]
        public IHttpActionResult UpdateStatus(TerminosServicio terminosServicio)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TerminosServicioManager();
                manager.UpdateStatus(terminosServicio);

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
