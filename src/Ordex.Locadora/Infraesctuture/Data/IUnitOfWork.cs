namespace Ordex.Locadora.Infraesctuture.Data
{
    public interface IUnitOfWork
    {
        Task<int> Commit();
    }
}