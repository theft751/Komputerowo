using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.EntityModels.Additional.ComputerParts;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;

namespace App.Pages.Products
{
    public class DesktopComputerModel : ProductPageModel
    {
        public string Processor { get; set; }
        public string Chipset { get; set; }
        public string Gpu { get; set; }
        public string GpuMemoryType { get; set; }
        public int GpuMemorySize { get; set; }
        public string RamType { get; set; }
        public int RamSize { get; set; }
        public string DiskType { get; set; }
        public int DiskSize { get; set; }
        public string ExternalPorts { get; set; }
        public string InternalPorts { get; set; }
        public int PowerSupply { get; set; } //In watts
        public string OperatingSystem { get; set; }

        protected override void initializeEssentialProductProperties(int productId)
        {
            //Initialize inherited properties from ProductModel
            base.initializeEssentialProductProperties(productId);

            DesktopComputer desktopComuputer = context.DesktopComputers.Find(productId);

            //Initialize properties specific for DesktopComputer
            Processor = desktopComuputer.Processor;
            Chipset = desktopComuputer.Chipset;
            Gpu = desktopComuputer.Gpu;
            GpuMemoryType = desktopComuputer.GpuMemoryType;
            GpuMemorySize = desktopComuputer.GpuMemorySize;
            RamType = desktopComuputer.RamType;
            RamSize = desktopComuputer.RamSize;
            DiskType = desktopComuputer.RamType;
            DiskSize = desktopComuputer.DiskSize;
            ExternalPorts = desktopComuputer.ExternalPorts;
            InternalPorts = desktopComuputer.InternalPorts;
            PowerSupply = desktopComuputer.PowerSupply; //In watts
            OperatingSystem = desktopComuputer.OperatingSystem;
        }

        DesktopComputerModel(AppDbContext _context)
            : base(_context) { }
    }
}
