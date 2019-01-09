using AutoMapper;
using Lcma.Domain.Entities;
using Lcma.WebContracts.DTO;

namespace Lcma.BLL.Tests.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>(MemberList.None).ReverseMap();
            CreateMap<Project, ProjectDTO>(MemberList.None).ReverseMap();
        }
    }
}
