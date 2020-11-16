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
			builder.RegisterType<TimeTrackingComponent>().As<ITimeTracker>().SingleInstance();
			builder.RegisterType<NotifyIconComponent>().AsSelf().SingleInstance();
			builder.RegisterType<ReportView>().AsSelf().InstancePerDependency();
			builder.RegisterType<OptionsView>().AsSelf().InstancePerDependency();

			return builder.Build();
		}
	}
}
