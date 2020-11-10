using Autofac;
using log4net;
using System.Windows;
using WorkTime.Components;
using WorkTime.Interfaces;
using WorkTime.Messages;

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

			Messenger.Subscribe<ReportPageRequestMessage>((m)=>log.Info("Report page requested"));
			Messenger.Subscribe<OptionsPageRequestMessage>((m)=> log.Info("Options page requested"));
			Messenger.Subscribe<SwitchMessage>((m)=> log.Info("switch requested"));
			Messenger.Subscribe<ExitRequestMessage>((m)=> Current.Shutdown());

			IoCContainer.Resolve<NotifyIconComponent>().Enable();
		}

		protected override void OnExit(ExitEventArgs e)
		{
			log.Info("Aplication exited");
			base.OnExit(e);
		}
	}

	
}
