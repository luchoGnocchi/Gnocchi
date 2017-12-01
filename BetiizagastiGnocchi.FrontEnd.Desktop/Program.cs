using Autofac;
using BetizagastiGnocchi.FrontEnd.Desktop.Modules;
using BetizagastiGnocchi.BackEnd.DAL;
using BetizagastiGnocchi.BackEnd.Domain.Entities;
using BetizagastiGnocchi.BackEnd.Services.LogServices;
using BetizagastiGnocchi.BackEnd.Services.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetizagastiGnocchi.FrontEnd.Desktop
{
	static class Program
	{
		/// <summary>
		/// Punto de entrada principal para la aplicación.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			//registrando las dependencias
			var builder = new ContainerBuilder();
			//builder.RegisterApiControllers(typeof(WebApiApplication).Assembly).PropertiesAutowired();
			builder.RegisterModule(new ServiceModule());
			builder.RegisterModule(new RepositoryModule());
			builder.RegisterModule(new EntityFrameworkModule());

			var assembly = Assembly.GetExecutingAssembly();
			builder.RegisterAssemblyTypes(assembly).Where(type => type.IsSubclassOf(typeof(Form)));

			//registrando los Filter
			//builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
			var container = builder.Build();
			//GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

			Application.Run(container.Resolve<frmLogin>()); //new frmLogin(new LogService(), new UserService(new GenericRepository<User>(new CarManagementContext())))

		}
	}
}
