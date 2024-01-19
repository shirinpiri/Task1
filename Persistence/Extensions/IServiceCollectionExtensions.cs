using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;
using System.Reflection;

namespace Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddProductDbContext(configuration);
            services.AddRepositories();
            services.AddMappings();
        }

        private static void AddMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }


        public static void AddProductDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var AppConnectionString = configuration.GetConnectionString("AppConnStr");

            services.AddDbContext<ProductDBContext>(options =>
               options.UseSqlServer(AppConnectionString,
                   builder => builder.MigrationsAssembly(typeof(ProductDBContext).Assembly.FullName)));

        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<ICategoryRepository, CategoryRepository>();
           }
    }
    }
