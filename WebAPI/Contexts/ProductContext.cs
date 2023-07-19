using Microsoft.EntityFrameworkCore;
using System;
using WebAPI.Data;

namespace WebAPI.Contexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]{
            new(){ Id=1,Name="Category 1"},
            new(){ Id=2,Name="Category 2"}});
            modelBuilder.Entity<Product>().Property(x=> x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().HasData(new Product[] { new() { Id=1,Name="Product 1", ImageUrl="Product 1", Price=100,CreatedDate= DateTime.Now.AddDays(-2),CategoryId=1},
            new() {Id=2, Name="Product 2", ImageUrl="Product 2", Price=200,CreatedDate= DateTime.Now.AddDays(-4),CategoryId=1},
            new() { Id=3,Name="Product 3", ImageUrl="Product 3", Price=250,CreatedDate= DateTime.Now.AddDays(-3),CategoryId=1},
            new() { Id=4,Name="Product 4", ImageUrl="Product 4", Price=120,CreatedDate= DateTime.Now.AddDays(-1),CategoryId=2}});
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
