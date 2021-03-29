using BillCalc.BLL.Interfaces;
using BillCalc.BLL.Services;
using Ninject.Modules;

namespace BillCalc.WEB.Util
{
    public class BillModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBillService>().To<BillService>();
        }
    }
}