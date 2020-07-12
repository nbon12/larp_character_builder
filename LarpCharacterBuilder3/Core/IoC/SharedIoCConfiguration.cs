﻿using System.Linq;
using Autofac;
using Core.CQRS;
using Core.Helpers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Core.IoC
{
    public class SharedIoCConfiguration : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = new[] { this.GetType().Assembly, typeof(AssemblyHelpers).Assembly }.Distinct().ToArray();
            builder.RegisterAssemblyTypes(assemblies).Where(x => x.IsClass).InstancePerDependency();
            builder.RegisterAssemblyTypes(assemblies).Where(x => x.IsClass).AsImplementedInterfaces().InstancePerDependency();


            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();


            //builder.Register(c => new SecurityContext(Thread.CurrentPrincipal)).As<ISecurityContext>().InstancePerDependency();

            //builder.RegisterAssemblyTypes(assemblies).AsClosedTypesOf(typeof(IValidator<>)).AsImplementedInterfaces().InstancePerDependency();
            //builder.RegisterAssemblyTypes(assemblies).AsClosedTypesOf(typeof(IQueryHandler<,>)).AsImplementedInterfaces().InstancePerDependency();
            //builder.RegisterAssemblyTypes(assemblies).AsClosedTypesOf(typeof(ICommandExecutor<>)).AsImplementedInterfaces().InstancePerDependency();

            //builder.RegisterAssemblyTypes(assemblies).AsClosedTypesOf(typeof(IHttpExceptionHandler<>)).AsImplementedInterfaces().InstancePerDependency();
            //builder.RegisterAssemblyTypes(assemblies).AsClosedTypesOf(typeof(ILogger<>)).AsImplementedInterfaces().InstancePerDependency();
            //builder.RegisterAssemblyTypes(assemblies).AsClosedTypesOf(typeof(IOptions<>)).AsImplementedInterfaces().InstancePerDependency();

            //builder.RegisterType<CommandSenderWithFactory>().As<ICommandSender>();
            
            base.Load(builder);
        }
    }
}