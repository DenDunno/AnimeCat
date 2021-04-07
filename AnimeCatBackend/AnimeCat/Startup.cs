using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AnimeCat.Models;

namespace AnimeCat
{
    public class Startup
    {
        private readonly IConfiguration _config;


        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            string connection = _config.GetConnectionString("DefaultConnection");
            services.AddDbContext<AnimeContext>(options => options.UseSqlServer(connection));
            services.AddControllers();
            services.AddCors();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
