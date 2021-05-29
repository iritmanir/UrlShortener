using Framework.Domain.Events;
using System;

namespace UrlShortener.DomainModels.UrlAgg.Events
{
    public class UrlCreated : IEvent
    {
        public Guid Id { get; }
        public string ShortKey { get; }
        public string Url { get; }

        public UrlCreated(Guid id, string shortKey, string url)
        {
            Id = id;
            ShortKey = shortKey;
            Url = url;
        }
    }
}