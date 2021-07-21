using StudyAbroad.Repositories;
using StudyAbroad.Web.Controllers;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace StudyAbroad.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<INewsRepository, NewsRepository>();
            container.RegisterType<INewsCategoryRepository, NewsCategoryRepository>();
            container.RegisterType<IOrderRepository, OrderRepository>();
            container.RegisterType<IOrderCategoryRepository, OrderCategoryRepository>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<IMenuRepository, MenuRepository>();
            container.RegisterType<IProgramRepository, ProgramRepository>();
          //  container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<AccountController>(new InjectionConstructor());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}