using Newtonsoft.Json;
using System.IO;
using WorkTime.Core.Interfaces;
using WorkTime.Core.Models.Settings;
using WorkTime.Core.Messages;

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
				Messenger.PublishAsync(new SettingsChangedMessage());
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
				Messenger.PublishAsync(new SettingsChangedMessage());
			}
			catch
			{
			}
		}
	}
}
