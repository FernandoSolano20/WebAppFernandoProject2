using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace Web_API.AppCode.Extension
{
    public class HeaderHelper
    {
        public static string GetLanguage(HttpRequestHeaders headers)
        {
            string lenguaje = string.Empty;
            if (headers.Contains("lenguaje"))
            {
                lenguaje = headers.GetValues("lenguaje").First();
            }
            else
            {
                lenguaje = "es";
            }

            return lenguaje;
        }
    }
}