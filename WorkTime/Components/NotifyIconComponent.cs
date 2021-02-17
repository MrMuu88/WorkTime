using System.Collections.Generic;
using System.Windows.Forms;
using WorkTime.Core.Interfaces;
using WorkTime.Core.Messages;

namespace WorkTime.Components
{
	public class NotifyIconComponent
	{
		public IMessenger Messenger { get; }

		private static readonly Dictionary<string, dynamic> MenuComposition = new Dictionary<string, dynamic> {
			{ "Show report",new ReportPageRequestMessage() },
			{ "Options",new OptionsPageRequestMessage() },
			{ "Exit",new ExitRequestMessage() },
		};
		private NotifyIcon NotifyIcon { get; set; } = new NotifyIcon() {
			Icon = Properties.Resources.working_time_icon,
			BalloonTipText = "Monitoring worktime for Self use"
		};

		public NotifyIconComponent(IMessenger messenger)
		{
			Messenger = messenger;
			NotifyIcon.ContextMenu = ComposeMenu(MenuComposition);
		}


		public void Enable() {
			NotifyIcon.Visible = true;
		}

		public void Disable() {
			NotifyIcon.Visible = false;
		}

		private ContextMenu ComposeMenu(Dictionary<string,dynamic> composition) {
			var menu = new ContextMenu();
			foreach (var item in composition)
			{
				var menuItem = new MenuItem(item.Key);
				menuItem.Click += (s, e) => Messenger.PublishAsync(item.Value);
				menu.MenuItems.Add(menuItem);
			}
			return menu;
		}

	}
}
