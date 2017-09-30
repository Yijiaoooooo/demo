using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using System.Configuration;
using System.Reflection;
using Data.Domain;
using Data.Respository;
using Data.Context;
using System.Web.Http;
using BLL.ReservationS;

namespace WEB.UI
{
    public class IocConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(typeof(IocConfig).Assembly);

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();



            // Register your MVC controllers.
            builder.RegisterControllers(typeof(IocConfig).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            RegisterCustomObjects(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

        }
        static void RegisterCustomObjects(ContainerBuilder builder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Reser"].ConnectionString;
#pragma warning disable CS0618 // 'RegistrationExtensions.InstancePerHttpRequest<TLimit, TActivatorData, TStyle>(IRegistrationBuilder<TLimit, TActivatorData, TStyle>, params object[])' is obsolete: 'Instead of using the MVC-specific InstancePerHttpRequest, please switch to the InstancePerRequest shared registration extension from Autofac core.'
            builder.Register<IDbContext>(c => new DefaultObjectContext(connectionString)).InstancePerHttpRequest();
#pragma warning restore CS0618 // 'RegistrationExtensions.InstancePerHttpRequest<TLimit, TActivatorData, TStyle>(IRegistrationBuilder<TLimit, TActivatorData, TStyle>, params object[])' is obsolete: 'Instead of using the MVC-specific InstancePerHttpRequest, please switch to the InstancePerRequest shared registration extension from Autofac core.'
#pragma warning disable CS0618 // 'RegistrationExtensions.InstancePerHttpRequest<TLimit, TActivatorData, TStyle>(IRegistrationBuilder<TLimit, TActivatorData, TStyle>, params object[])' is obsolete: 'Instead of using the MVC-specific InstancePerHttpRequest, please switch to the InstancePerRequest shared registration extension from Autofac core.'
            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepository<>)).InstancePerHttpRequest();
#pragma warning restore CS0618 // 'RegistrationExtensions.InstancePerHttpRequest<TLimit, TActivatorData, TStyle>(IRegistrationBuilder<TLimit, TActivatorData, TStyle>, params object[])' is obsolete: 'Instead of using the MVC-specific InstancePerHttpRequest, please switch to the InstancePerRequest shared registration extension from Autofac core.'


            builder.RegisterType<ReservationService>().As<IReservationService>().InstancePerHttpRequest();
        }
    }
    
}