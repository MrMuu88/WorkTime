using AutoMapper;
using WorkTime.Core.Models;
using WorkTime.ViewModels;

namespace WorkTime.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<WorkDay, WorkDayViewModel>().ReverseMap();
			CreateMap<TimeFrame, TimeFrameViewModel>().ReverseMap();
		}
	}
}
