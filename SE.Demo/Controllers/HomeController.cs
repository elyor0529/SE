using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SE.Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
           
        public ActionResult Error()
        {
            var error = (Exception)Session["last-error"];

            if (error != null)
            {
                Session["last-error"] = null;

                return View(new HandleErrorInfo(error, "Search", "Error"));
            }

            return View();
        }

    }
}