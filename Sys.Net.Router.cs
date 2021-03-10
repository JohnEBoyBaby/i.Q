using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys.Net.Router
{
    public static class Route
    {
        public static void HttpRequest(ref System.Web.HttpContext httpContext) {
            if (Sys.Caching.Cache.Contains(ref httpContext)) {
                Sys.Caching.Cache.Get(ref httpContext);
            }
            else 
            {
                httpContext.Response.ContentEncoding = System.Text.UTF8Encoding.UTF8;
                if (Sys.Security.Authentication.Authenticate(ref httpContext)) {
                    Sys.Net.Router.Route.FunctionCall(Sys.Function.ConvertStringToFunction(httpContext.Request.Form[0]), ref httpContext);
                }
                else {
                    if(Sys.Function.ConvertStringToFunction(httpContext.Request.Form[0]).name.ToLower().Trim().Equals("login")) {
                        Sys.Security.Authentication.Authenticate(ref httpContext);
                    }
                    else {
                        httpContext.Response.Write(System.IO.File.ReadAllText(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "spa.html"));
                    }
                }
            }
        }
        public static void WsRequest(ref System.Collections.Generic.List<Sys.Net.WebSockets.IWebSocketConnection> webSocketConnections,
                                     ref Sys.Net.WebSockets.IWebSocketConnection webSocketConnection) {
            //the iWebSocketConnection            
        }
        public static void FunctionCall(Sys.Funktion funktion,
                                     ref System.Web.HttpContext httpContext)
        {
            System.String response = Sys.Function.Call(funktion);
            httpContext.Response.Write(response);
        }
        public static void FunctionCall(Sys.Funktion funktion,
                             ref Sys.Net.WebSockets.IWebSocketConnection webSocketConnection)
        {
            System.String response = Sys.Function.Call(funktion);
            webSocketConnection.Send(response);
        }
        public static void FunctionCall(Sys.Funktion funktion,
                                System.Boolean exclude,
                                System.Collections.Generic.List<System.String> listOfConnectionsToExcludeOrToOnlyInclude,
                             ref System.Collections.Generic.List<Sys.Net.WebSockets.IWebSocketConnection> webSocketConnections,
                             ref Sys.Net.WebSockets.IWebSocketConnection webSocketConnection)
        {
            System.String response = Sys.Function.Call(funktion);
            var list = webSocketConnections.ToList();
            System.Int32 numberOfConnections = list.Count;
            if (exclude)
            {
                for (System.Int32 i = 0; i < numberOfConnections; i++)
                {
                    if (!listOfConnectionsToExcludeOrToOnlyInclude.Contains(webSocketConnections[i].ConnectionInfo.Id.ToString()))
                    {
                        webSocketConnections[i].Send(response);
                    }
                }
            }
            else
            { //include
                for (System.Int32 i = 0; i < numberOfConnections; i++)
                {
                    if (listOfConnectionsToExcludeOrToOnlyInclude.Contains(webSocketConnections[i].ConnectionInfo.Id.ToString()))
                    {
                        webSocketConnections[i].Send(response);
                    }
                }
            }
        }
        public static void FunctionCall(Sys.Funktion funktion,
                             ref System.Collections.Generic.List<Sys.Net.WebSockets.IWebSocketConnection> webSocketConnections,
                             ref Sys.Net.WebSockets.IWebSocketConnection webSocketConnection)
        {
            System.String response = Sys.Function.Call(funktion);
            webSocketConnections.ToList().ForEach(s => s.Send(response));
        }
    }
}