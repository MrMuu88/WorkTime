using AutoMapper;
using WorkTime.Core.Models.Settings;
using WorkTime.ViewModels.DTOs;

namespace WorkTime.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<AppSettings, AppSettingsDTO>().ReverseMap();

			CreateMap<DevOpsSettings, DevOpsSettingsDTO>();
			CreateMap<DevOpsSettingsDTO, DevOpsSettings>().ForMember(m => m.BaseUrl,o => o.UseDestinationValue());

			CreateMap<MenuSettings, MenuSettingsDTO>().ReverseMap();
		}
	}
}
