using WorkTime.Interfaces;
using WorkTime.Messages;

namespace WorkTime.Components
{
	public class SettingsComponent : ISettingManager
	{
		
		public IMessenger Messenger { get; }

		public SettingsComponent(IMessenger messenger)
		{
			Messenger = messenger;
		}

		public void Save() {
			Properties.Settings.Default.Save();
			Messenger.Publish(new SettingsChangedMessage());
		}

		public void Reload() {
			Properties.Settings.Default.Reload();
			Messenger.Publish(new SettingsChangedMessage());
		}

		public void ResetToDefaults() {
			Properties.Settings.Default.Reset();
			Messenger.Publish(new SettingsChangedMessage());
		}
	}
}
