using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;


namespace ETrade
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {

            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
           
        }

        protected void Application_AcquireRequestState()
        {
            try
            {
                HttpCookie AuthCookie = Request.Cookies.Get("UserLoginData");
                if(AuthCookie != null && string .IsNullOrEmpty(AuthCookie.Value) && FormsAuthentication.Decrypt(AuthCookie.Value) != null)
                {
                    var ticket = FormsAuthentication.Decrypt(AuthCookie.Value);
                    var userName = ticket.Name;
                    Session["User"] = userName;
                }
                else
                {
                    Session["User"] = null;
                }
            }
            catch (Exception ex)
            {

                
            }
        }
    }
}