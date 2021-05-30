using Autofac;
using log4net;
using System.Threading.Tasks;
using System.Windows;
using WorkTime.Components;
using WorkTime.Core.Interfaces;
using WorkTime.Core.Messages;
using WorkTime.Views;

namespace WorkTime
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application, ISubscribe<ReportPageRequestMessage>,ISubscribe<OptionsPageRequestMessage>,ISubscribe<ExitRequestMessage>
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

			Messenger.Subscribe<ReportPageRequestMessage>(this);
			Messenger.Subscribe<OptionsPageRequestMessage>(this);
			Messenger.Subscribe<ExitRequestMessage>(this);

			IoCContainer.Resolve<NotifyIconComponent>().Enable();
		}

		protected override void OnExit(ExitEventArgs e)
		{
			log.Info("Aplication exited");
			base.OnExit(e);
		}

		public Task OnMessage(ReportPageRequestMessage message) {
			return Task.Factory.StartNew(() =>{
				log.Info("Report page requested");

				//a Dsipatcher is needed to manipulate GUI stuff from a Task, otherwise STA exception
				//https://stackoverflow.com/questions/37648693/wpf-trying-to-open-a-new-window-in-a-task-but-receive-a-the-calling-thread-mu

				Current.Dispatcher.Invoke(() => { 
					IoCContainer.Resolve<ReportView>().Show();
				});
			});
		}

		public Task OnMessage(OptionsPageRequestMessage message)
		{
			return Task.Factory.StartNew(() => { 
				log.Info("Options page requested");
				Current.Dispatcher.Invoke(() =>
				{
					IoCContainer.Resolve<OptionsView>().Show();
				});
			});
		}

		public Task OnMessage(ExitRequestMessage message) {
			return Task.Factory.StartNew(()=> {
				Current.Dispatcher.Invoke(() =>
				{
					Current.Shutdown();
				});
			});
		}
	}

	
}
