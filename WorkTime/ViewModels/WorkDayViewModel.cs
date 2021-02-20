using System;
using System.Collections.ObjectModel;

namespace WorkTime.ViewModels
{
	public class WorkDayViewModel : ViewModelBase
	{
		private DateTime date;
		private ObservableCollection<TimeFrameViewModel> timeFrames = new ObservableCollection<TimeFrameViewModel>();

		public DateTime Date { get => date; set { date = value; Changed(); } }
		public ObservableCollection<TimeFrameViewModel> TimeFrames { get => timeFrames;
			set {
				timeFrames = value;
				Changed();
				TimeFrames.CollectionChanged += (s, e) => Changed(nameof(TimeFrames));
			} 
		} 

		public WorkDayViewModel()
		{
			TimeFrames.CollectionChanged += (s, e) => Changed(nameof(TimeFrames));
		}
	}
}
