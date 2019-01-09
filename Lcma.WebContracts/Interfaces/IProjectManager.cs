using Lcma.WebContracts.DTO;
using System;
using System.Collections.Generic;

namespace Lcma.WebContracts.Interfaces
{
    public interface IProjectManager
    {
        void AttachEmployee(Guid projectId, Guid employeeId);
        void DetachEmployee(Guid projectId, Guid employeeId);
        IEnumerable<EmployeeDTO> GetManagerList();
        IEnumerable<ProjectDTO> GetOrderedProjects();
        IEnumerable<ProjectDTO> GetFilteredAndSortedProejcts(SortAndFilterParams parameters);
    }
}
