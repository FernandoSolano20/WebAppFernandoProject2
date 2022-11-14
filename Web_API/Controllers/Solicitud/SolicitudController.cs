using CoreAPI.SolicitudManager;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.AppCode.Extension;

namespace Web_API.Controllers.Solicitud
{
    public class SolicitudController : ApiController
    {
        private ApiResponse apiResponse;
        private SolicitudManager manager;
        public IHttpActionResult Get()
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new SolicitudManager();
                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveAll();

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }


        public IHttpActionResult Post(Entities_POJO.Solicitud solicitud)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new SolicitudManager();


                apiResponse = new ApiResponse();
                apiResponse.Data = manager.Create(solicitud);
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
                var solicitud = new Entities_POJO.Solicitud { ID = id };

                manager = new SolicitudManager();
                solicitud = manager.RetrieveByID(solicitud);

                apiResponse = new ApiResponse();
                apiResponse.Data = solicitud;

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        //Metodo que retorna la lista de solicitudes activas del usuario
        [HttpGet]
        [Route("api/Solicitud/ActivoPorUsuario")]
        public IHttpActionResult GetSolicitudesActivas(string IdentificacionUsuario)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var solicitud = new Entities_POJO.Solicitud { ID_Cliente = IdentificacionUsuario };

                manager = new SolicitudManager();

                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveIdClienteActivo(solicitud);

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        //Metodo que retorna la lista de solicitudes activas del usuario
        [HttpGet]
        [Route("api/Solicitud/SolicitudID")]
        public IHttpActionResult SolicitudID(int id)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var solicitud = new Entities_POJO.Solicitud { ID = id };

                manager = new SolicitudManager();

                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveByIDConFormatoPrecio(solicitud);

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        //Metodo que retorna la lista de solicitudes pendientes de adjudicar
        [HttpGet]
        [Route("api/Solicitud/PendienteAdjudicarPorUsuario")]
        public IHttpActionResult GetSolicitudesPendientesAdjudicar(string IdentificacionUsuario)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var solicitud = new Entities_POJO.Solicitud { ID_Cliente = IdentificacionUsuario };

                manager = new SolicitudManager();

                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveIdClientePendienteAdjudicar(solicitud);

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        //Metodo que retorna la lista de solicitudes pendientes de calificar
        [HttpGet]
        [Route("api/Solicitud/PendienteCalificarPorUsuario")]
        public IHttpActionResult GetSolicitudesPendientesCalificar(string IdentificacionUsuario)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var solicitud = new Entities_POJO.Solicitud { ID_Cliente = IdentificacionUsuario };

                manager = new SolicitudManager();

                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveIdClientePendienteCalificar(solicitud);

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        //Metodo que retorna la lista de solicitudes pendientes de calificar
        [HttpGet]
        [Route("api/Solicitud/CompletoPorUsuario")]
        public IHttpActionResult GetSolicitudesCompletas(string IdentificacionUsuario)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var solicitud = new Entities_POJO.Solicitud { ID_Cliente = IdentificacionUsuario };

                manager = new SolicitudManager();

                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveIdClienteCompleto(solicitud);

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        //Metodo que retorna la lista de solicitudes pendientes de calificar
        [HttpGet]
        [Route("api/Solicitud/PorIniciarPorUsuario")]
        public IHttpActionResult GetSolicitudesPorIniciar(string IdentificacionUsuario)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var solicitud = new Entities_POJO.Solicitud { ID_Cliente = IdentificacionUsuario };

                manager = new SolicitudManager();

                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveIdClientePorIniciar(solicitud);

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        public IHttpActionResult Put(Entities_POJO.Solicitud solicitud)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new SolicitudManager();
                manager.Update(solicitud);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }

        }

        public IHttpActionResult Delete(Entities_POJO.Solicitud solicitud)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new SolicitudManager();
                manager.Delete(solicitud);

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
        [Route("api/Solicitud/Active")]
        public IHttpActionResult GetActive()
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new SolicitudManager();

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

        [HttpPut]
        [Route("api/Solicitud/UpdateStatus")]
        public IHttpActionResult UpdateStatus(Entities_POJO.Solicitud solicitud)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new SolicitudManager();
                manager.UpdateStatus(solicitud);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpPut]
        [Route("api/Solicitud/UpdateStatusPendiente")]
        public IHttpActionResult UpdateStatusPendiente(Entities_POJO.Solicitud solicitud)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new SolicitudManager();
                manager.UpdateStatusPendiente(solicitud);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpPut]
        [Route("api/Solicitud/AceptarOferta")]
        public IHttpActionResult AceptarOferta(Entities_POJO.Solicitud solicitud)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new SolicitudManager();
                manager.AceptarOferta(solicitud);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpPut]
        [Route("api/Solicitud/AccionTrabajo")]
        public IHttpActionResult AccionTrabajo(Entities_POJO.Solicitud solicitud)
        {

            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new SolicitudManager();
                manager.AccionSolicitud(solicitud);

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
        [Route("api/Solicitud/SolicitudConEmpresa")]
        public IHttpActionResult GetSolicitudEmpresa(int ID_Solicitud)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var solicitud = new Entities_POJO.Solicitud { ID = ID_Solicitud };

                manager = new SolicitudManager();
                solicitud = manager.RetrieveISolicitudEmpresa(solicitud);

                apiResponse = new ApiResponse();
                apiResponse.Data = solicitud;

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }


        [HttpGet]
        [Route("api/Solicitud/ObtenerSolictudesParaOferentes")]
        public IHttpActionResult ObtenerSolictudesParaOferentes(string id)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new SolicitudManager();
                apiResponse = new ApiResponse();
                apiResponse.Data = manager.GetOferentesSolictudMatching(new Usuario()
                {
                    Identificacion = id
                });

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }
        [HttpGet]
        [Route("api/Solicitud/SolicitudPrecioCompleto")]
        public IHttpActionResult SolicitudPrecioCompleto(int ID_Solicitud)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var solicitud = new Entities_POJO.Solicitud { ID = ID_Solicitud };

                manager = new SolicitudManager();
                solicitud = manager.RetrieveByIDPrecioCompleto(solicitud);

                apiResponse = new ApiResponse();
                apiResponse.Data = solicitud;

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpPut]
        [Route("api/Solicitud/FinalizarTrabajo")]
        public IHttpActionResult FinalizarTrabajo(Entities_POJO.Solicitud solicitud)
        {

            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new SolicitudManager();
                manager.PagarSolicitud(solicitud);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpPut]
        [Route("api/Solicitud/CalificarSolicitud")]
        public IHttpActionResult CalificarSolicitud(Entities_POJO.Solicitud solicitud)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new SolicitudManager();
                manager.UpdateCalificacion(solicitud);

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
        [Route("api/Solicitud/ObtenerClienteSolicitudes")]
        public IHttpActionResult GetClienteSolicitudes(string id)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new SolicitudManager();
                apiResponse = new ApiResponse();
                apiResponse.Data = manager.GetClienteSolicitudes(new Entities_POJO.Solicitud()
                {
                    ID_Cliente = id
                });

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpGet]
        [Route("api/Solicitud/ObtenerOferenteSolicitudes")]
        public IHttpActionResult GetOferenteSolicitudes(string id)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new SolicitudManager();
                apiResponse = new ApiResponse();
                apiResponse.Data = manager.GetOferenteSolicitudes(new Entities_POJO.Solicitud()
                {
                    ID_Empresa = id
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
