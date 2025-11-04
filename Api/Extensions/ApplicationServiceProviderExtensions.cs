using Api.Seed;
using Api.Storage;

namespace Api.Extensions
{
    public static class ApplicationServiceProviderExtensions
    {
        public static IServiceProvider AddCustomService(
            this IServiceProvider services,
            IConfiguration configuration
        )
        {
            using var scope = services.CreateScope();

            var storage = scope.ServiceProvider.GetService<IStorage>();
            var dbStorage = storage as ApplicationEfStorage;
            if (dbStorage != null)
            {
                string connectionString = configuration
                    .GetConnectionString("DefaultConnection");

                new FakerInitializer(connectionString).Initialize();
            }

            return services;
        }
    }
}
