using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ETrade.Controllers
{
    public class BaseController : Controller
    {
        private static readonly List<string> _cultures = new List<string>
        {
            "en-US", // first culture is default
            "ru"
        };

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string CultureName = RouteData.Values["culture"] as string;
            //attempt to read the culture from the cookie request
            if (CultureName == null)
                CultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ? Request.UserLanguages[0] : null; //obtain it from http header acceptlanguages
            if (CultureName == null)
                CultureName = _cultures[0];
            CultureName = CultureName.ToLowerInvariant();
            //validate culture name
            CultureName = _cultures.Any(c => c.ToLowerInvariant().Contains(CultureName)) ? CultureName : _cultures[0].ToLowerInvariant();

            if(RouteData.Values["culture"] as string != CultureName)
            {
                //force valid culture in the URL
                RouteData.Values["culture"] = CultureName; //lower case 
                //redirect user
                Response.RedirectToRoute(RouteData.Values);

            }
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(CultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            return base.BeginExecuteCore(callback, state);
        }
    }
}