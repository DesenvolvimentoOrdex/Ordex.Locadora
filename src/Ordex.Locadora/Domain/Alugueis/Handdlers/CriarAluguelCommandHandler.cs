using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Alugueis.Commands;
using Ordex.Locadora.Domain.Cadastros.Clientes;
using Ordex.Locadora.Shared.DTOs;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Alugueis.Handdlers
{
    public sealed class CriarAluguelCommandHandler : IRequestHandler<CriarAluguelCommand, Result<AluguelViewModel>>
    {
        private readonly IAluguelRepository _aluguelRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public CriarAluguelCommandHandler(IAluguelRepository aluguelRepository, IClienteRepository clienteRepository, IFuncionarioRepository funcionarioRepository, IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _aluguelRepository = aluguelRepository;
            _clienteRepository = clienteRepository;
            _funcionarioRepository = funcionarioRepository;
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<Result<AluguelViewModel>> Handle(CriarAluguelCommand request, CancellationToken cancellationToken)
        {
            var veiculo = await _veiculoRepository.ObterPorPlaca(request.PlacaVeiculo);
            if (veiculo.HasNoValue)
            {
                return Result.Failure<AluguelViewModel>($"Veículo com a placa:{request.PlacaVeiculo}, não econtrado!");
            }
            var funcionario = await _funcionarioRepository.ObterPorId(request.CodigoFuncionario);
            if (funcionario.HasNoValue)
            {
                return Result.Failure<AluguelViewModel>($"Funcionário com o código:{request.CodigoFuncionario}, não econtrado!");
            }

            var cliente = await _clienteRepository.ObterPorId(request.CodigoCliente);
            if (funcionario.HasNoValue)
            {
                return Result.Failure<AluguelViewModel>($"Cliente com o código:{request.CodigoCliente}, não econtrado!");
            }

            var aluguel = await _aluguelRepository.ObterPorVeiculo(request.PlacaVeiculo);
            if (aluguel.HasValue)
            {
                if (aluguel.Value.Status == EnumStatusAluguel.Aberto)
                {
                    return Result.Failure<AluguelViewModel>($"Existe um aluguel em andamento para o veiculo:{request.PlacaVeiculo}");
                }
            }

            var aluguelNovo = Aluguel.Novo(request.CodigoCliente, request.CodigoFuncionario, request.PlacaVeiculo, request.Valor, request.PossuiDesconto);

            aluguelNovo.CriarDesconto(request.PercentualDesconto);

            aluguelNovo.InserirCliente(cliente.Value);

            aluguelNovo.InserirFuncionario(funcionario.Value);

            aluguelNovo.InserirVeiculo(veiculo.Value);

            await _aluguelRepository.Adicionar(aluguelNovo);

            var aluguelCriado = await _aluguelRepository.ObterPorId(aluguelNovo.Codigo);

            var aluguelViewModel = _mapper.Map<AluguelViewModel>(aluguelCriado.Value);
            return Result.Success<AluguelViewModel>(aluguelViewModel);
        }
    }
}
