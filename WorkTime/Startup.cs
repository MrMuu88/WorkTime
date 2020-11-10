using Autofac;
using WorkTime.Components;
using WorkTime.Interfaces;
using WorkTime.Views;

namespace WorkTime
{
	public static class Startup
	{
		public static IContainer ConfigureServices() {
			var builder = new ContainerBuilder();

			builder.RegisterType<MessengerComponent>().As<IMessenger>().SingleInstance();
			builder.RegisterType<MainWindow>().AsSelf().InstancePerDependency();
			builder.RegisterType<NotifyIconComponent>().AsSelf().SingleInstance();

			return builder.Build();
		}
	}
}
