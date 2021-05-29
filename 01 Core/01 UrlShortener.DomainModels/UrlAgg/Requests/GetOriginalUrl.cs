using Framework.Domain.Requests;

namespace UrlShortener.DomainModels.UrlAgg.Requests
{
    public class GetOriginalUrl : IRequest
    {
        public string ShortKey { get; set; }

        public GetOriginalUrl(string shortKey)
        {
            ShortKey = shortKey;
        }
    }
}