using System.Collections.Generic;

namespace Lcma.Domain.Entities
{
    public class Employee : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
