using CSharpFunctionalExtensions;
using Ordex.Locadora.Domain.Cadastros.Funcionarios;

namespace Ordex.Locadora.Shared.Interfaces;

public interface IFuncionarioService
{
    Task<Result<Funcionario>> ObterPorId(int id);
    Task<Result<List<Funcionario>>> ObterTodos();
}
