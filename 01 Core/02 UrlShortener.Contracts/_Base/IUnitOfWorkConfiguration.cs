
namespace UrlShortener.Contracts._Base
{
    public interface IUnitOfWorkConfiguration
    {
        string SqlServerConnectionString { get; set; }
    }
}