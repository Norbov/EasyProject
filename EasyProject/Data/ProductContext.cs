using Microsoft.EntityFrameworkCore;
using EasyProject.Models;
using static System.Net.WebRequestMethods;

namespace EasyProject.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductProperties>().HasKey(pi => new
            {
                pi.ProductId,
                pi.PropertiesId
            });

            //Foreign keys
            modelBuilder.Entity<ProductProperties>().HasOne(p => p.Product).WithMany(pi => pi.ProductProperties).HasForeignKey(pi => pi.ProductId);
            modelBuilder.Entity<ProductProperties>().HasOne(p => p.Properties).WithMany(pi => pi.ProductProperties).HasForeignKey(pi => pi.PropertiesId);

            //Adding some data
            modelBuilder.Entity<Product>().HasData(new Product { 
                Id = 1, 
                Name = "Product1", 
                Price = 50.50, 
                ImageUrl = "https://www.tinyboxcompany.co.uk/media/catalog/product/F/M/FMKRCU_22.jpg?width=800&height=800&store=default&image-type=image" });
            modelBuilder.Entity<Properties>().HasData(
                new Properties
                {
                    Id = 1,
                    Name = "Contains a good product"
                },
                new Properties
                {
                    Id = 2,
                    Name = "Contains a small mistery gift"
                });
            modelBuilder.Entity<ProductProperties>().HasData(
                new ProductProperties
                {
                    ProductId = 1,
                    PropertiesId = 1,
                },
                new ProductProperties
                {
                    ProductId = 1,
                    PropertiesId = 2,
                }
            );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<ProductProperties> ProductProperties { get; set; }
    }
}
