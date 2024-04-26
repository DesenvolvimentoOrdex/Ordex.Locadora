using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Cadastros.Funcionarios.Commands;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Funcionarios.Handllers;

public sealed class CriarFuncionarioCommandHandler : IRequestHandler<CriarFuncionarioCommand, Result<int>>
{
    private readonly IFuncionarioRepository _funcionarioRepo;

    public CriarFuncionarioCommandHandler(IFuncionarioRepository funcionarioRepo)
    {
        _funcionarioRepo = funcionarioRepo;
    }
    public async Task<Result<int>> Handle(CriarFuncionarioCommand request, CancellationToken cancellationToken)
    {
        var funcionario = await _funcionarioRepo.ObterPorUsuarioId(request.Usuarios.Id);
        if (funcionario.HasValue)
        {
            return Result.Failure<int>(funcionario.Value.Codigo.ToString());
        }

        var existeCpfCnpj = await _funcionarioRepo.ObterPorCpfCnpj(request.CpfCnpj);
        if (existeCpfCnpj.HasValue)
        {
            return Result.Failure<int>($" Cpf ou Cnpj cadastrado para o funcionario com o codigo: {existeCpfCnpj.Value.Codigo}, verifique!"
            );
        }

        var funcionarioNovo = Funcionario.Novo(request. CpfCnpj, request.NomeRazao, request.DataFiliacao, request.Telefone, true, request.Usuarios.Id);
        if (funcionarioNovo.IsFailure)
        {
            return Result.Failure<int>(funcionarioNovo.Error);
        }

        funcionarioNovo.Value.Contrato("Gerente");

        funcionarioNovo.Value.CriarUsuario(request.Usuarios);

        await _funcionarioRepo.Adicionar(funcionarioNovo.Value);

        return funcionarioNovo.Value.Codigo;
    }
}
