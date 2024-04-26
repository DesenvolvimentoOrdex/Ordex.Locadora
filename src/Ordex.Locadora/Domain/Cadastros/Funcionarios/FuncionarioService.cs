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

    public async Task<Result<bool>> ExisteCpfCnpj(string cpfCnpj)
    {
        var funcionario = await _funcionarioRepo.ObterPorCpfCnpj(cpfCnpj);
        if (funcionario.HasValue)
        {
            return Result.Failure<bool>("CpfCnpj em uso.");
        }
        return Result.Success<bool>(false);
    }

    public async Task<Result<Funcionario>> ObterPorCpfnpj(string cpfCnpj)
    {
        var funcionario = await _funcionarioRepo.ObterPorCpfCnpj(cpfCnpj);
        if (funcionario.HasNoValue)
        {
            return Result.Failure<Funcionario>("Funcionario não encontrado.");
        }
        return funcionario.Value;
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
