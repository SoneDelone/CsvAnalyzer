using CsvAnalyzer.Application;
using CsvAnalyzer.Infrastructure;
using System.Text.Json.Serialization;

namespace CsvAnalyzer.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDefaults(this IServiceCollection services,
                                                           IConfiguration configuration)
        {
            services
                .AddDefaults()
                .AddApplication()
                .AddInfrastructure(configuration);

            return services;
        }

        public static IServiceCollection AddDefaults(this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddProblemDetails();

            return services;
        }
    }
}
