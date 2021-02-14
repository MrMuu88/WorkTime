using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkTime.Models;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;

namespace WorkTime.Components.Tests
{
	[TestClass]
	public class TimeTrackingComponentTests
	{

		public static MessengerComponent Messanger { get; private set; }
		public static TimeTrackingComponent TimeTracker { get; private set; }

		[ClassInitialize]
		public static void InitializeClass(TestContext context)
		{
			Messanger = new MessengerComponent();
			TimeTracker = new TimeTrackingComponent(Messanger);
			TimeTracker.Stop();
		}

		[TestMethod]

		public async Task OnTimerElapsedTest()
		{
		}
	}
}