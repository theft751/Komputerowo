using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Domain.EntityModels.Additional.Common;
using Domain.EntityModels.Additional.ComputerParts;
using Domain.EntityModels.Main;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;



namespace DataBaseContext
{
    public class AppDbContext : DbContext
    {


        //*************
        // Essenstials
        //*************
        public DbSet<UserAdress> Adresses { get; set; }
        public DbSet<OrderAdress> OrderAdresses { get; set; }
        public DbSet<BonusProductImage> BonusProductImages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<MainProductImage> MainProductImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BankAcountNumber> BankAcountNumber { get; set;}
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
        public DbSet<MonitorScreen> Monitors { get; set; }
        public DbSet<Mouse> Mouses { get; set; }
        public DbSet<Keyboard> Keyboards { get; set; }
        public DbSet<Printer> Printers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
:        base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /******************************
             Essential entities configuration
            *****************************/

            modelBuilder.Entity<User>()
                .HasOne(u => u.Adress)
                .WithOne(a => a.User)
                .HasForeignKey<User>(u => u.AdressId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Adress)
                .WithOne(a => a.Order)
                .HasForeignKey<Order>(o => o.AdressId)
                .OnDelete(DeleteBehavior.Cascade);

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
                .OnDelete(DeleteBehavior.Cascade);

            //ProductType Dyscryminator to string Conversion
            modelBuilder.Entity<Product>()
                .Property(p => p.ProductType)
                .HasConversion<string>();

            modelBuilder.Entity<Case>()
            .Property(p => p.CaseType)
            .HasConversion<string>();

            //Setting Discriminator values
            modelBuilder.Entity<Product>()
                .ToTable("Products")
                .HasDiscriminator<ProductType>("ProductType")
                .HasValue<DiskDrive>(ProductType.DiskDrive)
                .HasValue<GraphicCard>(ProductType.GraphicCard)
                .HasValue<Ram>(ProductType.Ram)
                .HasValue<Case>(ProductType.Case)
                .HasValue<PowerSupply>(ProductType.PowerSupply)
                .HasValue<Processor>(ProductType.Processor)
                .HasValue<MotherBoard>(ProductType.Motherboard)
                .HasValue<DesktopComputer>(ProductType.DesktopComputer)
                .HasValue<Laptop>(ProductType.Laptop)
                .HasValue<Smartphone>(ProductType.Smartphone)
                .HasValue<Televisor>(ProductType.Televisor)
                .HasValue<MonitorScreen>(ProductType.Monitor)
                .HasValue<Mouse>(ProductType.Mouse)
                .HasValue<Keyboard>(ProductType.Keyboard)
                .HasValue<Printer>(ProductType.Printer)
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


            /****************************************
            Model managed data
            *****************************************/

            //Admin account login: admin, password: admin
            using (SHA256 sha256 = SHA256.Create())
            {

                //hashing password
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes("admin"));
                string hashedAdminPassword = Convert.ToBase64String(hashBytes);
                modelBuilder.Entity<User>()
                .HasData
                (
                    new User
                    {
                        Id = 1,
                        Email = "admin",
                        FirstName = "Admin",
                        LastName = "Admin",
                        PhoneNumber = "000000000",
                        Password = hashedAdminPassword,
                        UserType = UserType.Admin,
                        //Navigation properties
                        AdressId = null
                    }
                );

                //
            }
            //
        }
    }
}
