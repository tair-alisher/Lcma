using Lcma.DAL.Context;
using Lcma.Domain.Entities;
using Lcma.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Lcma.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyAppContext _db;
        private BaseRepository<Employee> employeeRepository;
        private BaseRepository<Project> projectRepository;

        public UnitOfWork(string connectionString) => _db = new MyAppContext(connectionString);

        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new BaseRepository<Employee>(_db);
                return employeeRepository;
            }
        }

        public IRepository<Project> Projects
        {
            get
            {
                if (projectRepository == null)
                    projectRepository = new BaseRepository<Project>(_db);
                return projectRepository;
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    _db.Dispose();
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save() => _db.SaveChanges();

        public async Task SaveAsync() => await _db.SaveChangesAsync();
    }
}
