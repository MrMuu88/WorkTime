namespace WorkTime.ViewModels.DTOs
{
	public class DevOpsSettingsDTO :ViewModelBase { 

		private string pesonalAccessToken;
		public string PesonalAccessToken {
			get => pesonalAccessToken;
			set { pesonalAccessToken = value; Changed(); }
		}
	}
}
