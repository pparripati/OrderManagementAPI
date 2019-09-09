using System.Web.Http;
using Unity;
using Unity.WebApi;
using OrderManagement.Interfaces;
using OrderManagement.Repository;

namespace OrderManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //registering the repositories
            container.RegisterType<IOrderRepository, OrderRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}