using AutoMapper;
using Lcma.DAL.Repositories;
using Lcma.Domain.Entities;
using Lcma.Domain.Interfaces;
using Lcma.WebContracts.DTO;
using Lcma.WebContracts.Exceptions;
using Lcma.WebContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lcma.BLL.Services
{
    public class ProjectManager : IProjectManager, IDisposable
    {
        private IUnitOfWork _uow { get; set; }

        public ProjectManager(IUnitOfWork uow) => _uow = uow;

        public void AttachEmployee(Guid projectId, Guid employeeId)
        {
            var project = _uow.Projects.GetById(projectId);
            var employee = _uow.Employees.GetById(employeeId);

            if (project == null)
                throw new NotFoundException(projectId);
            if (employee == null)
                throw new NotFoundException(employeeId);

            project.Employees.Add(employee);
            _uow.Save();
        }

        public void DetachEmployee(Guid projectId, Guid employeeId)
        {
            var project = _uow.Projects.GetById(projectId);
            var employee = _uow.Employees.GetById(employeeId);

            if (project == null)
                throw new NotFoundException(projectId);
            if (employee == null)
                throw new NotFoundException(employeeId);

            project.Employees.Remove(employee);
            _uow.Save();
        }

        public IEnumerable<ProjectDTO> GetFilteredAndSortedProejcts(SortAndFilterParams parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeDTO> GetManagerList()
        {
            var managerIds = _uow.Projects
                .List(new BaseSpecification<Project>(p => p.ManagerId != null))
                .Select(i => (Guid)i.ManagerId);

            var managers = _uow.Employees
                .List(new BaseSpecification<Employee>(e => managerIds.Contains(e.Id)))
                .ToList();

            return Mapper.Map<IEnumerable<EmployeeDTO>>(managers);
        }

        public IEnumerable<ProjectDTO> GetOrderedProjects()
        {
            var projects = _uow.Projects.List().OrderBy(p => p.Title).ToList();
            return Mapper.Map<IEnumerable<ProjectDTO>>(projects);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
