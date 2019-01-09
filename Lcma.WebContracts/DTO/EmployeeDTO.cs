using System.Collections.Generic;

namespace Lcma.WebContracts.DTO
{
    public class EmployeeDTO : DTOBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public ICollection<ProjectDTO> Projects { get; set; }
    }
}
