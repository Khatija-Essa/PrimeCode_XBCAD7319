using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace PrimeCode_XBCAD7319
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            string defaultPage = "~/User/Default.aspx";
            if (HttpContext.Current != null && HttpContext.Current.Request.Url.AbsolutePath == "/")
            {
                HttpContext.Current.Response.Redirect(defaultPage);
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Session["username"] = string.Empty;
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.Path == "/" || Request.Path == "/Default.aspx")
            {
                Response.Redirect("~/User/Default.aspx");
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex != null)
            {
                Server.ClearError();
                Response.Redirect("~/User/Default.aspx");
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}