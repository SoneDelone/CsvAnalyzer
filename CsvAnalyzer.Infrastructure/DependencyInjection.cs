using CsvAnalyzer.Application.Common.Interfaces;
using CsvAnalyzer.Infrastructure.Common.Persistence;
using CsvAnalyzer.Infrastructure.Files;
using CsvAnalyzer.Infrastructure.Results.Persistence;
using CsvAnalyzer.Infrastructure.Values.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CsvAnalyzer.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration builder)
        {
            return services
                .AddPersistence(builder)
                .AddLogic();

        }
        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            services.AddScoped<ICsvValidator, CsvValidator>();
            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration builder)
        {
            services.AddDbContext<CsvDbContext>(options =>
                options.UseNpgsql(builder.GetConnectionString("DefaultConnection")));

            services.AddScoped<IResultsRepository, ResultsRepository>();
            services.AddScoped<IFilesRepository, FilesRepository>();
            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<CsvDbContext>());

            return services;
        }
    }
}
