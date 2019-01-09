using AutoMapper;
using Lcma.Web.Models;
using Lcma.WebContracts.DTO;

namespace Lcma.Web.MappingProfiles
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<EmployeeDTO, EmployeeVM>(MemberList.None).ReverseMap();
            CreateMap<ProjectDTO, ProjectVM>(MemberList.None).ReverseMap();
        }
    }
}