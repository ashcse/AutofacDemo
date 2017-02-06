using Autofac;
using Autofac.Integration.Mvc;
using ProductManagement.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ProductManagement.Attributes;
using Autofac.Extras.NLog;
using ProductManagement.Controllers;

namespace ProductManagement
{
    public class AutofacWebAPiConfig
    {
        public static void Initialize(HttpConfiguration config)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());

            // This will enable property injection into custom action filtes
            //This allows you to add properties to your filter attributes and any matching dependencies 
            // that are registered in the container will be injected into the properties.
          

            //builder.RegisterType<NLog.Logger>().As<NLog.ILogger>().InstancePerRequest();
            builder.RegisterModule<NLogModule>();
            builder.RegisterFilterProvider();

            //builder.RegisterType<LoggingExceptionFilter>().AsExceptionFilterFor<BaseController>().AsSelf();

            //builder.RegisterType<LoggingExceptionFilter>().AsExceptionFilterFor<BaseController>().AsSelf();

            builder.RegisterType<LoggingExceptionFilter>().AsExceptionFilterFor<BaseController>()
            .InstancePerRequest().PropertiesAutowired();


            builder.RegisterType<ApplicationService.ApplicationService>().As<IApplicationService>().SingleInstance();
            builder.RegisterType<DataService.DataService>().As<DataService.IDataService>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));            
        }
    }
}