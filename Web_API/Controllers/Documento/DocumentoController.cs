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

namespace Web_API.Controllers.Documento
{
    public class DocumentoController : ApiController
    {
        private ApiResponse apiResponse;
        private CoreAPI.DocumentoManager.DocumentoManager manager;
        public IHttpActionResult Get()
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new CoreAPI.DocumentoManager.DocumentoManager();
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
        [Route("api/Documento/DocumentoProveedor")]
        public IHttpActionResult Post(Entities_POJO.Documento documento)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                documento.TipoDocumento = TipoDocumento.DOCUMENTO_PROVEEDOR;
                documento.Estado = Estado.ACT;

                manager = new CoreAPI.DocumentoManager.DocumentoManager();
                manager.Create(documento);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpPost]
        [Route("api/Documento/FotoInicialTrabajo")]
        public IHttpActionResult PostFotoInicialTrabajo(Entities_POJO.Documento documento)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                documento.TipoDocumento = TipoDocumento.FOTOGRAFIA_TRABAJO_INICIAL;
                documento.Estado = Estado.ACT;

                manager = new CoreAPI.DocumentoManager.DocumentoManager();
                manager.Create(documento);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpPost]
        [Route("api/Documento/FotoFinalTrabajo")]
        public IHttpActionResult PostFotoFinalTrabajo(Entities_POJO.Documento documento)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                documento.TipoDocumento = TipoDocumento.FOTOGRAFIA_TRABAJO_FINAL;
                documento.Estado = Estado.ACT;

                manager = new CoreAPI.DocumentoManager.DocumentoManager();
                manager.Create(documento);

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
                var documento = new Entities_POJO.Documento { ID = id };

                manager = new CoreAPI.DocumentoManager.DocumentoManager();
                documento = manager.RetrieveByID(documento);

                apiResponse = new ApiResponse();
                apiResponse.Data = documento;

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpGet]
        [Route("api/Documento/ObtenerPorUsuario")]
        public IHttpActionResult Get(string IdentificacionUsuario)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var documento = new Entities_POJO.Documento {
                    ID_Propietario = IdentificacionUsuario,
                    TipoDocumento = TipoDocumento.DOCUMENTO_PROVEEDOR
                };

                manager = new CoreAPI.DocumentoManager.DocumentoManager();
                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveByUserID(documento);

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpGet]
        [Route("api/Documento/ObtenerFotosIniciales")]
        public IHttpActionResult GetFotosIniciales(string Identificador)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var documento = new Entities_POJO.Documento
                {
                    ID_Propietario = Identificador,
                    TipoDocumento = TipoDocumento.FOTOGRAFIA_TRABAJO_INICIAL
                };

                manager = new CoreAPI.DocumentoManager.DocumentoManager();
                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveByUserID(documento);

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        [HttpGet]
        [Route("api/Documento/ObtenerFotosFinales")]
        public IHttpActionResult GetFotosFinales(string Identificador)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var documento = new Entities_POJO.Documento
                {
                    ID_Propietario = Identificador,
                    TipoDocumento = TipoDocumento.FOTOGRAFIA_TRABAJO_FINAL
                };

                manager = new CoreAPI.DocumentoManager.DocumentoManager();
                apiResponse = new ApiResponse();
                apiResponse.Data = manager.RetrieveByUserID(documento);

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        public IHttpActionResult Put(Entities_POJO.Documento documento)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new CoreAPI.DocumentoManager.DocumentoManager();
                manager.Update(documento);

                apiResponse = new ApiResponse();
                apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResponse);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        public IHttpActionResult Delete(Entities_POJO.Documento documento)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new CoreAPI.DocumentoManager.DocumentoManager();
                manager.Delete(documento);

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
        [Route("api/Documento/Active")]
        public IHttpActionResult GetActive()
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new CoreAPI.DocumentoManager.DocumentoManager();

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
        [Route("api/Documento/UpdateStatus")]
        public IHttpActionResult UpdateStatus(Entities_POJO.Documento documento)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                manager = new CoreAPI.DocumentoManager.DocumentoManager();
                manager.UpdateStatus(documento);

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
