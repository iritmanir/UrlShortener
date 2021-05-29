using Framework.Tools.ShortKey;
using System;
using System.Threading.Tasks;
using UrlShortener.ApplicationServices._Base;
using UrlShortener.Contracts._Base;
using UrlShortener.DomainModels.UrlAgg.Dtoes;
using UrlShortener.DomainModels.UrlAgg.Entities;
using UrlShortener.DomainModels.UrlAgg.Requests;
using UrlShortener.DomainModels.UrlAgg.ValueObjects;

namespace UrlShortener.ApplicationServices.UrlAgg
{
    public class CreateShortUrlHandler : RequestHandlerAsync<CreateShortUrl, ShortUrlDto>
    {
        private readonly IShortKeyGenerator _shortKeyGenerator;
        public CreateShortUrlHandler(IUnitOfWork unitOfWork, IShortKeyGenerator shortKeyGenerator) : base(unitOfWork)
        {
            _shortKeyGenerator = shortKeyGenerator;
        }

        public override async Task<ShortUrlDto> HandleAsync(CreateShortUrl req)
        {
            var longUrl = new UrlLongUrl(req.LongUrl);
            var shortUrl = await _shortKeyGenerator.GenerateUniqKey();
            var url = new Url(Guid.NewGuid(), new UrlShortKey(shortUrl), longUrl);
            
            //await UnitOfWork.UrlRepository.AddAsync(url);
            //await UnitOfWork.CommitAsync();
            
            return new ShortUrlDto(shortUrl);
        }
    }
}