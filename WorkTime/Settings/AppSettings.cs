namespace WorkTime.Settings
{
	public class AppSettings : SettingsBase
	{
		public TimeTrackingSettings TimeTracking { get; set; } = new TimeTrackingSettings();
	}
}
