using WorkTime.Core.Models;

namespace WorkTime.ViewModels.DTOs
{
	public class AppsettingsDTO : ViewModelBase
	{
		private string pesonalAccessToken;
		private WorkItemType startMenuAt;
		private bool myAsigmentsOnly;
		private bool startWithWindows;

		public string PesonalAccessToken {
			get => pesonalAccessToken;
			set { pesonalAccessToken = value; Changed(); }
		}

		public WorkItemType StartMenuAt {
			get => startMenuAt;
			set { startMenuAt = value; Changed(); } 
		}

		public bool MyAsigmentsOnly {
			get => myAsigmentsOnly;
			set { myAsigmentsOnly = value; Changed(); }
		}

		public bool StartWithWindows {
			get => startWithWindows;
			set { startWithWindows = value; Changed(); }
		}
	}
}
