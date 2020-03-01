using ForTest.Core.Config;
using ForTest.Core.Service.Log;
using ForTest.Web.Controllers;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ForTest.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule registrations = new DependenciesConfig();
            var kernel = new StandardKernel(registrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            Logging.InitLogger();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();

            var httpException = ex as HttpException;
            if (httpException != null)
            {
                var routeData = new RouteData();
                routeData.Values.Add("controller", "Error");

                switch (httpException.GetHttpCode())
                {
                    case 400:
                        routeData.Values.Add("action", "BadRequest");
                        break;
                    case 403:
                        routeData.Values.Add("action", "Forbidden");
                        break;
                    case 404:
                        routeData.Values.Add("action", "NotFound");
                        break;
                    default:
#if DEBUG
                        return;
#endif
                        routeData.Values.Add("action", "InternalServerError");
                        break;
                }

                Response.Clear();
                Server.ClearError();
                Response.TrySkipIisCustomErrors = true;

                IController errorController = new ErrorController();
                errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
            }
        }
    }
}
