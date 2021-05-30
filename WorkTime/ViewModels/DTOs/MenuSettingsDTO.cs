using WorkTime.Core.Models;

namespace WorkTime.ViewModels.DTOs
{
	public class MenuSettingsDTO : ViewModelBase { 
		private WorkItemType startMenuAt;
		private bool myAsigmentsOnly;

		public WorkItemType StartMenuAt {
			get => startMenuAt;
			set { startMenuAt = value; Changed(); } 
		}
		public bool MyAsigmentsOnly {
			get => myAsigmentsOnly;
			set { myAsigmentsOnly = value; Changed(); }
		}
	}
}
