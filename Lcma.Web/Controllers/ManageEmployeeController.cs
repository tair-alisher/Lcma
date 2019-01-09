using AutoMapper;
using Lcma.Web.Models;
using Lcma.WebContracts.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Lcma.Web.Controllers
{
    public class ManageEmployeeController : Controller
    {
        private readonly IEmployeeManager _employeeManager;

        public ManageEmployeeController(IEmployeeManager employeeManager) => _employeeManager = employeeManager;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FindEmployees(string name)
        {
            var employees = _employeeManager.GetEmployeesByName(name);
            var employeeVmList = Mapper.Map<IEnumerable<EmployeeVM>>(employees);

            return PartialView(employeeVmList);
        }
    }
}