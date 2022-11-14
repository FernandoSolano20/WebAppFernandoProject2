using CoreAPI.TrabajoEspecialidadManager;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.AppCode.Extension;

namespace Web_API.Controllers.TrabajoEspecialidad
{
    public class TrabajoEspecialidadController : ApiController
    {
        private ApiResponse apiResponse;
        private TrabajoEspecialidadManager manager;
        public IHttpActionResult Get()
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TrabajoEspecialidadManager();
                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveAll();

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        public IHttpActionResult Post(Entities_POJO.TrabajoEspecialidad trabajoEspecialidad)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TrabajoEspecialidadManager();
                manager.Create(trabajoEspecialidad);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        public IHttpActionResult Get(int ID_Trabajo, int ID_Especialidad)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var trabajoEspecialidad = new Entities_POJO.TrabajoEspecialidad()
                {
                    ID_Trabajo = ID_Trabajo,
                    ID_Especialidad = ID_Especialidad
                };

                manager = new TrabajoEspecialidadManager();
                trabajoEspecialidad = manager.RetrieveByID(trabajoEspecialidad);

                apiResponse = new ApiResponse();
                apiResponse.Data = trabajoEspecialidad;

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        public IHttpActionResult Delete(Entities_POJO.TrabajoEspecialidad trabajoEspecialidad)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new TrabajoEspecialidadManager();
                manager.Delete(trabajoEspecialidad);

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
        [HttpGet, Route("api/TrabajoEspecialidad/EspecialidadesPorTrabajo")]
        public IHttpActionResult GetEspecialidadesPorTrabajo(int ID_Trabajo)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var trabajoEspecialidad = new Entities_POJO.TrabajoEspecialidad()
                {
                    ID_Trabajo = ID_Trabajo
                };

                manager = new TrabajoEspecialidadManager();

                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveIDTrabajo(trabajoEspecialidad);

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }
    }
}
