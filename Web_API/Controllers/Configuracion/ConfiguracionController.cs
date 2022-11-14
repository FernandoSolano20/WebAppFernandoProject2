﻿using CoreAPI.ConfiguracionManager;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.AppCode.Extension;

namespace Web_API.Controllers.Configuracion
{
    public class ConfiguracionController : ApiController
    {

        private ApiResponse apiResponse;
        private ConfiguracionManager manager;

        public IHttpActionResult Get(string parametro)
        {
            var lenguaje = HeaderHelper.GetLanguage(this.Request.Headers);
            try
            {
                var configuracion = new Entities_POJO.Configuracion { Parametro = parametro };

                manager = new ConfiguracionManager();
                configuracion = manager.RetrieveByParameter(configuracion);

                apiResponse = new ApiResponse();
                apiResponse.Data = configuracion;

                return Ok(apiResponse);

            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Mensaje(lenguaje)));
            }
        }
    }
}
