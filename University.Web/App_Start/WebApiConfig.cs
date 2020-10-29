﻿using System.Web.Http;
using System.Web.Http.Cors;
using University.API.Controllers;

namespace University.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            var enableCorseAttribute = new EnableCorsAttribute("*", "*", "*");

            config.EnableCors(enableCorseAttribute);

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
