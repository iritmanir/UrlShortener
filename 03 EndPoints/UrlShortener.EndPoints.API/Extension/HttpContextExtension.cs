using Microsoft.AspNetCore.Http;
using UrlShortener.EndPoints.API.Configuration;

namespace UrlShortener.EndPoints.API.Extension
{
    public static class HttpContextExtension
    {
        public static ServiceConfig ServiceContext(this HttpContext httpContext) =>
            (ServiceConfig)httpContext.RequestServices.GetService(typeof(ServiceConfig));
    }
}