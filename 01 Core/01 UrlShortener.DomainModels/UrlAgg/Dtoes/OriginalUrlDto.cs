using Framework.Domain.Dtoes;

namespace UrlShortener.DomainModels.UrlAgg.Dtoes
{
    public class OriginalUrlDto : IDto
    {
        public string LongUrl { get; set; }

        public OriginalUrlDto() { }

        public OriginalUrlDto(string longUrl)
        {
            LongUrl = longUrl;
        }
    }
}
