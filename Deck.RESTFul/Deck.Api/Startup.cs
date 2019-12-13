using Deck.Api.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Deck.Api
{
    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configure Services
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddHateoas();

            services.AddCustomServices(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Deck.Api", Version = "1.0" });
            });
        }

        /// <summary>
        /// Configure App
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Deck.Api");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
