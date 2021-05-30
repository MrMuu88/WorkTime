namespace WorkTime.ViewModels.DTOs
{
	public class DevOpsSettingsDTO :ViewModelBase { 

		private string pesonalAccessToken;
		public string PersonalAccessToken {
			get => pesonalAccessToken;
			set { pesonalAccessToken = value; Changed(); }
		}
	}
}
