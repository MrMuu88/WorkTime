using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace WorkTime.ViewModels
{
	public class WorkDayViewModel : ViewModelBase
	{
		private DateTime date;
		private ObservableCollection<TimeFrameViewModel> timeFrames = new ObservableCollection<TimeFrameViewModel>();

		public DateTime Date { get => date; set { date = value; Changed(); } }
		public ObservableCollection<TimeFrameViewModel> TimeFrames { get => timeFrames;
			set {
				TimeFrames.CollectionChanged -= TimeFrames_CollectionChanged;
				timeFrames = value;
				Changed();
				TimeFrames.CollectionChanged += TimeFrames_CollectionChanged;
			} 
		}

		private void TimeFrames_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => Changed(nameof(TimeFrames));

		public WorkDayViewModel()
		{
			TimeFrames.CollectionChanged += TimeFrames_CollectionChanged;
		}

	
	}
}
