using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WindsorBTest.Controllers
{
    using WindsorBTest.Core.Web.Controllers;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            // Logger.InfoFormat("Home page accessed @{1}", DateTime.Now.ToShortDateString());

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
