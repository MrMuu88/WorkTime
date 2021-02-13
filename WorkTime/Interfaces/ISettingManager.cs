namespace WorkTime.Interfaces
{
	public interface ISettingManager
	{
		void Reload();
		void ResetToDefaults();
		void Save();
	}
}