using Framework.Domain.Dtoes;

namespace UrlShortener.DomainModels.UrlAgg.Dtoes
{
    public class ShortUrlDto : IDto
    {
        public string ShortUrl { get; set; }

        public ShortUrlDto(string shortUrl)
        {
            ShortUrl = shortUrl;
        }
    }
}