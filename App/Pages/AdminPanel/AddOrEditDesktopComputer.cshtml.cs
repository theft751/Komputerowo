using DataBaseContext;
using Domain.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Model.EntityModels.Main;
using Model.EntityModels.Products.OtherDevices;

namespace App.Pages.AdminPanel
{
    public class AddOrEditDesktopComputerModel : AddOrEditProductModel
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
            DesktopComputer product = OperationMode == OperationMode.Add ? new DesktopComputer() : context.DesktopComputers.Find(Id);
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


            if (OperationMode == OperationMode.Add) context.Products.Add(product);
            context.SaveChanges();
            return Page();
        }

        public AddOrEditDesktopComputerModel(AppDbContext _context)
            : base(_context) { }
    }
}
