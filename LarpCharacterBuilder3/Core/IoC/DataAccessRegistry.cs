using System.Linq;
using Autofac;
using Core.CQRS;
using Core.Helpers;
using LarpCharacterBuilder3.Core.Core.Dapper;
using Microsoft.Extensions.Configuration;

namespace LarpCharacterBuilder3.Core.IoC
{
    public class DataAccessRegistry: Autofac.Module
    {
        private readonly IConfigurationRoot _configuration;

        public DataAccessRegistry(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = new[] { this.GetType().Assembly, typeof(AssemblyHelpers).Assembly }.Distinct().ToArray();
            builder.RegisterAssemblyTypes(assemblies).Where(x => x.IsClass).InstancePerDependency();
            builder.RegisterAssemblyTypes(assemblies).Where(x => x.IsClass).AsImplementedInterfaces().InstancePerDependency();
            
            builder.RegisterType<IDapperDataSession>().As<IDataSession>();
            
            base.Load(builder);
        }
    }
}