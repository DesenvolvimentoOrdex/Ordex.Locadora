using CSharpFunctionalExtensions;
using Ordex.Locadora.Domain.Alugueis;
using Ordex.Locadora.Shared.DTOs;

namespace Ordex.Locadora.Shared.Interfaces
{
    public interface IAluguelService
    {
        Task<Result<AluguelViewModel>> ObterPorId(int id);
        Task<Result<AluguelViewModel>> ObterPorVeiculo(string placa);
        Task<Result<List<AluguelViewModel>>> ObterTodos();
    }
}