using Framework.Domain.BaseModels;
using System;
using UrlShortener.DomainModels.UrlAgg.Events;
using UrlShortener.DomainModels.UrlAgg.ValueObjects;

namespace UrlShortener.DomainModels.UrlAgg.Entities
{
    public class Url : BaseAggregateRoot<Guid>
    {
        public UrlShortKey ShortKey { get; private set; }
        public UrlLongUrl LongUrl { get; private set; }

        private Url() { }

        public Url(Guid id, UrlShortKey shortKey, UrlLongUrl longUrl)
        {
            Id = id;
            ShortKey = shortKey;
            LongUrl = longUrl;

            AddEvent(new UrlCreated(Id, ShortKey.Value, LongUrl.Value));
        }
    }
}