using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys
{
    public class Server: System.Web.IHttpModule
    {
        public virtual void Init(System.Web.HttpApplication httpApplication)
        {
            httpApplication.BeginRequest += new System.EventHandler(BeginRequestEventHandler);
        }
        protected virtual void BeginRequestEventHandler(System.Object sender, System.EventArgs args)
        {
            System.Web.HttpContext httpContext = ((System.Web.HttpApplication)sender).Context;
            #region "if not a secure HTTPS request or if the HTTPS method is not a GET or POST method, then redirect to home page"
            if ((!httpContext.Request.IsLocal
              && !httpContext.Request.IsSecureConnection) 
             || (httpContext.Request.HttpMethod.ToLower().Trim() != "get"
              && httpContext.Request.HttpMethod.ToLower().Trim() != "post")) {
                httpContext.Response.Redirect("https://" + System.Web.Hosting.HostingEnvironment.SiteName);
            }           
            #endregion
            #region "else, route the HTTPS GET or POST request"
            else {
                Sys.Net.Router.Route.HttpRequest(ref httpContext);
            }
            #endregion

            #region "that's it, now, just end the response so IIS does no other handling of HTTP(S) requests."
            httpContext.Response.End();
            #endregion
        }
        public void Dispose()
        {
        }
    }
}