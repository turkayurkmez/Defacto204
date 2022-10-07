using Microsoft.EntityFrameworkCore;
using sample.Models;

namespace sample.Data
{
    public class SampleDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product { Name = "Gözlük", Price = 150, Id = 1 });
            modelBuilder.Entity<Product>().HasData(new Product { Name = "Şapka", Price = 75, Id = 2 });


        }
    }
}
