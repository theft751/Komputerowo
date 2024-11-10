﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.EntityModels.Additional.Common;
using Model.EntityModels.Additional.ComputerParts;
using Model.EntityModels.Main;
using Model.EntityModels.Products.ComputerParts;
using Model.EntityModels.Products.OtherDevices;
using System.Reflection.Emit;



namespace DataBaseContext
{
    public class AppDbContext : DbContext
    {
        //*************
        // Essenstials
        //*************
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<BonusProductImage> BonusProductImages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<MainProductImage> MainProductImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        //*************
        //  Products
        //*************
        
        //Computer Parts
        public DbSet<DiskDrive> DiskDrives { get; set; }
        public DbSet<GraphicCard> GraphicCards { get; set; }
        public DbSet<Ram> Rams { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<PowerSupply> PowerSupplies { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<MotherBoard> MotherBoards { get; set; }

        //Other devices
        public DbSet<DesktopComputer> DesktopComputers { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Smartphone> Smartphones { get; set; }
        public DbSet<Televisor> Televisors { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
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

            //Setting Discriminator values
            modelBuilder.Entity<Product>()
                .ToTable("Products")
                .HasDiscriminator<ProductType>("ProductType")
                .HasValue<DiskDrive>(ProductType.DISK_DRIVE)
                .HasValue<Ram>(ProductType.RAM)
                .HasValue<Case>(ProductType.CASE)
                .HasValue<PowerSupply>(ProductType.POWER_SUPPLY)
                .HasValue<Processor>(ProductType.PROCESSOR)
                .HasValue<MotherBoard>(ProductType.MOTHERBOARD)
                .HasValue<DesktopComputer>(ProductType.DESKTOP_COMPUTER)
                .HasValue<Laptop>(ProductType.LAPTOP)
                .HasValue<Smartphone>(ProductType.SMARTPHONE)
                .HasValue<Televisor>(ProductType.TELEVISOR)
                ;

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