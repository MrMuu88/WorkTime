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
		private static AppSettings settings;

		public AppSettings Settings { get => settings; internal set => settings = value; }


		public IMessenger Messenger { get; }

		public SettingsComponent(IMessenger messenger)
		{
			Messenger = messenger;
			Load();
		}

		public AppSettings Load()
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
				//Todo: Add logging
				Settings = new AppSettings();
			}
			return Settings;

		}

		public AppSettings Save()
		{
			try
			{
				var json = JsonConvert.SerializeObject(Settings, Formatting.Indented);
				File.WriteAllText(settingsfile, json);
			}
			catch
			{
			}
			Messenger.PublishAsync(new SettingsChangedMessage());
			return Settings;
		}

		public AppSettings Save(AppSettings newsettings)
		{
			Settings = newsettings;
			return Save();
		}

		public AppSettings ResetToDefaults()
		{
			try
			{
				Settings = new AppSettings();
				Messenger.PublishAsync(new SettingsChangedMessage());
			}
			catch
			{
			}
			return Settings;
		}
	}
}
