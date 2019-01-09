using AutoMapper;
using Lcma.BLL.Services;
using Lcma.BLL.Tests.MappingProfiles;
using Lcma.BLL.Tests.Repositories;
using Lcma.Domain.Interfaces;
using Lcma.WebContracts.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcma.BLL.Tests.Services.Tests
{
    public class Util
    {
        protected IEmployeeManager _employeeManager;
        protected EmployeeRepository _employeeRepository;
        protected Mock<IUnitOfWork> _uow;

        public void EmployeeManagerConstructor()
        {
            _employeeRepository = new EmployeeRepository();
            _uow = new Mock<IUnitOfWork>();
            _uow
                .Setup(u => u.Employees)
                .Returns(_employeeRepository.repository.Object);
            _employeeManager = new EmployeeManager(_uow.Object);
        }

        protected void ResetInitMapper()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.AddProfile<MappingProfile>());
        }
    }
}
