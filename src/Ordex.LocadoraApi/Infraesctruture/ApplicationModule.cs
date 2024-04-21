using Autofac;
using Ordex.Locadora.Domain.Cadastros.Clientes;
using Ordex.Locadora.Domain.Cadastros.Funcionarios;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.LocadoraApi.Infraesctruture
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClienteRepository>().As<IClienteRepository>();
            builder.RegisterType<ClienteService>().As<IClienteService>();
            builder.RegisterType<FuncionarioRepository>().As<IFuncionarioRepository>();
            builder.RegisterType<FuncionarioService>().As<IFuncionarioService>();
        }
    }
}
