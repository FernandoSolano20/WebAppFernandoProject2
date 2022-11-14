using CoreAPI.Transaccion;
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

namespace Web_API.Controllers.Transaccion
{
    public class TransaccionController : ApiController
    {
        private ApiResponse apiResponse;
        private TransaccionManager manager;
        public IHttpActionResult Get()
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TransaccionManager();
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
        [Route("api/Transaccion/TransaccionTrabajo")]
        public IHttpActionResult PostTransaccionTrabajo(Entities_POJO.Transaccion transaccion)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TransaccionManager();
                manager.CreateTransaccionTrabajo(transaccion);

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
        [Route("api/Transaccion/TransaccionMembresia")]
        public IHttpActionResult PostTransaccionMembresia(Entities_POJO.Transaccion transaccion)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TransaccionManager();
                manager.CreateTransaccionMembresia(transaccion);

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
                var transaccion = new Entities_POJO.Transaccion { ID = id };

                manager = new TransaccionManager();
                transaccion = manager.RetrieveByID(transaccion);

                apiResponse = new ApiResponse();
                apiResponse.Data = transaccion;

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [CatalogosActionFilter]
        public IHttpActionResult Put(Entities_POJO.Transaccion transaccion)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TransaccionManager();
                manager.Update(transaccion);

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
        public IHttpActionResult Delete(Entities_POJO.Transaccion transaccion)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TransaccionManager();
                manager.Delete(transaccion);

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
