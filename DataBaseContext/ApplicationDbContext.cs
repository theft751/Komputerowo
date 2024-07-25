﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.DataModel.Main;
using System.Reflection.Emit;



namespace DataBaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<BonusProductImage> BonusProductImages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MainProductImage> MainProductImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /******************************
             Product entity configuration
            *****************************/

            //Main Image Reltation configuration
            modelBuilder
                .Entity<Product>()
                .HasOne(p => p.MainImage)
                .WithOne(p => p.Product)
                .HasForeignKey<Product>(p=>p.MainImageId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

            //Bonus Images Relation configuration
            modelBuilder
                .Entity<Product>()
                .HasMany(p=>p.BonusImages)
                .WithOne(p=>p.Product)
                .HasForeignKey(p=>p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            //ProductType Dyscryminator to string Conversion
            modelBuilder.Entity<Product>()
                .Property(p => p.ProductType)
                .HasConversion<string>();

            /****************************************
            Order and OrderItem entity configuration
            *****************************************/
            modelBuilder
                .Entity<Order>()
                .HasMany(p=>p.Items)
                .WithOne(p=>p.Order)
                .HasForeignKey(p=>p.OrderId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
                

        }
    }
}