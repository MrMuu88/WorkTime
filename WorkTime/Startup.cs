using Autofac;
using WorkTime.Views;

namespace WorkTime
{
	public static class Startup
	{
		public static IContainer ConfigureServices() {
			var builder = new ContainerBuilder();

			builder.RegisterType<MainWindow>().AsSelf().InstancePerDependency();

			return builder.Build();
		}
	}
}
