using RestSharp;
using System.Threading.Tasks;
using WorkTime.Core.Models.Settings;

namespace WorkTime.AzureClient
{
	public class DevOpsRestClient
	{
		private readonly IRestRequest request;

		protected virtual IRestClient RestClient {
			get => new RestClient(Settings.BaseUrl)
				.AddDefaultHeader("Authorization", $"Basic {Settings.PersonalAccessToken}"); //<= PAT as base64 encoded
		}

		public IRestRequest Request => request;

		public DevOpsSettings Settings { get; }

		public DevOpsRestClient(DevOpsSettings settings)
		{
			Settings = settings;
		}

		public async Task<string> GetWorkItem(int id)
		{
			var request = new RestRequest("wit/workitems/{id}", Method.GET)
				.AddUrlSegment("id",id)
				.AddQueryParameter("expand","relations");
			var response = await RestClient.ExecuteAsync(request);

			return response.Content;
		}

		public async Task<string> GetWorkItemHistory(int id)
		{
			var request = new RestRequest("wit/workitems/{id}/updates", Method.GET)
				.AddUrlSegment("id", id);
			var response = await RestClient.ExecuteAsync(request);
			return response.Content;
		}
	}
}
