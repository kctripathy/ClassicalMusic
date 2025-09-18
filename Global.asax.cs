using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ClassicalMusicApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (custom == "Daily")
            {
                return DateTime.Now.ToString("yyyyMMdd"); // changes daily at midnight
            }
            return base.GetVaryByCustomString(context, custom);
        }

        //Language is applied at each request:
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            HttpCookie langCookie = HttpContext.Current.Request.Cookies["lang"];
            string culture = langCookie != null ? langCookie.Value : "en";

            LanguageHelper.SetLanguage(culture);
        }
    }
}
