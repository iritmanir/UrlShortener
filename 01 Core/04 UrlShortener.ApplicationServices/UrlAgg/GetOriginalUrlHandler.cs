using System;
using Framework.Domain.Exceptions;
using System.Threading.Tasks;
using UrlShortener.ApplicationServices._Base;
using UrlShortener.Contracts._Base;
using UrlShortener.DomainModels.UrlAgg.Dtoes;
using UrlShortener.DomainModels.UrlAgg.Entities;
using UrlShortener.DomainModels.UrlAgg.Requests;
using UrlShortener.DomainModels.UrlAgg.ValueObjects;

namespace UrlShortener.ApplicationServices.UrlAgg
{
    public class GetOriginalUrlHandler : RequestHandlerAsync<GetOriginalUrl, OriginalUrlDto>
    {
        public GetOriginalUrlHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override async Task<OriginalUrlDto> HandleAsync(GetOriginalUrl req)
        {
            var shortKey = new UrlShortKey(req.ShortKey);

            //todo => update unitOfWork
            //var url = await UnitOfWork.UrlRepository.GetAsync(shortKey.Value);
            var url = new Url(Guid.NewGuid(), shortKey, new UrlLongUrl("http://google.com"));
            if (url is null)
                throw new DomainException("Url not found.");

            return new OriginalUrlDto(url.LongUrl.Value);
        }
    }
}