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
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _uow;

        public EmployeeService(IUnitOfWork uow) => _uow = uow;

        public void Add(EmployeeDTO item)
        {
            var employee = Mapper.Map<Employee>(item);

            _uow.Employees.Add(employee);
            _uow.Save();
        }

        public EmployeeDTO GetById(Guid? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            var employee = _uow.Employees.GetById((Guid)id);
            if (employee == null)
                throw new NotFoundException((Guid)id);

            return Mapper.Map<EmployeeDTO>(employee);
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            var employees = _uow.Employees.List().ToList();

            return Mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }

        public void Update(EmployeeDTO item)
        {
            var employee = Mapper.Map<Employee>(item);

            _uow.Employees.Update(employee);
            _uow.Save();
        }

        public void Delete(Guid? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            var employee = _uow.Employees.GetById((Guid)id);
            if (employee == null)
                throw new NotFoundException((Guid)id);

            RemoveManagerFromProjects(employee.Id);
            employee.Projects.Clear();

            _uow.Employees.Delete(employee);
            _uow.Save();
        }

        private void RemoveManagerFromProjects(Guid managerId)
        {
            var projects = _uow.Projects.List(new BaseSpecification<Project>(p => p.ManagerId == managerId));

            foreach (var project in projects)
                project.ManagerId = null;

            _uow.Save();
        }

        public void Dispose() => _uow.Dispose();
    }
}
