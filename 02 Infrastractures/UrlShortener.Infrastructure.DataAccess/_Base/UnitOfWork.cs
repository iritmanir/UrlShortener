using System.Threading.Tasks;
using UrlShortener.Contracts._Base;

namespace UrlShortener.Infrastructure.DataAccess._Base
{
    public sealed class UnitOfWork<TDbContext> : IUnitOfWork
        where TDbContext : BaseDbContext
    {

        private readonly TDbContext _dbContext;
        private readonly IUnitOfWorkConfiguration _config;
        public UnitOfWork(TDbContext dbContext, IUnitOfWorkConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;

        }

        public void BeginTransaction() => _dbContext.BeginTransaction();
        public Task BeginTransactionAsync() => _dbContext.BeginTransactionAsync();

        public int Commit() => _dbContext.SaveChanges();
        public async Task<int> CommitAsync() => await _dbContext.SaveChangesAsync();

        public void Rollback() => _dbContext.RollbackTransaction();
        public Task RollbackAsync() => _dbContext.RollbackTransactionAsync();
    }
}