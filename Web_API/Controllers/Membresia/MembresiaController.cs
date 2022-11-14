using CoreAPI.MembresiaManager;
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

namespace Web_API.Controllers.Membresia
{
    public class MembresiaController : ApiController
    {
        private ApiResponse apiResponse;
        private MembresiaManager manager;
        public IHttpActionResult Get()
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new MembresiaManager();
                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveAll();

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpPost]
        [Route("api/Membresia/MembresiaRegular")]
        public IHttpActionResult PostMembresiaRegular(Entities_POJO.Membresia membresia)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try { 
            
                manager = new MembresiaManager();
                manager.Create(membresia);

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
                var membresia = new Entities_POJO.Membresia { ID = id };

                manager = new MembresiaManager();
                membresia = manager.RetrieveByID(membresia);

                apiResponse = new ApiResponse();
                apiResponse.Data = membresia;

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        public IHttpActionResult Delete(Entities_POJO.Membresia membresia)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new MembresiaManager();
                manager.Delete(membresia);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        public IHttpActionResult Put(Entities_POJO.Membresia membresia)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new MembresiaManager();
                manager.Update(membresia);

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
        [Route("api/Membresia/MembresiaEstandarActual")]
        public IHttpActionResult GetCurrentStandard(string IdentificacionUsuario)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var membresia = new Entities_POJO.Membresia()
                {
                    ID_Representante = IdentificacionUsuario
                };

                manager = new MembresiaManager();

                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveCurrentStandardMembership(membresia);
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";



                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpGet]
        [Route("api/Membresia/GetIsPremium")]
        public IHttpActionResult GetIsPremium(string IdentificacionUsuario)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var membresia = new Entities_POJO.Membresia()
                {
                    ID_Representante = IdentificacionUsuario
                };

                manager = new MembresiaManager();

                apiResponse = new ApiResponse();
                apiResponse.Data = manager.IsPremium(membresia);

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpGet]
        [Route("api/Membresia/MembresiaPremiumActual")]
        public IHttpActionResult GetCurrentPremium(string IdentificacionUsuario)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var membresia = new Entities_POJO.Membresia()
                {
                    ID_Representante = IdentificacionUsuario
                };

                manager = new MembresiaManager();

                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveCurrentPremiumMembership(membresia);
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";



                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpPut]
        [Route("api/Membresia/UpdateDate")]
        public IHttpActionResult UpdateDate(Entities_POJO.Membresia membresia)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new MembresiaManager();

                /*Se retorna el valor de la membresia actualizada (con la actualizacion de la fecha)
                Se quiere mostrar en el mensaje de respuesta la fecha actualizada. */
                var membresiaFinal = manager.UpdateStandardDate(membresia);

                apiResponse = new ApiResponse();
                apiResponse.Message = "El pago se ha realizado correctamente. Estará disponible hasta " + membresiaFinal.Fecha;

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpPut]
        [Route("api/Membresia/UpdatePremiumDate")]
        public IHttpActionResult UpdatePremiumDate(Entities_POJO.Membresia membresia)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new MembresiaManager();

                /*Se retorna el valor de la membresia actualizada (con la actualizacion de la fecha)
                Se quiere mostrar en el mensaje de respuesta la fecha actualizada. */
                var membresiaFinal = manager.UpdatePremiumDate(membresia);

                apiResponse = new ApiResponse();
                apiResponse.Message = "El pago se ha realizado correctamente. Premium estará disponible hasta " + membresiaFinal.Fecha;

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }
    }
}
