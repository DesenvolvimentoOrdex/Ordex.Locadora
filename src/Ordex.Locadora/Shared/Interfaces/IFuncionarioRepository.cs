using CSharpFunctionalExtensions;
using Ordex.Locadora.Domain.Cadastros.Funcionarios;

namespace Ordex.Locadora.Shared.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task Adicionar(Funcionario entity);
        Task Atualizar(Funcionario entity);
        Task<List<Funcionario>> ObterTodos();
        Task<Maybe<Funcionario>> ObterPorId(int id);
        Task<Maybe<Funcionario>> ObterPorCpfCnpj(string cpfCnpj);
        Task<Maybe<Funcionario>> ObterPorUsuarioId(string id);
    }
}
