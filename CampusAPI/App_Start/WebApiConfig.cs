using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;

namespace CampusAPI
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services
      // Unity configuration
      var container = new UnityContainer();
      container.RegisterType<CampusAPI.DataStore.ICampusCache, DataStore.CampusCache>();
      config.DependencyResolver = new UnityDependencyResolver(container);

      // Web API routes
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
    }
  }
}
