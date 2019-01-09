using Lcma.DAL.Repositories;
using Lcma.Domain.Interfaces;
using Ninject.Modules;

namespace Lcma.BLL.Infrastructure
{
    public class BLLModule : NinjectModule
    {
        private readonly string _connectionString;

        public BLLModule(string connectionString) => _connectionString = connectionString;

        public override void Load() => Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(_connectionString);
    }
}
