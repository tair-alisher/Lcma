using Lcma.BLL.Services;
using Lcma.WebContracts.Interfaces;
using Ninject.Modules;

namespace Lcma.Web.Infrastructure
{
    public class WebModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEmployeeService>().To<EmployeeService>();
            Bind<IProjectService>().To<ProjectService>();
            Bind<IProjectManager>().To<ProjectManager>();
            Bind<IEmployeeManager>().To<EmployeeManager>();
        }
    }
}