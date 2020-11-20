namespace WorkTime.Settings
{
	public class TimeTrackingSettings : SettingsBase {
		public double TrackingInterval
		{
			get => Get<double>();
			set => Set(value);
		}

		public double BreakTreshold
		{
			get => Get<double>();
			set => Set(value);
		}
	}
}
