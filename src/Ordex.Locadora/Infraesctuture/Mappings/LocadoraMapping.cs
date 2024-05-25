using AutoMapper;
using Ordex.Locadora.Domain.Cadastros.Enderecos;
using Ordex.Locadora.Domain.Cadastros.Frotas;
using Ordex.Locadora.Domain.Cadastros.Funcionarios;
using Ordex.Locadora.Shared.DTOs;


namespace Ordex.Locadora.Infraesctuture.Mappings;

public class LocadoraMapping : Profile
{
    public LocadoraMapping()
    {
        CreateMap<Veiculo, VeiculoViewModel>();
        CreateMap<Funcionario, FuncionarioViewModel>()
        .ForMember(a=> a.Email, opt => opt.MapFrom(src => src.Usuario.UserName))
        .ForMember(a => a.endereco, opt => opt.MapFrom(src => src.Endereco));
        CreateMap<Endereco, EnderecoViewModel>();
    }
}
