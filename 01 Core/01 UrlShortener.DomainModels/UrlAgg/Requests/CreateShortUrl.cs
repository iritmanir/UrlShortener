using Framework.Domain.Requests;

namespace UrlShortener.DomainModels.UrlAgg.Requests
{
    public class CreateShortUrl : IRequest
    {
        public string LongUrl { get; set; }
    }
}