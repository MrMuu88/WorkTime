using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTime.ViewModels
{
	public class AppsettingsViewModel : ViewModelBase
	{
		private TimeTrackingSettingsViewModel timeTracking = new TimeTrackingSettingsViewModel();

		public TimeTrackingSettingsViewModel TimeTracking { get => timeTracking; set { timeTracking = value; Changed(); } }

	}
}
