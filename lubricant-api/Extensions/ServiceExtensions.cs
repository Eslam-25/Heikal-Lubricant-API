using Heikal.Lubricant.Core.Interfaces;
using Heikal.Lubricant.Core.Interfaces.Repositories;
using Heikal.Lubricant.Core.Services;
using Heikal.Lubricant.Infrastructure.Data;
using Heikal.Lubricant.LoggerService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace lubricant_api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void RegisterServices(this IServiceCollection services) 
        {
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository <>));
            services.AddScoped<IDayService, DayService>();
            services.AddScoped<ILineService, LineService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
        }

        public static void ConfigureContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LubricantContext>(options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }
    }
}
