using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DataModel.Main;
using Model.DataModel.Products.OtherDevices;

namespace App.Pages.AdminPanel
{
    public class AddSmartphoneModel : AddProductModel
    {
        [BindProperty]
        public string BackCamera { get; set; }
        
        [BindProperty]
        public string FrontCamera { get; set; }
        
        [BindProperty]
        public string Resolution { get; set; }

        [BindProperty]
        public decimal ScreenDiagonal { get; set; } //inches

        [BindProperty]
        public int ScreenRefreshRate { get; set; } //Hz

        [BindProperty]
        public string Processor { get; set; }

        [BindProperty]
        public int RamSize { get; set; }

        [BindProperty]
        public int EmbeddedMemorySize { get; set; }

        [BindProperty]
        public string OperatingSystem { get; set; }

        [BindProperty]
        public string ExternalPorts { get; set; }

        [BindProperty]
        public int BatteryCapacity { get; set; }

        [BindProperty]
        public bool Nfc { get; set; }

        [BindProperty]
        public bool FingPrinterReader { get; set; }
        public override IActionResult OnPost()
        {
            Smartphone product = new Smartphone();

            //set properties inherited from product 
            setProductEssentialProperties(product); ;

            //Smartphone properties
            product.BackCamera = BackCamera;
            product.FrontCamera = FrontCamera;
            product.Resolution = Resolution;
            product.ScreenDiagonal = ScreenDiagonal;
            product.ScreenRefreshRate = ScreenRefreshRate;
            product.Processor = Processor;
            product.RamSize = RamSize;
            product.EmbeddedMemorySize = EmbeddedMemorySize;
            product.OperatingSystem = OperatingSystem; 
            product.ExternalPorts = ExternalPorts;
            product.BatteryCapacity = BatteryCapacity;
            product.Nfc = Nfc;
            product.FingPrinterReader = FingPrinterReader;


            context.Smartphones.Add(product);
            context.SaveChanges();
            return Page();
        }
        public AddSmartphoneModel(AppDbContext _context)
            :base(_context){}
    }
}
