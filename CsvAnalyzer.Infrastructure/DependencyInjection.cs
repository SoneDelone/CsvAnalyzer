using CsvAnalyzer.Application.Common.Interfaces;
using CsvAnalyzer.Infrastructure.Common.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CsvAnalyzer.Infrastructure.Values.Persistence;

namespace CsvAnalyzer.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration builder)
        {
            return services
                .AddPersistence(builder);
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration builder)
        {
            services.AddDbContext<CsvDbContext>(options =>
                options.UseNpgsql(builder.GetConnectionString("DefaultConnection")));

            //services.AddScoped<IResultsRepository, AdminsRepository>();
            services.AddScoped<IFilesRepository, FilesRepository>();
            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<CsvDbContext>());

            return services;
        }
    }
}
