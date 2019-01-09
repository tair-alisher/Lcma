using Lcma.Domain.Entities;
using Lcma.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lcma.BLL.Tests.Repositories
{
    public class EmployeeRepository
    {
        public Mock<IRepository<Employee>> repository;
        public List<Employee> Employees { get; }

        public EmployeeRepository()
        {
            repository = new Mock<IRepository<Employee>>();
            Employees = new List<Employee>
            {
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Ярослава",
                    LastName = "Ермишина",
                    MiddleName = "Филипповна",
                    Email = "ermishina@mail.com"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Владилен",
                    LastName = "Пашин",
                    MiddleName = "Елизарович",
                    Email = "pashin@mail.com"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Артем",
                    LastName = "Яманов",
                    MiddleName = "Прохорович ",
                    Email = "yamanov@mail.com"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Оксана",
                    LastName = "Лютова",
                    MiddleName = "Родионовна",
                    Email = "lutova@mail.com"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Адам",
                    LastName = "Абабков",
                    MiddleName = "Назарович",
                    Email = "ababkov@mail.com"
                }
            };

            repository
                .Setup(r => r.Add(It.IsAny<Employee>()))
                .Callback<Employee>(Add);
            repository
                .Setup(r => r.GetById(It.IsAny<Guid>()))
                .Returns((Guid id) => Get(id));
            repository
                .Setup(r => r.List())
                .Returns(GetAll());
            repository
                .Setup(r => r.Update(It.IsAny<Employee>()))
                .Callback((Employee employee) => Update(employee));
            repository
                .Setup(r => r.Delete(It.IsAny<Employee>()))
                .Callback<Employee>(Delete);
        }

        public void Add(Employee employee)
        {
            Employees.Add(employee);
        }

        public Employee Get(Guid id)
        {
            return Employees.Where(e => e.Id == id).FirstOrDefault();
        }

        public IQueryable<Employee> GetAll()
        {
            return Employees.AsQueryable();
        }

        public void Update(Employee data)
        {
            var employee = Get(data.Id);
            employee.FirstName = data.FirstName;
            employee.LastName = data.LastName;
            employee.MiddleName = data.MiddleName;
            employee.Email = data.Email;

            employee.Projects = data.Projects;
        }

        public void Delete(Employee employee)
        {
            Employees.Remove(employee);
        }

        public void RemoveLastEmployee()
        {
            Employees.Remove(Employees.Last());
        }
    }
}
