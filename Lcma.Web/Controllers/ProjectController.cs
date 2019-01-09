using AutoMapper;
using Lcma.Web.Models;
using Lcma.WebContracts.Exceptions;
using Lcma.WebContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Lcma.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService) => _projectService = projectService;

        public ActionResult Index()
        {
            var projects = _projectService.GetAll();
            var projectVmList = Mapper.Map<IEnumerable<ProjectVM>>(projects);

            return View(projectVmList);
        }

        public ActionResult AttachedEmployees(Guid? id)
        {
            try
            {
                var project = _projectService.GetById(id);
                var projectVm = Mapper.Map<ProjectVM>(project);

                return View(projectVm);
            }
            catch (ArgumentNullException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catch (NotFoundException)
            {
                return HttpNotFound();
            }
        }
    }
}