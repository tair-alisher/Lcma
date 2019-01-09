using AutoMapper;
using Lcma.Web.Models;
using Lcma.WebContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Lcma.Web.Controllers
{
    public class ManageProjectController : Controller
    {
        private readonly IProjectManager _projectManager;
        private readonly IEmployeeService _employeeService;

        public ManageProjectController(IProjectManager projectManager, IEmployeeService employeeService)
        {
            _projectManager = projectManager;
            _employeeService = employeeService;

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AttachEmployee(Guid projectId, Guid employeeId)
        {
            try
            {
                var employeeVM = Mapper.Map<EmployeeVM>(_employeeService.GetById(employeeId));
                _projectManager.AttachEmployee(projectId, employeeId);

                return PartialView(employeeVM);
            }
            catch (ArgumentNullException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return RedirectToRoute(new { controller = "Message", action = "ErrorPartial", message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool DetachEmployee(Guid projectId, Guid employeeId)
        {
            try
            {
                _projectManager.DetachEmployee(projectId, employeeId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}