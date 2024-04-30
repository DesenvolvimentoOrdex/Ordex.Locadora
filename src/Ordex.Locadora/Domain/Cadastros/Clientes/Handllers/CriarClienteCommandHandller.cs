using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Cadastros.Clientes.Commands;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Clientes.Handllers
{
    public sealed class CriarClienteCommandHandller : IRequestHandler<CriarClienteCommand, Result<int>>
    {

        private readonly IClienteRepository _clienteRepo;
 
        public CriarClienteCommandHandller(IClienteRepository clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        public async Task<Result<int>> Handle(CriarClienteCommand request, CancellationToken cancellationToken)
        {
            var clientex = await _clienteRepo.ObterPorUsuarioId(request.Usuarios.Id);
            if (clientex.HasValue)
            {
                return Result.Failure<int>(clientex.Value.Codigo.ToString());
            }

            var existeCpfCnpj = await _clienteRepo.ObterPorCpfCnpj(request.CpfCnpj);
            if (existeCpfCnpj.HasValue)
            {
                return Result.Failure<int>($" Cpf ou Cnpj cadastrado para o cliente com o codigo: {existeCpfCnpj.Value.Codigo}, verifique!"
                );
            }

            var clienteNovo = Cliente.Novo(request.CpfCnpj, request.NomeRazao, request.DataFiliacao, request.Telefone, true, request.Usuarios.Id);
            if (clienteNovo.IsFailure)
            {
                return Result.Failure<int>(clienteNovo.Error);
            }

            clienteNovo.Value.IncluirEdereco(request.Endereco);

            await _clienteRepo.Adicionar(clienteNovo.Value);

            return clienteNovo.Value.Codigo;

        }
    }
}
