using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WorkTime.AzureClient;

namespace WorkTime.Tests
{
	[TestClass]
	public class DevopsClientTest
	{
		public static DevOpsRestClient DevopsRestClient { get; private set; }

		[ClassInitialize]
		public static void InitializeClass(TestContext context)
		{
			DevopsRestClient = new DevOpsRestClient(Constants.AppSettings.DevOps);
		}

		[TestMethod]
		public async Task GetWorkItemByIdTest()
		{
			var response = await DevopsRestClient.GetWorkItem(37807);

			Trace.WriteLine(response);
		}

		[TestMethod]
		public async Task GetWorkItemHistoryTest()
		{
			var response = await DevopsRestClient.GetWorkItemHistory(37807);

			Trace.WriteLine(response);
		}
	}
}
