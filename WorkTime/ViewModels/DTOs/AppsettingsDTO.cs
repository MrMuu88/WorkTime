namespace WorkTime.ViewModels.DTOs
{
	public class AppsettingsDTO : ViewModelBase
	{
		private TimeTrackingSettingsDTO timeTracking = new TimeTrackingSettingsDTO();

		public TimeTrackingSettingsDTO TimeTracking { get => timeTracking; set { timeTracking = value; Changed(); } }

	}
}
