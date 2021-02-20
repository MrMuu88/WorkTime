using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace WorkTime.ViewModels.DTOs
{
	public class WorkDayDTO : ViewModelBase
	{
		private DateTime date;
		private ObservableCollection<TimeFrameDTO> timeFrames = new ObservableCollection<TimeFrameDTO>();

		public DateTime Date { get => date; set { date = value; Changed(); } }
		public ObservableCollection<TimeFrameDTO> TimeFrames
		{
			get => timeFrames;
			set
			{
				TimeFrames.CollectionChanged -= TimeFrames_CollectionChanged;
				timeFrames = value;
				Changed();
				TimeFrames.CollectionChanged += TimeFrames_CollectionChanged;
			}
		}

		private void TimeFrames_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => Changed(nameof(TimeFrames));

		public WorkDayDTO()
		{
			TimeFrames.CollectionChanged += TimeFrames_CollectionChanged;
		}


	}
}
