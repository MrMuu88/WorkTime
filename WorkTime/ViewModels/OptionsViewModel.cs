namespace WorkTime.ViewModels
{
	public class OptionsViewModel : ViewModelBase
	{
		private AppsettingsViewModel appsettings;

		public AppsettingsViewModel Appsettings
		{
			get => appsettings; set { appsettings = value; Changed(); }
		}
	}
}
