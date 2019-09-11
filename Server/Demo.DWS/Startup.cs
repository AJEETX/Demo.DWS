using Demo.DWS.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Logging;
using Demo.DWS.Data;
using Microsoft.EntityFrameworkCore;

namespace Demo.DWS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(config => {
                config.SwaggerDoc("v1", new Info { Title = "Demo API", Version = "V1" });
            });
            services.AddDbContext<DataContext>(x => x.UseInMemoryDatabase("TestDb"));
            services.AddCors();
            services.AddMvc();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IAllPriceService, AllPriceService>();
            services.AddScoped<IFileDataService, FileDataService>();
            services.AddScoped<ILeastExpensivePriceService, LeastExpensivePriceService>();
            services.AddScoped<IMostExpensivePriceService, MostExpensivePriceService>();
            services.AddScoped<IPriceServiceCtx, PriceServiceCtx>();

        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseCors(x => x
                .WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseMvc().UseSwagger().UseSwaggerUI(config => {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo API");
            });
        }
    }
}
