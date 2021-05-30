using WorkTime.ViewModels.DTOs;

namespace WorkTime.ViewModels
{
	public class OptionsViewModel : ViewModelBase
	{
		private AppsettingsDTO appsettings = new AppsettingsDTO();

		public AppsettingsDTO Appsettings
		{
			get => appsettings; set { appsettings = value; Changed(); }
		}
	}
}
