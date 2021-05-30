using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Diagnostics;
using WorkTime.Core.Models.Settings;

namespace WorkTime.Tests
{
	[TestClass]
	public class SettingsTests
	{
		[TestMethod]
		public void SerializeAppsettings()
		{
			var appsettings = new AppSettings();
			var json = JsonConvert.SerializeObject(appsettings,Formatting.Indented);
			Trace.WriteLine(json);
		}
	}
}
