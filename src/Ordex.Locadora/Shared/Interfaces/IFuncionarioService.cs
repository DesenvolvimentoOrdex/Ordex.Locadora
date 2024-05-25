using CSharpFunctionalExtensions;
using Ordex.Locadora.Shared.DTOs;

namespace Ordex.Locadora.Shared.Interfaces;

public interface IFuncionarioService
{
    Task<Result<FuncionarioViewModel>> ObterPorId(int id);
    Task<Result<List<FuncionarioViewModel>>> ObterTodos();
    Task<Result<FuncionarioViewModel>> ObterPorCpfnpj(string cpfCnpj);
    Task<Result<bool>> ExisteCpfCnpj(string cpfCnpj);
}
