using Microsoft.EntityFrameworkCore;
using ProductManagement.Data.Entities;

namespace ProductManagement.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> option) : base(option)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>(entity =>
            {
                //entity.HasKey(e => e.ProductId)
                //    .HasName("PK_ProductId");

                entity.Property(e => e.ProductName).HasMaxLength(255);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");

            });

            modelBuilder.Entity<Category>(entity =>
            {
                //entity.HasKey(e => e.CategoryId)
                //    .HasName("PK_CategoryId");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

            });
        }
    }
}
