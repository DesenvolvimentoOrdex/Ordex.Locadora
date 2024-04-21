﻿using CSharpFunctionalExtensions;
using Ordex.Locadora.Domain.Cadastros.Clientes;
using Ordex.Locadora.Domain.Logon;

namespace Ordex.Locadora.Shared.Interfaces
{
    public interface IClienteRepository
    {
        Task Adicionar(Cliente entity);
        Task Atualizar(Cliente entity);
        Task<List<Cliente>> ObterTodos();
        Task<Maybe<Cliente>> ObterPorId(int id);
        Task<Maybe<Cliente>> ObterPorUsuarioId(string id);
    }
}