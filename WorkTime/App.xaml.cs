using Autofac;
using log4net;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using WorkTime.Views;

namespace WorkTime
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : System.Windows.Application
	{
		private static ILog log = LogManager.GetLogger(nameof(App));

		public static IContainer IoCContainer { get; private set; }
		public NotifyIcon NotifyIcon { get; private set; }

		protected override void OnStartup(StartupEventArgs e)
		{
			log.Info("Application Started");
			base.OnStartup(e);

			IoCContainer = WorkTime.Startup.ConfigureServices();

			using (var scope = App.IoCContainer.BeginLifetimeScope())
			{
				log.Info("Main Scope created");
				scope.Resolve<MainWindow>().Show();
			}

			NotifyIcon = new NotifyIcon();
			NotifyIcon.Visible = true;
		}

		protected override void OnExit(ExitEventArgs e)
		{
			log.Info("Aplication exited");
			base.OnExit(e);
		}
	}

	
}
