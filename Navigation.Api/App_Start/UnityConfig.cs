using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using Navigation.Services;
using Navigation.Common.Sugar;

namespace Navigation.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<DbService, DbService>(new HierarchicalLifetimeManager());
            container.RegisterType<CategoryServices, CategoryServices>(new HierarchicalLifetimeManager());
            container.RegisterType<NavigateServices, NavigateServices>(new HierarchicalLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

    }
}