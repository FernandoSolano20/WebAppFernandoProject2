using CoreAPI;
using CoreAPI.RolManager;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Web_API.ActionFilters;
using Web_API.AppCode.Extension;

namespace Web_API.Controllers
{

    public class RolController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // GET api/cliente
        // Retrieve
        public IHttpActionResult Get()
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                apiResp = new ApiResponse();
                var mng = new RolManager();
                apiResp.Data = mng.RetrieveAll();
                apiResp.Message = "The action was executed";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }
        // GET api/descuento/5
        // Retrieve by id
        public IHttpActionResult Get(string nombre)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var mng = new RolManager();
                var rol = new Rol
                {
                    Nombre = nombre
                };

                rol = mng.RetrieveById(rol);
                apiResp = new ApiResponse();
                apiResp.Data = rol;
                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }
        // POST 
        // CREATE
        [CatalogosActionFilter]

        public IHttpActionResult Post(Rol rol)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var mng = new RolManager();
                mng.Create(rol);

                apiResp = new ApiResponse();
                apiResp.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }
        // PUT
        // UPDATE
        [CatalogosActionFilter]

        public IHttpActionResult Put(Rol rol)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var mng = new RolManager();
                mng.Update(rol);

                apiResp = new ApiResponse();
                apiResp.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        // DELETE ==
        [CatalogosActionFilter]
        public IHttpActionResult Delete(Rol rol)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var mng = new RolManager();
                mng.Delete(rol);

                apiResp = new ApiResponse();
                apiResp.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }
    }
}
