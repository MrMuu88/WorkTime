using Autofac;
using WorkTime.Components;
using WorkTime.Core.Interfaces;
using WorkTime.ViewModels;
using WorkTime.Views;

namespace WorkTime
{
	public static class Startup
	{
		public static IContainer ConfigureServices() {
			var builder = new ContainerBuilder();
			builder.RegisterType<MessengerComponent>().As<IMessenger>().SingleInstance();
			builder.RegisterType<SettingsComponent>().As<ISettingManager>().SingleInstance();
			builder.RegisterType<NotifyIconComponent>().AsSelf().SingleInstance();

			builder.RegisterType<OptionsView>().AsSelf().InstancePerDependency();

			builder.RegisterType<OptionsViewModel>().AsSelf().InstancePerDependency();

			return builder.Build();
		}
	}
}
