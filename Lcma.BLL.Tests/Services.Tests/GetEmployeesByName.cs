using System;
using System.Collections.Generic;
using System.Linq;
using Lcma.Domain.Entities;
using Lcma.WebContracts.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lcma.BLL.Tests.Services.Tests
{
    [TestClass]
    public class GetEmployeesByName : Util
    {
        private Employee employeeOne;
        private Employee employeeTwo;
        private Employee employeeThree;

        public GetEmployeesByName()
        {
            ResetInitMapper();
            EmployeeManagerConstructor();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            employeeOne = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Алина",
                LastName = "Чазова",
                MiddleName = "Святославовна"
            };
            employeeTwo = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Алина",
                LastName = "Дябина",
                MiddleName = "Игнатиевна"
            };
            employeeThree = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Филимон",
                LastName = "Чазов",
                MiddleName = "Архипович"
            };

            _employeeRepository.Add(employeeOne);
            _employeeRepository.Add(employeeTwo);
            _employeeRepository.Add(employeeThree);
        }

        [TestMethod]
        public void GetEmployeesByLastName()
        {
            // Arrange
            int originalemployeesCount = _employeeRepository.Employees.Count();

            // Act
            var employeesByLastName = _employeeManager.GetEmployeesByName(employeeThree.LastName) as IEnumerable<EmployeeDTO>;

            // Assert
            Assert.AreEqual(_employeeRepository.Employees.Count(), originalemployeesCount);
            Assert.IsTrue(employeesByLastName.Count() >= 2);
        }

        [TestMethod]
        public void GetEmployeesByNameWithLowerCase()
        {
            // Act
            var employeesByLowerName = _employeeManager.GetEmployeesByName(employeeOne.FirstName.ToLower()) as IEnumerable<EmployeeDTO>;

            // Assert
            Assert.IsTrue(employeesByLowerName.Count() >= 2);
        }

        [TestMethod]
        public void GetEmployeeByFirstName()
        {
            // Act
            var employeesByName = _employeeManager.GetEmployeesByName(employeeOne.FirstName) as IEnumerable<EmployeeDTO>;

            // Assert
            Assert.IsTrue(employeesByName.Count() >= 2);
        }
    }
}
