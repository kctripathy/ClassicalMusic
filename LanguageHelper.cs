using System;
using System.Globalization;
using System.Threading;
using System.Web;

public class LanguageHelper
{
    public static void SetLanguage(string culture)
    {
        if (!string.IsNullOrEmpty(culture))
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            HttpCookie langCookie = new HttpCookie("lang", culture)
            {
                Expires = DateTime.Now.AddYears(1)
            };
            HttpContext.Current.Response.Cookies.Add(langCookie);
        }
    }

    public static int? GetCurrenAppResourceId()
    {
        HttpCookie langCookie = HttpContext.Current.Request.Cookies["lang"];
        string currentLanguage = langCookie != null ? langCookie.Value : "en";
        int? langId = 0;
        switch(currentLanguage)
        {
            case "en": langId = 1; break;
            case "hi": langId = 2; break;
            case "or": langId = 3; break;
        }
        return langId;
    }
}