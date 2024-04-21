﻿using CSharpFunctionalExtensions;
using Ordex.Locadora.Domain.Cadastros.Clientes;

namespace Ordex.Locadora.Shared.Interfaces
{
    public interface IClienteService
    {
        Task<Result<Cliente>> ObterPorId(int id);
        Task<Result<List<Cliente>>> ObterTodos();

    }
}