﻿using CSharpFunctionalExtensions;
using Ordex.Locadora.Domain.Cadastros.Funcionarios;

namespace Ordex.Locadora.Shared.Interfaces;

public interface IFuncionarioService
{
    Task<Result<Funcionario>> ObterPorId(int id);
    Task<Result<List<Funcionario>>> ObterTodos();
    Task<Result<Funcionario>> ObterPorCpfnpj(string cpfCnpj);
    Task<Result<bool>> ExisteCpfCnpj(string cpfCnpj);
}
