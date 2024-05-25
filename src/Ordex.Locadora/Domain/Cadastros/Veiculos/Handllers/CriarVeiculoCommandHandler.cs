using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Cadastros.Frotas;
using Ordex.Locadora.Domain.Cadastros.Veiculos.Commands;
using Ordex.Locadora.Shared.DTOs;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Veiculos.Handllers
{
    public sealed class CriarVeiculoCommandHandler : IRequestHandler<CriarVeiculoCommand, Result<VeiculoViewModel>>
    {
        private readonly IVeiculoRepository _veiculoRepo;
        private readonly IMapper _mapper;

        public CriarVeiculoCommandHandler(IVeiculoRepository veiculoRepo, IMapper mapper)
        {
            _veiculoRepo = veiculoRepo;
            _mapper = mapper;
        }

        public async Task<Result<VeiculoViewModel>> Handle(CriarVeiculoCommand request, CancellationToken cancellationToken)
        {
            var veiculo = await _veiculoRepo.ObterPorPlaca(request.Placa);
            if (veiculo.HasValue)
            {
                return Result.Failure<VeiculoViewModel>("Veículo já possui cadastro!");
            }

            var veiculoNovo = Veiculo.Novo(request.Placa, request.Marca, request.Modelo, request.Ano, request.Cor, request.Valor, request.Renavam, request.Chassi);

            await _veiculoRepo.Adicionar(veiculoNovo);

            var veiculoViewModel = _mapper.Map<VeiculoViewModel>(veiculo.Value);
            return Result.Success<VeiculoViewModel>(veiculoViewModel);
        }
    }
}
