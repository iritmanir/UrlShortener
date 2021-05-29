using Framework.Tools.ShortKey;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UrlShortener.ApplicationServices.UrlAgg;
using UrlShortener.Contracts._Base;
using UrlShortener.Contracts.UrlAgg;
using UrlShortener.EndPoints.API.Configuration;
using UrlShortener.EndPoints.API.Extension;
using UrlShortener.Infrastructure.DataAccess._Base;
using UrlShortener.Infrastructure.DataAccess.UrlAgg;

namespace UrlShortener.EndPoints.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var serviceConfig = services.AddServiceConfig(Configuration);

            services.AddControllers();
            services.AddTransient<IUrlRepository, UrlRepository>();
            services.AddSingleton<IUnitOfWorkConfiguration, UnitOfWorkConfig>();
            services.AddDbContext<ServiceDbContext>(options => options.UseInMemoryDatabase(databaseName: "UrlShortenerDB"));
            services.AddTransient<IUnitOfWork, UnitOfWork<ServiceDbContext>>();
            services.AddSingleton<IShortKeyGenerator, ShortKeyGenerator>();

            services.AddScoped<CreateShortUrlHandler>();
            services.AddScoped<GetOriginalUrlHandler>();
            services.AddSwagger(serviceConfig);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ServiceConfig config)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.ConfigSwagger(config);
        }
    }
}
