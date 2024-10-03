﻿// <auto-generated />
using System;
using DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataBaseContext.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241002135639_init1")]
    partial class init1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Model.DataModel.Main.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Voivodeship")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("Model.DataModel.Main.BonusProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("BonusProductImages");
                });

            modelBuilder.Entity("Model.DataModel.Main.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Model.DataModel.Main.MainProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MainProductImages");
                });

            modelBuilder.Entity("Model.DataModel.Main.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdressId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdressId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Model.DataModel.Main.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Model.DataModel.Main.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("Model.DataModel.Main.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("Availability")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("GuarantyTime")
                        .HasColumnType("int");

                    b.Property<int>("MainImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProducerId")
                        .HasColumnType("int");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MainImageId")
                        .IsUnique();

                    b.HasIndex("ProducerId");

                    b.ToTable("Products");

                    b.HasDiscriminator().HasValue("Product");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Model.DataModel.Main.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdressId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdressId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Model.DataModel.Products.ComputerParts.Case", b =>
                {
                    b.HasBaseType("Model.DataModel.Main.Product");

                    b.Property<int>("CaseType")
                        .HasColumnType("int");

                    b.Property<string>("MotherBoardFormats")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PowerSupplyFormat")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Case");
                });

            modelBuilder.Entity("Model.DataModel.Products.ComputerParts.DiskDrive", b =>
                {
                    b.HasBaseType("Model.DataModel.Main.Product");

                    b.Property<int>("DiskDriveInterface")
                        .HasColumnType("int");

                    b.Property<int>("DiskDriveType")
                        .HasColumnType("int");

                    b.Property<int>("DiskSize")
                        .HasColumnType("int");

                    b.Property<int>("ReadSpeed")
                        .HasColumnType("int");

                    b.Property<int>("WriteSpeed")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("DiskDrive");
                });

            modelBuilder.Entity("Model.DataModel.Products.ComputerParts.PowerSupply", b =>
                {
                    b.HasBaseType("Model.DataModel.Main.Product");

                    b.Property<int>("PowerSupplyFormat")
                        .HasColumnType("int");

                    b.ToTable("Products", t =>
                        {
                            t.Property("PowerSupplyFormat")
                                .HasColumnName("PowerSupplyFormat1");
                        });

                    b.HasDiscriminator().HasValue("PowerSupply");
                });

            modelBuilder.Entity("Model.DataModel.Products.ComputerParts.Processor", b =>
                {
                    b.HasBaseType("Model.DataModel.Main.Product");

                    b.Property<int>("CacheSize")
                        .HasColumnType("int");

                    b.Property<int>("Cores")
                        .HasColumnType("int");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<bool>("IntegratedGpu")
                        .HasColumnType("bit");

                    b.Property<int>("ProcessorSerie")
                        .HasColumnType("int");

                    b.Property<int>("ProcessorSocket")
                        .HasColumnType("int");

                    b.Property<int>("Threads")
                        .HasColumnType("int");

                    b.Property<bool>("hasCoolerIncluded")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Processor");
                });

            modelBuilder.Entity("Model.DataModel.Products.ComputerParts.Ram", b =>
                {
                    b.HasBaseType("Model.DataModel.Main.Product");

                    b.Property<int>("ChipsAmount")
                        .HasColumnType("int");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<bool>("Ligthing")
                        .HasColumnType("bit");

                    b.Property<int>("RamType")
                        .HasColumnType("int");

                    b.Property<int>("SizePerChips")
                        .HasColumnType("int");

                    b.ToTable("Products", t =>
                        {
                            t.Property("Frequency")
                                .HasColumnName("Ram_Frequency");
                        });

                    b.HasDiscriminator().HasValue("Ram");
                });

            modelBuilder.Entity("Model.DataModel.Main.BonusProductImage", b =>
                {
                    b.HasOne("Model.DataModel.Main.Product", "Product")
                        .WithMany("BonusImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Model.DataModel.Main.Comment", b =>
                {
                    b.HasOne("Model.DataModel.Main.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.DataModel.Main.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.DataModel.Main.Order", b =>
                {
                    b.HasOne("Model.DataModel.Main.Adress", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.DataModel.Main.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("Model.DataModel.Main.OrderItem", b =>
                {
                    b.HasOne("Model.DataModel.Main.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.DataModel.Main.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Model.DataModel.Main.Product", b =>
                {
                    b.HasOne("Model.DataModel.Main.MainProductImage", "MainImage")
                        .WithOne("Product")
                        .HasForeignKey("Model.DataModel.Main.Product", "MainImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.DataModel.Main.Producer", "Producer")
                        .WithMany("Products")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainImage");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("Model.DataModel.Main.User", b =>
                {
                    b.HasOne("Model.DataModel.Main.Adress", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("Model.DataModel.Main.MainProductImage", b =>
                {
                    b.Navigation("Product")
                        .IsRequired();
                });

            modelBuilder.Entity("Model.DataModel.Main.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Model.DataModel.Main.Producer", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Model.DataModel.Main.Product", b =>
                {
                    b.Navigation("BonusImages");

                    b.Navigation("Comments");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Model.DataModel.Main.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
