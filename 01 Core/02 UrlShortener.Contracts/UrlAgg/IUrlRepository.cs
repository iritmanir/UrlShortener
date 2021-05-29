using System.Threading.Tasks;
using UrlShortener.DomainModels.UrlAgg.Entities;

namespace UrlShortener.Contracts.UrlAgg
{
    public interface IUrlRepository
    {
        Task AddAsync(Url url);
        Task<Url> GetAsync(string shortKey);
    }
}