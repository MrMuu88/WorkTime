namespace WorkTime.ViewModels.DTOs
{
	public class AppsettingsDTO : ViewModelBase
	{
		private bool startWithWindows;
		private MenuSettingsDTO menu;
		private DevOpsSettingsDTO devOps;

		public bool StartWithWindows
		{
			get => startWithWindows;
			set { startWithWindows = value; Changed(); }
		}

		public MenuSettingsDTO Menu {
			get => menu;
			set { menu = value; Changed(); }
		}
		public DevOpsSettingsDTO DevOps {
			get => devOps;
			set { devOps = value; Changed(); } 
		}
	}
}
