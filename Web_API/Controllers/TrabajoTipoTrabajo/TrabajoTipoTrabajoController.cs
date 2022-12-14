using CoreAPI.TrabajoTrabajoTipoTrabajoManager;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.AppCode.Extension;

namespace Web_API.Controllers.TrabajoTrabajoTipoTrabajo
{
    public class TrabajoTipoTrabajoController : ApiController
    {
        private ApiResponse apiResponse;
        private TrabajoTipoTrabajoManager manager;
        public IHttpActionResult Get()
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TrabajoTipoTrabajoManager();
                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveAll();

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        public IHttpActionResult Post(TrabajoTipoTrabajo trabajoTipoTrabajo)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TrabajoTipoTrabajoManager();
                manager.Create(trabajoTipoTrabajo);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        public IHttpActionResult Get(int ID_Trabajo, int ID_Tipo_Trabajo)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var trabajoTipoTrabajo = new TrabajoTipoTrabajo()
                {
                    ID_Trabajo = ID_Trabajo,
                    ID_Tipo_Trabajo = ID_Tipo_Trabajo
                };

                manager = new TrabajoTipoTrabajoManager();
                trabajoTipoTrabajo = manager.RetrieveByID(trabajoTipoTrabajo);

                apiResponse = new ApiResponse();
                apiResponse.Data = trabajoTipoTrabajo;

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        public IHttpActionResult Put(TrabajoTipoTrabajo trabajoTipoTrabajo)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TrabajoTipoTrabajoManager();
                manager.Update(trabajoTipoTrabajo);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }

        }
        public IHttpActionResult Delete(TrabajoTipoTrabajo trabajoTipoTrabajo)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TrabajoTipoTrabajoManager();
                manager.Delete(trabajoTipoTrabajo);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }
        
        //Permite retornar los tipos de trabajo relacionados a una solicitud de trabajo
        [HttpGet, Route("api/TrabajoTipoTrabajo/TiposTrabajoPorTrabajo")]
        public IHttpActionResult GetTiposTrabajoPorTrabajo(int ID_Trabajo)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var trabajoTipoTrabajo = new TrabajoTipoTrabajo()
                {
                    ID_Trabajo = ID_Trabajo
                };

                manager = new TrabajoTipoTrabajoManager();

                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveIDTrabajo(trabajoTipoTrabajo);

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }
    }
}
