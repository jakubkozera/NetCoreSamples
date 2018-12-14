using DataAccess.Constants;
using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDataAccessConfig(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString(ConnectionString.ConnnectionStringName);

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<AppDbContext>(options =>
                    options.UseNpgsql(connectionString));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IValueRepository, ValueRepository>();

            return services;
        }
    }
}
