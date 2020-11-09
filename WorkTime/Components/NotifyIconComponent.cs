
using System.Windows.Forms;

namespace WorkTime.Components
{
	public class NotifyIconComponent
	{
		private NotifyIcon NotifyIcon { get; set; } = new NotifyIcon() {
			Icon = Properties.Resources.working_time_icon,
			BalloonTipText = "Monitoring worktime for Self use"
		};
		private ContextMenu Menu { get; set; } = new ContextMenu() { };

		public NotifyIconComponent()
		{
			NotifyIcon.ContextMenu = Menu;
			Menu.MenuItems.Add(new MenuItem("Show report"));
			Menu.MenuItems.Add(new MenuItem("Options"));
			Menu.MenuItems.Add(new MenuItem("Disable/enable"));
			Menu.MenuItems.Add(new MenuItem("Exit"));

		}

		private void NotifyIcon_Click(object sender, System.EventArgs e)
		{

		}

		public void Enable() {
			NotifyIcon.Visible = true;
		}

		public void Disable() {
			NotifyIcon.Visible = false;
		}
	}
}
