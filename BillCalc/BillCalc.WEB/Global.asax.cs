using BillCalc.BLL.Infrastructure;
using BillCalc.WEB.Util;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BillCalc.WEB
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var billModule = new BillModule();
            var serviceModule = new ServiceModule("BillDBConnection");
            var kernel = new StandardKernel(billModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
