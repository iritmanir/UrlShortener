using System.Threading.Tasks;
using UrlShortener.Contracts._Base;
using UrlShortener.Contracts.UrlAgg;

namespace UrlShortener.Infrastructure.DataAccess._Base
{
    public sealed class UnitOfWork<TDbContext> : IUnitOfWork
        where TDbContext : BaseDbContext
    {
        public IUrlRepository UrlRepository { get; set; }

        private readonly TDbContext _dbContext;
        private readonly IUnitOfWorkConfiguration _config;
        public UnitOfWork(TDbContext dbContext, IUnitOfWorkConfiguration config,
            IUrlRepository urlRepository)
        {
            _dbContext = dbContext;
            _config = config;
            UrlRepository = urlRepository;
        }

        public void BeginTransaction() => _dbContext.BeginTransaction();
        public Task BeginTransactionAsync() => _dbContext.BeginTransactionAsync();

        public int Commit() => _dbContext.SaveChanges();
        public async Task<int> CommitAsync() => await _dbContext.SaveChangesAsync();

        public void Rollback() => _dbContext.RollbackTransaction();
        public Task RollbackAsync() => _dbContext.RollbackTransactionAsync();
    }
}