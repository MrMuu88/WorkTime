namespace WorkTime.ViewModels
{
	public class TimeTrackingSettingsViewModel : ViewModelBase
	{
		private double trackingInterval;
		private double breakTreshold;

		public double TrackingInterval { get => trackingInterval; set{ trackingInterval = value; Changed();} }
		public double BreakTreshold { get => breakTreshold; set{ breakTreshold = value;Changed();} }
	}
}
