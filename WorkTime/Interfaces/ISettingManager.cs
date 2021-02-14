using WorkTime.Settings;

namespace WorkTime.Interfaces
{
	public interface ISettingManager
	{
		AppSettings Settings { get; }

		void Load();
		void ResetToDefaults();
		void Save();
	}
}