using System.Threading.Tasks;
using UrlShortener.Contracts.UrlAgg;

namespace UrlShortener.Contracts._Base
{
    public interface IUnitOfWork
    {
        //void InitiateDatabase();
        //Task InitiateDatabaseAsync();

        void BeginTransaction();
        Task BeginTransactionAsync();

        int Commit();
        Task<int> CommitAsync();

        void Rollback();
        Task RollbackAsync();

        IUrlRepository UrlRepository { get; set; }
    }
}