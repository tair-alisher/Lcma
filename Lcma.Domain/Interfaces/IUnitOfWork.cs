using Lcma.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Lcma.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Employee> Employees { get; }
        IRepository<Project> Projects { get; }
        Task SaveAsync();
        void Save();
    }
}
