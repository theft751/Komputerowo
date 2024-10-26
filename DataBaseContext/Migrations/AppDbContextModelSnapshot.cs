﻿// <auto-generated />
using System;
using DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataBaseContext.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Model.DataModel.Main.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApartmentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberOfBuilding")
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

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<int>("GuarantyTime")
                        .HasColumnType("int");

                    b.Property<int>("MainImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProducerId")
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

            modelBuilder.Entity("Model.DataModel.Main.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
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

                    b.ToTable("Reviews");
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

                    b.Property<string>("PowerSupplyFormat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Case");
                });

            modelBuilder.Entity("Model.DataModel.Products.ComputerParts.DiskDrive", b =>
                {
                    b.HasBaseType("Model.DataModel.Main.Product");

                    b.Property<string>("DiskDriveInterface")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("Model.DataModel.Products.ComputerParts.MotherBoard", b =>
                {
                    b.HasBaseType("Model.DataModel.Main.Product");

                    b.Property<string>("Chipset")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExternalSockets")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternalSockets")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcesorArchitecture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessorSocket")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RamSlots")
                        .HasColumnType("int");

                    b.Property<string>("SupportedMemoryTypes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupportedMemoryTypesOC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupportedProcessorFamilies")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("MotherBoard");
                });

            modelBuilder.Entity("Model.DataModel.Products.ComputerParts.PowerSupply", b =>
                {
                    b.HasBaseType("Model.DataModel.Main.Product");

                    b.Property<string>("Certyficate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Connectors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Efficiency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaximalPower")
                        .HasColumnType("int");

                    b.Property<string>("PowerSupplyFormat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PowerSupplyProtectorsFeatures")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("ProcessorSerie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessorSocket")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Threads")
                        .HasColumnType("int");

                    b.Property<bool>("hasCoolerIncluded")
                        .HasColumnType("bit");

                    b.ToTable("Products", t =>
                        {
                            t.Property("ProcessorSocket")
                                .HasColumnName("ProcessorSocket1");
                        });

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

                    b.Property<string>("RamType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SizePerChips")
                        .HasColumnType("int");

                    b.ToTable("Products", t =>
                        {
                            t.Property("Frequency")
                                .HasColumnName("Ram_Frequency");
                        });

                    b.HasDiscriminator().HasValue("Ram");
                });

            modelBuilder.Entity("Model.DataModel.Products.OtherDevices.DesktopComputer", b =>
                {
                    b.HasBaseType("Model.DataModel.Main.Product");

                    b.Property<string>("Chipset")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiskSize")
                        .HasColumnType("int");

                    b.Property<string>("DiskType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExternalPorts")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gpu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GpuMemorySize")
                        .HasColumnType("int");

                    b.Property<string>("GpuMemoryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternalPorts")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperatingSystem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PowerSupply")
                        .HasColumnType("int");

                    b.Property<string>("Processor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RamSize")
                        .HasColumnType("int");

                    b.Property<string>("RamType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Products", t =>
                        {
                            t.Property("Chipset")
                                .HasColumnName("DesktopComputer_Chipset");

                            t.Property("DiskSize")
                                .HasColumnName("DesktopComputer_DiskSize");

                            t.Property("RamType")
                                .HasColumnName("DesktopComputer_RamType");
                        });

                    b.HasDiscriminator().HasValue("DesktopComputer");
                });

            modelBuilder.Entity("Model.DataModel.Products.OtherDevices.Laptop", b =>
                {
                    b.HasBaseType("Model.DataModel.Main.Product");

                    b.Property<string>("BatteryCapacity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiskSize")
                        .HasColumnType("int");

                    b.Property<string>("DiskType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExternalPorts")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gpu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperatingSystem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Processor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RamSize")
                        .HasColumnType("int");

                    b.Property<string>("RamType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resolution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ScreenDiagonal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ScreenType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Products", t =>
                        {
                            t.Property("DiskSize")
                                .HasColumnName("Laptop_DiskSize");

                            t.Property("DiskType")
                                .HasColumnName("Laptop_DiskType");

                            t.Property("ExternalPorts")
                                .HasColumnName("Laptop_ExternalPorts");

                            t.Property("Gpu")
                                .HasColumnName("Laptop_Gpu");

                            t.Property("OperatingSystem")
                                .HasColumnName("Laptop_OperatingSystem");

                            t.Property("Processor")
                                .HasColumnName("Laptop_Processor");

                            t.Property("RamSize")
                                .HasColumnName("Laptop_RamSize");

                            t.Property("RamType")
                                .HasColumnName("Laptop_RamType");
                        });

                    b.HasDiscriminator().HasValue("Laptop");
                });

            modelBuilder.Entity("Model.DataModel.Products.OtherDevices.Smartphone", b =>
                {
                    b.HasBaseType("Model.DataModel.Main.Product");

                    b.Property<string>("BackCamera")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BatteryCapacity")
                        .HasColumnType("int");

                    b.Property<int>("EmbeddedMemorySize")
                        .HasColumnType("int");

                    b.Property<string>("ExternalPorts")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FingPrinterReader")
                        .HasColumnType("bit");

                    b.Property<string>("FrontCamera")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Nfc")
                        .HasColumnType("bit");

                    b.Property<string>("OperatingSystem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Processor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RamSize")
                        .HasColumnType("int");

                    b.Property<string>("Resolution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ScreenDiagonal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ScreenRefreshRate")
                        .HasColumnType("int");

                    b.ToTable("Products", t =>
                        {
                            t.Property("BatteryCapacity")
                                .HasColumnName("Smartphone_BatteryCapacity");

                            t.Property("ExternalPorts")
                                .HasColumnName("Smartphone_ExternalPorts");

                            t.Property("OperatingSystem")
                                .HasColumnName("Smartphone_OperatingSystem");

                            t.Property("Processor")
                                .HasColumnName("Smartphone_Processor");

                            t.Property("RamSize")
                                .HasColumnName("Smartphone_RamSize");

                            t.Property("Resolution")
                                .HasColumnName("Smartphone_Resolution");

                            t.Property("ScreenDiagonal")
                                .HasColumnName("Smartphone_ScreenDiagonal");
                        });

                    b.HasDiscriminator().HasValue("Smartphone");
                });

            modelBuilder.Entity("Model.DataModel.Products.OtherDevices.Televisor", b =>
                {
                    b.HasBaseType("Model.DataModel.Main.Product");

                    b.Property<string>("ExternalPorts")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperatingSystem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resolution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ScreenDiagonal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ScreenRefreshRate")
                        .HasColumnType("int");

                    b.Property<bool>("hasSmartTv")
                        .HasColumnType("bit");

                    b.ToTable("Products", t =>
                        {
                            t.Property("ExternalPorts")
                                .HasColumnName("Televisor_ExternalPorts");

                            t.Property("OperatingSystem")
                                .HasColumnName("Televisor_OperatingSystem");

                            t.Property("Resolution")
                                .HasColumnName("Televisor_Resolution");

                            t.Property("ScreenDiagonal")
                                .HasColumnName("Televisor_ScreenDiagonal");

                            t.Property("ScreenRefreshRate")
                                .HasColumnName("Televisor_ScreenRefreshRate");
                        });

                    b.HasDiscriminator().HasValue("Televisor");
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

                    b.HasOne("Model.DataModel.Main.Producer", null)
                        .WithMany("Products")
                        .HasForeignKey("ProducerId");

                    b.Navigation("MainImage");
                });

            modelBuilder.Entity("Model.DataModel.Main.Review", b =>
                {
                    b.HasOne("Model.DataModel.Main.Product", "Product")
                        .WithMany("Reviews")
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

                    b.Navigation("OrderItems");

                    b.Navigation("Reviews");
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
