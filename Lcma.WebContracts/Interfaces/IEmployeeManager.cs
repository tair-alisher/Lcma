using Lcma.WebContracts.DTO;
using System.Collections.Generic;

namespace Lcma.WebContracts.Interfaces
{
    public interface IEmployeeManager
    {
        IEnumerable<EmployeeDTO> GetEmployeesByName(string name);
    }
}
