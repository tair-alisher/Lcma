using AutoMapper;
using Lcma.Domain.Entities;
using Lcma.WebContracts.DTO;

namespace Lcma.BLL.MappingProfiles
{
    public class BLLMappingProfile : Profile
    {
        public BLLMappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>(MemberList.None).ReverseMap();
            CreateMap<Project, ProjectDTO>(MemberList.None).ReverseMap();
        }
    }
}
