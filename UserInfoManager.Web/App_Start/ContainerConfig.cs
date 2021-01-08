using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserInfoManager.Data.Services;

namespace UserInfoManager.Web
{
    public static class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterApiControllers(typeof(MvcApplication).Assembly); // For Api Controllers
            builder.RegisterType<DataOperations>()
                   .As<IUserData>()
                   .InstancePerRequest(); // after the instance is over it creates a new
            builder.RegisterType<DataOperations>()
                   .As<ITaxOfficeData>()
                   .InstancePerRequest(); // after the instance is over it creates a new
            builder.RegisterType<UserInfoManagerDbContext>().InstancePerRequest();
            //.SingleInstance(); // Just gives a single Instance when a request is raised - NOT working with multiple users
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); // wow

           // httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container); //wow in api :P
        }
    }
}