using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Model.DataModel.Main;
using Model.DataModel.Products.OtherDevices;

namespace App.Pages.AdminPanel
{
    public class AddDesktopComputerModel : AddProductModel
    {
        [BindProperty]
        public string Processor { get; set; }

        [BindProperty]
        public string Chipset { get; set; }

        [BindProperty]
        public string Gpu { get; set; }

        [BindProperty]
        public string GpuMemoryType { get; set; }

        [BindProperty]
        public int GpuMemorySize { get; set; }

        [BindProperty]
        public string RamType { get; set; }

        [BindProperty]
        public int RamSize { get; set; }

        [BindProperty]
        public string DiskType { get; set; }

        [BindProperty]
        public int DiskSize { get; set; }

        [BindProperty]
        public string ExternalPorts { get; set; }

        [BindProperty] 
        public string InternalPorts { get; set; }

        [BindProperty]
        public int PowerSupply { get; set; } //In watts

        [BindProperty]
        public string OperatingSystem { get; set; }

        public override IActionResult OnPost()
        {
            DesktopComputer product = new DesktopComputer();

            //set properties inherited from product 
            setProductEssentialProperties(product); ;

            //DesktopComputer properties
            product.Processor = Processor;
            product.Chipset = Chipset;
            product.Gpu = Gpu;
            product.GpuMemoryType = GpuMemoryType;
            product.GpuMemorySize = GpuMemorySize;
            product.RamType = RamType;
            product.RamSize = RamSize;
            product.DiskSize = DiskSize;    
            product.ExternalPorts = ExternalPorts;
            product.InternalPorts = InternalPorts;
            product.PowerSupply = PowerSupply;
            product.OperatingSystem = OperatingSystem;


            context.Products.Add(product);
            context.SaveChanges();
            return Page();
        }

        public AddDesktopComputerModel (AppDbContext _context)
            : base(_context) { }
    }
}
