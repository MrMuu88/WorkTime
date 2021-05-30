using Newtonsoft.Json;
using System.IO;
using WorkTime.Core.Models.Settings;

namespace WorkTime.Tests
{
	public class Constants
	{
		public static AppSettings AppSettings {
			get {
				var raw = File.ReadAllText(@"..\..\..\workTime\Settings.Json");
				return JsonConvert.DeserializeObject<AppSettings>(raw); 
			}
		}
	}
}
