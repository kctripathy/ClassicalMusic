using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassicalMusicApp.Controllers
{
    public class LanguageController : Controller
    {
        public ActionResult Change(string lang)
        {
            LanguageHelper.SetLanguage(lang);
            return Redirect(Request.UrlReferrer.ToString()); // go back to same page
        }
    }
}