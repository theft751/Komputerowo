using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DataModel.Main;
using Model.DataModel.Products.OtherDevices;
using System.Drawing;

namespace App.Pages.AdminPanel
{
    public class AddLaptopModel : AddProductModel
    {
        [BindProperty]
        public string Processor { get; set; }

        [BindProperty]
        public int RamSize { get; set; }

        [BindProperty]
        public string RamType { get; set; }

        [BindProperty]
        public int DiskSize { get; set; }

        [BindProperty]
        public string DiskType { get; set; }

        [BindProperty]
        public string Gpu { get; set; }

        [BindProperty]
        public string BatteryCapacity { get; set; }

        [BindProperty]
        public string ExternalPorts { get; set; }

        [BindProperty]
        public string Resolution { get; set; }

        [BindProperty]
        public decimal ScreenDiagonal { get; set; } //inches

        [BindProperty]
        public string ScreenType { get; set; }

        [BindProperty]
        public string OperatingSystem { get; set; }
        
        public override IActionResult OnPost()
        {
            Laptop product = new Laptop();

            //set properties inherited from product 
            setProductEssentialProperties(product); ;

            //laptop properties
            product.Processor = Processor;
            product.RamSize = RamSize;
            product.RamType = RamType;
            product.DiskSize = DiskSize;
            product.DiskType = DiskType;
            product.Gpu = Gpu;
            product.BatteryCapacity = BatteryCapacity;
            product.ExternalPorts = ExternalPorts;
            product.Resolution = Resolution;
            product.ScreenDiagonal = ScreenDiagonal;
            product.ScreenType = ScreenType;
            product.OperatingSystem = OperatingSystem;

            context.Products.Add(product);
            context.SaveChanges();
            return Page();
        }
        public AddLaptopModel(AppDbContext _context) 
            :base(_context){ }
    }
}
