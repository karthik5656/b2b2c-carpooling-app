using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carpooling.App
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // CORS: read allowed origins from configuration (appsettings.json)
            var origins = Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
            if (origins == null || origins.Length == 0)
            {
                // sensible default for development when not configured
                origins = new[] { "http://localhost:3000" };
            }

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins(origins)
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new() { Title = "Carpooling API", Version = "v1" });
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // Always enable Swagger and serve UI at application root so opening the app loads Swagger by default.
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "/docs"; // serve UI at '/'
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Carpooling API v1");
            });

            app.UseHttpsRedirection();

            // Enable CORS
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
