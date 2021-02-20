using AutoMapper;
using WorkTime.Core.Models;
using WorkTime.Core.Models.Settings;
using WorkTime.ViewModels.DTOs;

namespace WorkTime.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<WorkDay, WorkDayDTO>().ReverseMap();
			CreateMap<TimeFrame, TimeFrameDTO>().ReverseMap();

			CreateMap<AppSettings, AppsettingsDTO>().ReverseMap();
			CreateMap<TimeTrackingSettings, TimeTrackingSettingsDTO>().ReverseMap();
		}
	}
}
