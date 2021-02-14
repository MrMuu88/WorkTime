using Newtonsoft.Json;
using System.IO;
using WorkTime.Interfaces;
using WorkTime.Messages;
using WorkTime.Settings;

namespace WorkTime.Components
{
	public class SettingsComponent : ISettingManager
	{
		private readonly string settingsfile = @".\Settings.json";
		public AppSettings Settings { get; internal set; }

		public IMessenger Messenger { get; }

		public SettingsComponent(IMessenger messenger)
		{
			Messenger = messenger;
			Load();
		}

		public void Load()
		{
			try
			{
				if (File.Exists(settingsfile))
				{
					var raw = File.ReadAllText(settingsfile);
					Settings = JsonConvert.DeserializeObject<AppSettings>(raw);
				}
				else
				{
					Settings = new AppSettings();
					Save();
				}
				Messenger.Publish(new SettingsChangedMessage());
			}
			catch
			{
			}
		}

		public void Save()
		{
			try
			{
				var json = JsonConvert.SerializeObject(Settings, Formatting.Indented);
				File.WriteAllText(settingsfile, json);
			}
			catch
			{
			}
		}

		public void ResetToDefaults()
		{
			try
			{
				Settings = new AppSettings();
				Messenger.Publish(new SettingsChangedMessage());
			}
			catch
			{
			}
		}
	}
}
