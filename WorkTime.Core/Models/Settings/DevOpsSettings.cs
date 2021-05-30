namespace WorkTime.Core.Models.Settings
{
	public class DevOpsSettings
	{
		public string BaseUrl { get; set; } = "https://dev.azure.com/geomant/_apis";
		public string PersonalAccessToken { get; set; }
	}
}
