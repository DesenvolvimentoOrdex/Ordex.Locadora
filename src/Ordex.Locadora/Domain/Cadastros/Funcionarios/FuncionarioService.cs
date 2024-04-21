using CSharpFunctionalExtensions;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Funcionarios;

public class FuncionarioService : IFuncionarioService
{
    private readonly IFuncionarioRepository _funcionarioRepo;

    public FuncionarioService(IFuncionarioRepository funcionarioRepo)
    {
        _funcionarioRepo = funcionarioRepo;
    }
    public async Task<Result<Funcionario>> ObterPorId(int id)
    {
        var funcionario = await _funcionarioRepo.ObterPorId(id);
        if (funcionario.HasNoValue)
        {
            return Result.Failure<Funcionario>("Funcionario não encontrado.");
        }
        return funcionario.Value;
    }

    public async Task<Result<List<Funcionario>>> ObterTodos()
    {
        return await _funcionarioRepo.ObterTodos();
    }
}
