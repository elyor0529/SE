using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using SE.Common;

namespace SE.Demo
{
    public class MvcApplication : HttpApplication
    {

        private static void Configure()
        {
            //iframe
            AntiForgeryConfig.SuppressXFrameOptionsHeader = true;

            //display
            DisplayModeProvider.Instance.Modes.Clear();
            DisplayModeProvider.Instance.Modes.Add(new DefaultDisplayMode());

            //veview
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            //header
            MvcHandler.DisableMvcResponseHeader = true;

            //pages
            WebPageHttpHandler.DisableWebPagesResponseHeader = true;

            //ioc
            IocConfig.Configure();

        }
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //re-configure default options
            Configure();

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //culture
            MainSettings.SetupCulture();

            // Implement HTTP compression
            Response.Headers.Remove("Server");
        }

        protected void Application_Error(object sender, EventArgs e)
        {

            var exception = Server.GetLastError();

            if (exception == null)
                return;

            Server.ClearError();

            if (MainSettings.IsProductionMode)
            {
                Session["last-error"] = exception;

                Response.Redirect("~/home/error");
            }
            else
            {
                Response.Write(exception);
                Response.Flush();
            }
        }
    }
}
