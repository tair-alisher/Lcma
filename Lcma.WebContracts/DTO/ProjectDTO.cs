using System;
using System.Collections.Generic;

namespace Lcma.WebContracts.DTO
{
    public class ProjectDTO : DTOBase
    {
        public string Title { get; set; }
        public string Customer { get; set; }
        public string Performer { get; set; }
        public int Priority { get; set; }
        public string Comment { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public Guid? ManagerId { get; set; }
        public EmployeeDTO Manager { get; set; }
        public ICollection<EmployeeDTO> Employees { get; set; }
    }
}
