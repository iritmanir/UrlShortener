using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using UrlShortener.ApplicationServices.UrlAgg;
using UrlShortener.DomainModels.UrlAgg.Dtoes;
using UrlShortener.DomainModels.UrlAgg.Requests;
using UrlShortener.EndPoints.API.Configuration;
using UrlShortener.EndPoints.API.Extension;

namespace UrlShortener.EndPoints.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        protected ServiceConfig Config => HttpContext.ServiceContext();

        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(ShortUrlDto), 200)]
        public async Task<IActionResult> Create(
            [FromBody, Required] CreateShortUrl req,
            [FromServices] CreateShortUrlHandler handler)
        {
            var result = await handler.HandleAsync(req);
            result.ShortUrl = Config.BaseUrl + "/" + result.ShortUrl;
            return new OkObjectResult(result);
        }

        [Route("{key}")]
        [HttpGet]
        [ProducesResponseType(typeof(ShortUrlDto), 200)]
        public async Task<IActionResult> Get(
            [FromRoute, Required] string key,
            [FromServices] GetOriginalUrlHandler handler)
        {
            var result = await handler.HandleAsync(new GetOriginalUrl(key));
            return new OkObjectResult(result);
        }
    }
}