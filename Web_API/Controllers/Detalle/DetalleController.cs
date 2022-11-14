using CoreAPI.Detalle;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.AppCode.Extension;

namespace Web_API.Controllers.Detalle
{
    public class DetalleController : ApiController
    {
        private ApiResponse apiResponse;
        private DetalleManager manager;
        public IHttpActionResult Get()
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new DetalleManager();
                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveAll();

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        
        public IHttpActionResult Post(Entities_POJO.Detalle detalle)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new DetalleManager();
                manager.Create(detalle);

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
                var detalle = new Entities_POJO.Detalle { ID = id };

                manager = new DetalleManager();
                detalle = manager.RetrieveByID(detalle);

                apiResponse = new ApiResponse();
                apiResponse.Data = detalle;

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        
        public IHttpActionResult Put(Entities_POJO.Detalle detalle)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new DetalleManager();
                manager.Update(detalle);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }

        }
        public IHttpActionResult Delete(Entities_POJO.Detalle detalle)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new DetalleManager();
                manager.Delete(detalle);

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
