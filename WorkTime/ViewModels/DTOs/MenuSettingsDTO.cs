using WorkTime.Core.Models;

namespace WorkTime.ViewModels.DTOs
{
	public class MenuSettingsDTO : ViewModelBase { 
		private WorkItemType startMenuAt;
		private bool myAsigmentsOnly = true;

		public WorkItemType StartMenuAt {
			get => startMenuAt;
			set { startMenuAt = value; Changed(); } 
		}
		public bool MyAssignmentsOnly {
			get => myAsigmentsOnly;
			set { myAsigmentsOnly = value; Changed(); }
		}
	}
}
