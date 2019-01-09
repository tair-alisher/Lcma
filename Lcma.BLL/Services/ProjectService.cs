using AutoMapper;
using Lcma.Domain.Entities;
using Lcma.Domain.Interfaces;
using Lcma.WebContracts.DTO;
using Lcma.WebContracts.Exceptions;
using Lcma.WebContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcma.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _uow;

        public ProjectService(IUnitOfWork uow) => _uow = uow;

        public void Add(ProjectDTO item)
        {
            var project = Mapper.Map<Project>(item);
            project.CreatedAt = DateTime.Now;
            project.UpdatedAt = DateTime.Now;

            _uow.Projects.Add(project);
            _uow.Save();
        }

        public ProjectDTO GetById(Guid? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            var project = _uow.Projects.GetById((Guid)id);
            if (project == null)
                throw new NotFoundException((Guid)id);

            return Mapper.Map<ProjectDTO>(project);
        }

        public IEnumerable<ProjectDTO> GetAll()
        {
            var projects = _uow.Projects.List().ToList();
            return Mapper.Map<IEnumerable<ProjectDTO>>(projects);
        }

        public void Update(ProjectDTO item)
        {
            var project = Mapper.Map<Project>(item);

            _uow.Projects.Update(project);
            _uow.Save();
        }

        public void Delete(Guid? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            var project = _uow.Projects.GetById((Guid)id);
            if (project == null)
                throw new NotFoundException((Guid)id);

            project.Employees.Clear();
            _uow.Projects.Delete(project);
            _uow.Save();
        }

        public void Dispose() => _uow.Dispose();
    }
}
