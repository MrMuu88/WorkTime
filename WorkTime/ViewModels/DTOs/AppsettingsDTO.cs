namespace WorkTime.ViewModels.DTOs
{
	public class AppSettingsDTO : ViewModelBase
	{
		private bool startWithWindows = true;
		private MenuSettingsDTO menu = new MenuSettingsDTO();
		private DevOpsSettingsDTO devOps = new DevOpsSettingsDTO();

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
