using System.Runtime.CompilerServices;

namespace WorkTime.Settings
{
	public abstract class SettingsBase
	{
		public T Get<T>([CallerMemberName] string settingName = null)
		{
			return (T)Properties.Settings.Default[settingName];
		}

		public void Set<T>(T value, [CallerMemberName] string settingName = null)
		{
			Properties.Settings.Default[settingName] = value;
		}
	}
}
