using Api.Storage;

namespace Api.Extensions
{
    public static class ApplicationServiceCollectionExtension
    {
        public static IServiceCollection AddServiceCollection(
            this IServiceCollection services, 
            ConfigurationManager configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers();
            var stringConnection = configuration.GetConnectionString("DefaultConnection");
            services.AddSingleton<IStorage>();

            services.AddCors(opt =>
            opt.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins(configuration["client"]);
            })
            );
            return services;
        }
    }
}
