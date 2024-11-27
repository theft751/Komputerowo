using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;

namespace App.Pages.Products
{
    public class LaptopModel : ProductTemplatePageModel
    {
        public string Processor { get; set; }
        public int RamSize { get; set; }
        public string RamType { get; set; }
        public int DiskSize { get; set; }
        public string DiskType { get; set; }
        public string Gpu { get; set; }
        public string BatteryCapacity { get; set; }
        public string ExternalPorts { get; set; }
        public string Resolution { get; set; }
        public decimal ScreenDiagonal { get; set; } //inches
        public string ScreenType { get; set; }
        public string OperatingSystem { get; set; }

        protected override void initializeEssentialProductProperties(int productId)
        {
            //Initialize inherited properties from ProductModel
            base.initializeEssentialProductProperties(productId);

            Laptop laptop = context.Laptops.Find(productId);

            //Initialize properties specific for DesktopComputer
            Processor = laptop.Processor;
            RamSize = laptop.RamSize;
            RamType = laptop.RamType;
            DiskSize = laptop.DiskSize;
            DiskType = laptop.DiskType;
            Gpu = laptop.Gpu;
            BatteryCapacity = laptop.BatteryCapacity;
            ExternalPorts = laptop.ExternalPorts;
            Resolution = laptop.Resolution;
            ScreenDiagonal = laptop.ScreenDiagonal;
            ScreenType = laptop.ScreenType;
            OperatingSystem = laptop.OperatingSystem;
        }
        public LaptopModel(AppDbContext _context)
            : base(_context)
        {
        }
    }
}
