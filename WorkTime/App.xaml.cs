using Autofac;
using log4net;
using System.Windows;
using WorkTime.Components;
using WorkTime.Interfaces;
using WorkTime.Messages;
using WorkTime.Views;

namespace WorkTime
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private static ILog log = LogManager.GetLogger(nameof(App));

		public static IContainer IoCContainer { get; private set; }
		public IMessenger Messenger { get; private set; }

		protected override void OnStartup(StartupEventArgs e)
		{
			log.Info("Application Started");
			base.OnStartup(e);

			IoCContainer = WorkTime.Startup.ConfigureServices();

			Messenger = IoCContainer.Resolve<IMessenger>();

			Messenger.Subscribe<ReportPageRequestMessage>(OnReportRequest);
			Messenger.Subscribe<OptionsPageRequestMessage>(OnOptionsRequest);
			Messenger.Subscribe<SwitchMessage>(OnSwitchRequest);
			Messenger.Subscribe<ExitRequestMessage>((m)=> Current.Shutdown());

			IoCContainer.Resolve<NotifyIconComponent>().Enable();
		}

		protected override void OnExit(ExitEventArgs e)
		{
			log.Info("Aplication exited");
			base.OnExit(e);
		}

		public void OnReportRequest(ReportPageRequestMessage message) {
			log.Info("Report page requested");
			IoCContainer.Resolve<ReportView>().Show();
		}

		public void OnOptionsRequest(OptionsPageRequestMessage message)
		{
			log.Info("Options page requested");
			IoCContainer.Resolve<OptionsView>().Show();
		}

		public void OnSwitchRequest(SwitchMessage message) {
			log.Info("switch requested");
		}


	}

	
}
