using System.Collections.ObjectModel;
using System.Collections.Specialized;
using WorkTime.ViewModels;
using WorkTime.ViewModels.DTOs;

namespace WorkTime
{
	public class ReportsViewModel : ViewModelBase
	{
		private ObservableCollection<WorkDayDTO> workDays = new ObservableCollection<WorkDayDTO>();

		public ObservableCollection<WorkDayDTO> WorkDays {
			get => workDays;
			set {
				WorkDays.CollectionChanged -= WorkDays_CollectionChanged;
				workDays = value;
				workDays.CollectionChanged += WorkDays_CollectionChanged;
				Changed(); 
			}
		}

		public ReportsViewModel()
		{
			workDays.CollectionChanged += WorkDays_CollectionChanged;
		}

		private void WorkDays_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => Changed(nameof(WorkDays));
	}
}
