using WorkTime.Core.Models.Settings;

namespace WorkTime.Core.Interfaces
{
	public interface ISettingManager
	{
		AppSettings Settings { get; }

		AppSettings Load();
		AppSettings ResetToDefaults();
		AppSettings Save();
		AppSettings Save(AppSettings);
	}
}