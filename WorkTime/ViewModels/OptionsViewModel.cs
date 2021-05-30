using AutoMapper;
using WorkTime.Core.Interfaces;
using WorkTime.Core.Models.Settings;
using WorkTime.ViewModels.DTOs;

namespace WorkTime.ViewModels
{
	public class OptionsViewModel : ViewModelBase
	{
		private AppSettingsDTO appSettings = new AppSettingsDTO();

		public AppSettingsDTO AppSettings
		{
			get => appSettings; set { appSettings = value; Changed(); }
		}

		private ISettingManager SettingManager { get; }
		private IMapper Mapper { get; }

		public OptionsViewModel(ISettingManager settingManager, IMapper mapper)
		{
			SettingManager = settingManager;
			Mapper = mapper;
		}

		public void Load() {
			var appSettingsModel = SettingManager.Load();
			AppSettings =  Mapper.Map<AppSettingsDTO>(appSettingsModel);
		}

		public void Save() {
			var appSettingsModel = Mapper.Map<AppSettings>(AppSettings);
			SettingManager.Save(appSettingsModel);
		}

	}
}
