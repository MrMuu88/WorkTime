using AutoMapper;
using WorkTime.Core.Models;
using WorkTime.Core.Models.Settings;
using WorkTime.ViewModels;

namespace WorkTime.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<WorkDay, WorkDayViewModel>().ReverseMap();
			CreateMap<TimeFrame, TimeFrameViewModel>().ReverseMap();

			CreateMap<AppSettings, AppsettingsViewModel>().ReverseMap();
			CreateMap<TimeTrackingSettings, TimeTrackingSettingsViewModel>().ReverseMap();
		}
	}
}
