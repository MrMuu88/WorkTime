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
			var workday = new WorkDay();
			await Task.Delay(1000);
			TimeTracker.OnTimerElapsed(workday);
			await Task.Delay(4000);
			TimeTracker.OnTimerElapsed(workday);
			Trace.WriteLine(JsonConvert.SerializeObject(workday, Formatting.Indented));
			Assert.IsTrue(workday.TimeFrames.Count == 3);
			Assert.IsTrue(workday.TimeFrames[0].Type == TimeFrameType.Work );
			Assert.IsTrue(workday.TimeFrames[1].Type == TimeFrameType.Break );
			Assert.IsTrue(workday.TimeFrames[2].Type == TimeFrameType.Work );
		}
	}
}