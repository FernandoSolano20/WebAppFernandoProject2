﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CoreAPI.ContrasennaManager;
using Entities_POJO;
using Excepciones;
using Web_API.AppCode.Extension;

namespace Web_API.Controllers.Contrasenna
{
    public class ContrasennaController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();
        public async Task<IHttpActionResult> Post(Entities_POJO.Contrasenna entity)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new ContrasennaManager();
                    apiResponse = new ApiResponse();
                    apiResponse.Data = mng.Create(entity);
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
