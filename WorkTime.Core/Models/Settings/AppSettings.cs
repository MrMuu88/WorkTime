namespace WorkTime.Core.Models.Settings
{
	public class AppSettings
	{
		public TimeTrackingSettings TimeTracking { get; set; } = new TimeTrackingSettings();

		public DevOpsSettings DevOps { get; set; } = new DevOpsSettings();
	}
}
