using Api.DataContext;
using Api.Seed;
using Api.Storage;
using Microsoft.EntityFrameworkCore;

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
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(stringConnection));
            services.AddScoped<IStorage, ApplicationEfStorage>();
            services.AddScoped<IInitializer, FakerInitializer>();

            services.AddCors(opt =>
            opt.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins(configuration["client"]);
            }));
            return services;
        }
    }
}
