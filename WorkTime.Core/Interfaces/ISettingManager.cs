using WorkTime.Core.Models.Settings;

namespace WorkTime.Core.Interfaces
{
	public interface ISettingManager
	{
		AppSettings Settings { get; }

		void Load();
		void ResetToDefaults();
		void Save();
	}
}