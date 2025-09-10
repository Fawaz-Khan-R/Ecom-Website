using System;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

namespace dotnetapp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductRequest> ProductRequests { get; set; }
        // Add other DbSets as needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User configurations
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.PasswordHash).IsRequired();
            });

            // Product configurations
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.HasOne(e => e.Seller)
                      .WithMany(u => u.Products)
                      .HasForeignKey(e => e.SellerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Order configurations
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId);
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
                entity.HasOne(e => e.Buyer)
                      .WithMany(u => u.Orders)
                      .HasForeignKey(e => e.BuyerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // OrderItem configurations
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.OrderItemId);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.HasOne(e => e.Order)
                      .WithMany(o => o.OrderItems)
                      .HasForeignKey(e => e.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Product)
                      .WithMany(p => p.OrderItems)
                      .HasForeignKey(e => e.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ProductRequest configurations
            modelBuilder.Entity<ProductRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId);
                entity.HasOne(e => e.Product)
                      .WithMany(p => p.ProductRequests)
                      .HasForeignKey(e => e.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Seller)
                      .WithMany(u => u.ProductRequests)
                      .HasForeignKey(e => e.SellerId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}