using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace OnlineStore.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));


            // Web API routes
            config.MapHttpAttributeRoutes();


            // allow anonymous origin header
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);


            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "ReservedItems",
                routeTemplate: "api/values/{action}/{id}",
                defaults: new {
                    Controller = "Values",
                    id = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "Auth",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new {
                    Controller = "Auth",
                    id = RouteParameter.Optional
                }
            );

            // Setup json serialization to serialize classes to camel (std. Json format)
            //var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            //jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

        }
    }
}
