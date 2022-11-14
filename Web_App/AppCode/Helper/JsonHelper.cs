using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Web_App.AppCode.Helper
{
    public static class JsonHelper
    {
        public static string ToJson(this object obj, Formatting formatting = Formatting.None)
        {
            var json = JsonConvert.SerializeObject(obj, formatting);
            return json;
        }
    }
}