using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateMap<Source, Destination>();
            //CreateMap<LeaveType, IndexVM>()
            //    .ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.NumberOfDays));
            //CreateMap<IndexVM,LeaveType>()
            //    .ForMember(dest => dest.NumberOfDays, opt => opt.MapFrom(src => src.Days));

            CreateMap<LeaveType, LeaveTypeReadOnlyVM>();
            CreateMap<LeaveTypeCreateVM, LeaveType>();
            CreateMap<LeaveTypeEditVM, LeaveType>().ReverseMap();


        }

    }
}
