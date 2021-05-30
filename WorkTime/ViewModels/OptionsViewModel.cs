using AutoMapper;
using System;
using WorkTime.Core.Interfaces;
using WorkTime.Core.Models.Settings;
using WorkTime.ViewModels.DTOs;

namespace WorkTime.ViewModels
{
	public class OptionsViewModel : ViewModelBase
	{
		private AppSettingsDTO appSettings = new AppSettingsDTO();
		private ISettingManager SettingManager { get; }
		private IMapper Mapper { get; }

		public Command CmdLoad { get; set; } 
		public Command CmdSave { get; set; }
		public Command CmdCancel { get; set; }

		public AppSettingsDTO AppSettings
		{
			get => appSettings; set { appSettings = value; Changed(); }
		}


		public OptionsViewModel(ISettingManager settingManager, IMapper mapper)
		{
			SettingManager = settingManager;
			Mapper = mapper;
			CmdLoad = new Command(Load);
			CmdSave = new Command(Save);
			CmdCancel = new Command(Cancel);
		}



		public void Load() {
			Console.WriteLine("Load command called");
			var appSettingsModel = SettingManager.Load();
			AppSettings =  Mapper.Map<AppSettingsDTO>(appSettingsModel);
		}

		public void Save() {
			Console.WriteLine("Save Command Called");
			//var appSettingsModel = Mapper.Map<AppSettings>(AppSettings);
			//SettingManager.Save(appSettingsModel);
		}

		public void Cancel() {
			Console.WriteLine("Cancel Command Called");
		}
	}
}
