namespace UrlShortener.EndPoints.API.Configuration
{
    public class ServiceConfig
    {
        public string Id { get; set; } = "Service01";
        public int CacheDuration { get; set; }
        public string BaseUrl { get; set; }
        public SwaggerConfig Swagger { get; set; }
    }
}