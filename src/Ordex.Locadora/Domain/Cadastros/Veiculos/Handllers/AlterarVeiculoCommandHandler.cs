using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Cadastros.Veiculos.Commands;
using Ordex.Locadora.Shared.DTOs;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Veiculos.Handllers
{
    public sealed class AlterarVeiculoCommandHandler : IRequestHandler<AlterarVeiculoCommand, Result<VeiculoViewModel>>
    {
        private readonly IVeiculoRepository _veiculoRepo;
        private readonly IMapper _mapper;

        public AlterarVeiculoCommandHandler(IVeiculoRepository veiculoRepo, IMapper mapper)
        {
            _veiculoRepo = veiculoRepo;
            _mapper = mapper;
        }
        public async Task<Result<VeiculoViewModel>> Handle(AlterarVeiculoCommand request, CancellationToken cancellationToken)
        {
            var veiculo = await _veiculoRepo.ObterPorPlaca(request.Placa);
            if (veiculo.HasNoValue)
            {
                return Result.Failure<VeiculoViewModel>("Veículo não encontrado!");
            }

            veiculo.Value.AlterarDados(request.Marca, request.Modelo, request.Ano, request.Cor, request.Valor, request.Renavam, request.Chassi);

            await _veiculoRepo.Atualizar(veiculo.Value);

            var veiculoViewModel = _mapper.Map<VeiculoViewModel>(veiculo.Value);
            return Result.Success<VeiculoViewModel>(veiculoViewModel);
        }
    }
}
