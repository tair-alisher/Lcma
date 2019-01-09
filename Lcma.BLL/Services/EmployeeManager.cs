using AutoMapper;
using Lcma.Domain.Entities;
using Lcma.Domain.Interfaces;
using Lcma.WebContracts.DTO;
using Lcma.WebContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lcma.BLL.Services
{
    public class EmployeeManager : IEmployeeManager, IDisposable
    {
        private readonly IUnitOfWork _uow;

        public EmployeeManager(IUnitOfWork uow) => _uow = uow;

        public IEnumerable<EmployeeDTO> GetEmployeesByName(string inputName)
        {
            var foundEmployees = Enumerable.Empty<Employee>();

            string name = inputName.Trim();
            if (name.Length < 0)
                Enumerable.Empty<EmployeeDTO>();

            NameParts nameParts = new NameParts(name);

            while (nameParts.PartsCount > 0)
            {
                foundEmployees = GetEmployeesByName(foundEmployees, nameParts.GetFirstElement());
                nameParts.RemoveFirstElement();
            }

            return Mapper.Map<IEnumerable<EmployeeDTO>>(foundEmployees);
        }

        private IEnumerable<Employee> GetEmployeesByName(IEnumerable<Employee> employees, string name)
        {
            List<Employee> foundEmployees = (
                from
                    emp in employees.Count() > 0 ? employees : _uow.Employees.List()
                where
                    emp.LastName.IndexOf(name, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
                    emp.FirstName.IndexOf(name, StringComparison.CurrentCultureIgnoreCase) >= 0
                select emp
                ).ToList();

            return foundEmployees;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    class NameParts
    {
        const int MaxNumberOfPartsInFullName = 3;

        List<string> Parts { get; }
        public int PartsCount
        {
            get { return Parts.Count(); }
        }

        public NameParts(string name)
        {
            Parts = name.Split(' ').ToList();
            if (Parts.Count() > MaxNumberOfPartsInFullName)
                Parts = Parts.Take(MaxNumberOfPartsInFullName).ToList();
        }

        public string GetFirstElement()
        {
            return Parts.First();
        }

        public void RemoveFirstElement()
        {
            Parts.Remove(Parts.First());
        }
    }
}
