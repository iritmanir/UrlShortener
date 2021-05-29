using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UrlShortener.Contracts.UrlAgg;
using UrlShortener.DomainModels.UrlAgg.Entities;
using UrlShortener.Infrastructure.DataAccess._Base;

namespace UrlShortener.Infrastructure.DataAccess.UrlAgg
{
    public class UrlRepository : IUrlRepository
    {
        internal readonly ServiceDbContext DbContext;
        public UrlRepository(ServiceDbContext dbContext)
            => DbContext = dbContext;

        public async Task AddAsync(Url url)
        {
            await DbContext.Url.AddAsync(url);
        }

        public Task<Url> GetAsync(string shortKey)
        {
            return DbContext.Url.SingleOrDefaultAsync(s => s.ShortKey == shortKey);
        }
    }
}