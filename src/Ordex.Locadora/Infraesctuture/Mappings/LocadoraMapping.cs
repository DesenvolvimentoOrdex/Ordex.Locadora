using AutoMapper;
using Ordex.Locadora.Domain.Alugueis;
using Ordex.Locadora.Domain.Cadastros.Clientes;
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
        .ForMember(a => a.Email, opt => opt.MapFrom(src => src.Usuario.UserName))
        .ForMember(a => a.endereco, opt => opt.MapFrom(src => src.Endereco))
        .ForMember(a => a.DataNascimento, opt => opt.MapFrom(src => src.DataFiliacao));
        CreateMap<Cliente, ClienteViewModel>()
        .ForMember(a => a.Email, opt => opt.MapFrom(src => src.Usuario.UserName))
        .ForMember(a => a.endereco, opt => opt.MapFrom(src => src.Endereco))
        .ForMember(a => a.DataNascimento, opt => opt.MapFrom(src => src.DataFiliacao));

        CreateMap<Endereco, EnderecoViewModel>();
        CreateMap<Aluguel, AluguelViewModel>();
    }
}
