using System;
using System.Collections.Generic;

namespace Lcma.Domain.Entities
{
    public class Project : EntityBase
    {
        public string Title { get; set; }
        public string Customer { get; set; }
        public string Performer { get; set; }
        public int Priority { get; set; }
        public string Comment { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public Guid? ManagerId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
