using WorkTime.Interfaces;
using WorkTime.Settings;

namespace WorkTime.Components
{
	public class SettingsComponent<T> : ISettingManager<T> where T:SettingsBase
	{
		public T value { get; set; }

		
		public IMessenger Messenger { get; }

		public SettingsComponent(IMessenger messenger)
		{
			Messenger = messenger;
		}
		public void Save() {
			Properties.Settings.Default.Save();
			Messenger.Publish(new SettingsChangedMessage<T>());
		}

		public void Reload() {
			Properties.Settings.Default.Reload();
			Messenger.Publish(new SettingsChangedMessage<T>());
		}

		public void ResetToDefaults() {
			Properties.Settings.Default.Reset();
			Messenger.Publish(new SettingsChangedMessage<T>());
		}
	}
}
