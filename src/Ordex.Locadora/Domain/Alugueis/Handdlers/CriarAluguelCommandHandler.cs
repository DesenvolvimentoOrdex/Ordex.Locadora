using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Alugueis.Commands;
using Ordex.Locadora.Domain.Cadastros.Clientes;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Alugueis.Handdlers
{
    public sealed class CriarAluguelCommandHandler : IRequestHandler<CriarAluguelCommand, Result<Aluguel>>
    {
        private readonly IAluguelRepository _aluguelRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IVeiculoRepository _veiculoRepository;

        public CriarAluguelCommandHandler(IAluguelRepository aluguelRepository, IClienteRepository clienteRepository, IFuncionarioRepository funcionarioRepository, IVeiculoRepository veiculoRepository)
        {
            _aluguelRepository = aluguelRepository;
            _clienteRepository = clienteRepository;
            _funcionarioRepository = funcionarioRepository;
            _veiculoRepository = veiculoRepository;
        }

        public async Task<Result<Aluguel>> Handle(CriarAluguelCommand request, CancellationToken cancellationToken)
        {
            var veiculo = await _veiculoRepository.ObterPorPlaca(request.PlacaVeiculo);
            if (veiculo.HasNoValue)
            {
                return Result.Failure<Aluguel>($"Veículo com a placa:{request.PlacaVeiculo}, não econtrado!");
            }
            var funcionario = await _funcionarioRepository.ObterPorId(request.CodigoFuncionario);
            if (funcionario.HasNoValue)
            {
                return Result.Failure<Aluguel>($"Funcionário com o código:{request.CodigoFuncionario}, não econtrado!");
            }

            var cliente = await _clienteRepository.ObterPorId(request.CodigoCliente);
            if (funcionario.HasNoValue)
            {
                return Result.Failure<Aluguel>($"Cliente com o código:{request.CodigoCliente}, não econtrado!");
            }

            var aluguel = await _aluguelRepository.ObterPorVeiculo(request.PlacaVeiculo);
            if (aluguel.HasValue)
            {
                if (aluguel.Value.Status == EnumStatusAluguel.Aberto)
                {
                    return Result.Failure<Aluguel>($"Existe um aluguel em andamento para o veiculo:{request.PlacaVeiculo}");
                }
            }

            var aluguelNovo = Aluguel.Novo(request.CodigoCliente, request.CodigoFuncionario, request.PlacaVeiculo, request.Valor, request.PossuiDesconto);

            if (request.PossuiDesconto)
            {
                aluguelNovo.CriarDesconto(request.PercentualDesconto);
            }

            aluguelNovo.InserirCliente(cliente.Value);

            aluguelNovo.InserirFuncionario(funcionario.Value);

            aluguelNovo.InserirVeiculo(veiculo.Value);

            await _aluguelRepository.Adicionar(aluguelNovo);

            return Result.Success<Aluguel>(aluguelNovo);
        }
    }
}
