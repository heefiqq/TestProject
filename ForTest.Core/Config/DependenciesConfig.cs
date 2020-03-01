using ForTest.Core.Service;
using ForTest.Core.Service.Track;
using Ninject;
using Ninject.Modules;

namespace ForTest.Core.Config
{
    public class DependenciesConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<ITrackService>().To<TrackService>();
            Bind<ICustomerService>().To<CustomerService>();
        }
    }
}
