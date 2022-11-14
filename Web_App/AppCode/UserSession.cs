using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Web_App.App_Start
{
    [Serializable]
    public sealed class UserSession
    {
        private static HttpSessionStateBase _current;
        public static HttpSessionStateBase Current
        {
            get => _current ?? (_current = new HttpSessionStateWrapper(HttpContext.Current.Session));
            set => _current = value;
        }
        private static readonly object SessionLock = new object();

        public static void SetItem(string key, object value)
        {
            lock (SessionLock)
            {
                Current.Add(key, value);

                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                {
                    HttpContext.Current.Session.Add(key, value);
                }
            }
        }

        public static object GetItem(string key)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                return HttpContext.Current.Session[key];
            }

            return Current[key];
        }

        public static string Language 
        {
            get
            {
                var language = GetItem("Language");

                if (language != null)
                {
                    return language.ToString();
                }

                return "es";
            }

            set => SetItem("Language",value);
        }

        public static string Id
        {
            get
            {
                var language = GetItem("Id");

                if (language != null)
                {
                    return language.ToString();
                }

                return "";
            }

            set => SetItem("Id", value);
        }

        public static string IdEmpresa
        {
            get
            {
                var language = GetItem("IdEmpresa");

                if (language != null)
                {
                    return language.ToString();
                }

                return "";
            }

            set => SetItem("IdEmpresa", value);
        }
    }
}