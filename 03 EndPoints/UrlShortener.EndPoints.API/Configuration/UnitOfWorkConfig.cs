using Microsoft.Extensions.Configuration;
using UrlShortener.Contracts._Base;

namespace UrlShortener.EndPoints.API.Configuration
{
    public class UnitOfWorkConfig : IUnitOfWorkConfiguration
    {
        public UnitOfWorkConfig(IConfiguration config)
        {
            var section = config.GetSection(nameof(UnitOfWorkConfig));
            section.Bind(this);
        }
        
        public string SqlServerConnectionString { get; set; }
    }
}