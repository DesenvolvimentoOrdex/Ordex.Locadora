using AutoMapper;
using Ordex.Locadora.Domain.Cadastros.Frotas;
using Ordex.Locadora.Shared.DTOs;


namespace Ordex.Locadora.Infraesctuture.Mappings;

public class LocadoraMapping : Profile
{
    public LocadoraMapping()
    {
        CreateMap<Veiculo, VeiculoViewModel>();
    }
}
