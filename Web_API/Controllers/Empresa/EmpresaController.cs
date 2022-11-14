using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CoreAPI.EmpresaManager;
using Entities_POJO;
using Excepciones;
using Web_API.AppCode.Extension;

namespace Web_API.Controllers
{
    public class EmpresaController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();
        public async Task<IHttpActionResult> Get()
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var response = await Task.Run(() =>
                {
                    apiResponse = new ApiResponse();
                    var mng = new EmpresaManager();
                    apiResponse.Data = mng.RetrieveAll();
                    return apiResponse;
                });
                return Ok(response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }

        }

        public async Task<IHttpActionResult> Post(Empresa entity)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new EmpresaManager();
                    mng.Create(entity);

                    apiResponse = new ApiResponse();
                    apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";
                    return apiResponse;
                });
                return Content(HttpStatusCode.OK, response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetById(string id)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new EmpresaManager();
                    apiResponse.Data = mng.RetrieveById(new Empresa()
                    {
                        Cedula = id
                    });
                    return apiResponse;
                });
                return Content(HttpStatusCode.OK, response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        public async Task<IHttpActionResult> Put(Empresa entity)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new EmpresaManager();
                    mng.Update(entity);

                    apiResponse = new ApiResponse();
                    apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";
                    return apiResponse;
                });
                return Content(HttpStatusCode.OK, response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }

        public async Task<IHttpActionResult> Delete(Empresa entity)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new EmpresaManager();
                    mng.Delete(entity);

                    apiResponse = new ApiResponse();
                    apiResponse.Message = lenguaje == "es" ? "Acción ejecutada" : "Action was executed.";
                    return apiResponse;
                });
                return Content(HttpStatusCode.OK, response);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }
    }
}
