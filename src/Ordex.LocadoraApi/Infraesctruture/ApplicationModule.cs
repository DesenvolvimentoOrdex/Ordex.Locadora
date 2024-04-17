using Autofac;
using Ordex.Locadora.Domain.Cadastros.Clientes;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.LocadoraApi.Infraesctruture
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClienteRepository>().As<IClienteRepository>();
        }
    }
}
