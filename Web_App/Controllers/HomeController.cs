using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_App.App_Start;

namespace Web_App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LandingPage()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LandingGrupo()
        {
            return View();
        }
    }
}