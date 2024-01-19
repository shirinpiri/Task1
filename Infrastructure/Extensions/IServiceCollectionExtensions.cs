using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Services;

namespace Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<IFileService, FileService>();
        }
    }
}
