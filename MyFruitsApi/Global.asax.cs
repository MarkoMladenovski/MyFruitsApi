using FruitInfoApp;
using MyFruitsApi.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyFruitsApi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //var container = new SimpleInjector.Container();
            //container.Register<IFruitService, FruitService>(Lifestyle.Scoped);
            var container = new Container();
            container.Register<HttpClient>(() => new HttpClient(), Lifestyle.Scoped);

            container.Register<IFruitRepository, FruitRepository>(Lifestyle.Scoped);
            container.Register<IFruitService, FruitService>(Lifestyle.Scoped);
            container.Register<FruitDbContext>(Lifestyle.Scoped);


            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
