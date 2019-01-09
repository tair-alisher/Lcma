using AutoMapper;
using Lcma.Web.Models;
using Lcma.WebContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lcma.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) => _employeeService = employeeService;

        public ActionResult Index()
        {
            var employees = _employeeService.GetAll();
            var employeeVmList = Mapper.Map<IEnumerable<EmployeeVM>>(employees);

            return View(employeeVmList);
        }
    }
}