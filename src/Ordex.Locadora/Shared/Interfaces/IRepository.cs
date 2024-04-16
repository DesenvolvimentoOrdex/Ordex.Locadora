namespace Ordex.Locadora.Shared.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Adicionar(T entity);
        Task Atualizar(T entity);
        
    }
}