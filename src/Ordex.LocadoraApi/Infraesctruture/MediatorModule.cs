using Autofac;
using MediatR;
using Ordex.Locadora.Shared;
using System.Reflection;

namespace Ordex.LocadoraApi.Infraesctruture
{

    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var domainAssembly = typeof(Ambiente).GetTypeInfo().Assembly;
            builder
                .RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder
                .RegisterAssemblyTypes(domainAssembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>))
                .InstancePerDependency();
            builder
                .RegisterAssemblyTypes(domainAssembly)
                .AsClosedTypesOf(typeof(INotificationHandler<>));



        }
    }
}
