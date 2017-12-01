using Autofac;
using Autofac.Integration.WebApi;
using BetizagastiGnocchi.FrontEnd.WebApi.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BetizagastiGnocchi.FrontEnd.WebApi
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			GlobalConfiguration.Configuration.Formatters.Clear();
			GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());

			GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

			//registrando las dependencias
			var builder = new ContainerBuilder();
			builder.RegisterApiControllers(typeof(WebApiApplication).Assembly).PropertiesAutowired();
			builder.RegisterModule(new ServiceModule());
			builder.RegisterModule(new RepositoryModule());
			builder.RegisterModule(new EntityFrameworkModule());
			//registrando los Filter
			builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
			var container = builder.Build();
			GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}
