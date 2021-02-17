using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;
using WorkTime.Components;
using WorkTime.Core.Interfaces;
using WorkTime.Core.Models.Settings;

namespace WorkTime.Tests
{
	[TestClass]
	public class TimeTrackingTests
	{
		public static TimeTrackingComponent TimeTracker { get; private set; }

		[ClassInitialize]
		public static void InitializeClass(TestContext context)
		{
			var messenger = new MessengerComponent();
			var settings = new DummySettingsManager();
			TimeTracker = new TimeTrackingComponent(messenger, settings);
		}

		[TestMethod]
		public async Task TrackingTime()
		{
			TimeTracker.Start();
			await Task.Delay(1*65*1000);
			TimeTracker.Stop();

			await Task.Delay(1 * 35 * 1000);
			TimeTracker.Start();
			await Task.Delay(1 * 65 * 1000);

			var result = JsonConvert.SerializeObject(TimeTracker.CurrentWorkDay, Formatting.Indented);
			Trace.WriteLine(result);
			
		}
	}

	public class DummySettingsManager : ISettingManager
	{

		public AppSettings Settings { get; }
		public DummySettingsManager()
		{
			Settings = new AppSettings();
			Settings.TimeTracking.TrackingInterval = 0.25;
		}

		public void Load()
		{
			throw new System.NotImplementedException();
		}

		public void ResetToDefaults()
		{
			throw new System.NotImplementedException();
		}

		public void Save()
		{
			throw new System.NotImplementedException();
		}
	}
}
