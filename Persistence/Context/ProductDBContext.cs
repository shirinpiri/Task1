using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Context
{
    public class ProductDBContext: DbContext
    {

        public ProductDBContext(DbContextOptions<ProductDBContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product => Set<Product>();
        public DbSet<Category> Category => Set<Category>();
        public DbSet<SubCategory> SubCategory => Set<SubCategory>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }


    }
}
