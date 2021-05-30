﻿using AutoMapper;
using System;
using System.Windows;
using WorkTime.Core.Interfaces;
using WorkTime.Core.Models.Settings;
using WorkTime.Helpers;
using WorkTime.ViewModels.DTOs;

namespace WorkTime.ViewModels
{
	public class OptionsViewModel : ViewModelBase
	{
		private AppSettingsDTO appSettings = new AppSettingsDTO();
		private ISettingManager SettingManager { get; }
		private IMapper Mapper { get; }

		public Command CmdLoad { get; set; } 
		public Command<Window> CmdSave { get; set; }
		public Command<Window> CmdCancel { get; set; }


		public AppSettingsDTO AppSettings
		{
			get => appSettings; set { appSettings = value; Changed(); }
		}

		public OptionsViewModel()
		{

		}

		public OptionsViewModel(ISettingManager settingManager, IMapper mapper)
		{
			SettingManager = settingManager;
			Mapper = mapper;
			CmdLoad = new Command(Load);
			CmdSave = new Command<Window>(Save);
			CmdCancel = new Command<Window>(Cancel);
		}



		public void Load() {
			Console.WriteLine("Load command called");
			var appSettingsModel = SettingManager.Load();
			AppSettings =  Mapper.Map<AppSettingsDTO>(appSettingsModel);
		}

		public void Save(Window window) {
			Console.WriteLine("Save Command Called");
			var appSettingsModel = Mapper.Map<AppSettings>(AppSettings);
			SettingManager.Save(appSettingsModel);
			window.Close();
		}

		public void Cancel(Window window) {
			Console.WriteLine("Cancel Command Called");
			window.Close();
		}
	}
}
