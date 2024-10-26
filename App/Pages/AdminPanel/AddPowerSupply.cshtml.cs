using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DataModel.Main;
using Model.DataModel.Products.ComputerParts;

namespace App.Pages.AdminPanel
{
    public class AddPowerSupplyModel : AddProductModel
    {
        [BindProperty]
        public int MaximalPower { get; set; } // In Watts

        [BindProperty]
        public string Certyficate { get; set; }

        [BindProperty]
        public string PowerSupplyFormat { get; set; }

        [BindProperty]
        public string Efficiency { get; set; }

        [BindProperty]
        public string Connectors { get; set; }

        [BindProperty]
        public string PowerSupplyProtectorsFeatures { get; set; }

        public override IActionResult OnPost()
        {

            PowerSupply product = new PowerSupply();

            //set properties inherited from product 
            setProductEssentialProperties(product); ;

            //power supply properties
            product.MaximalPower = MaximalPower;
            product.Certyficate = Certyficate;
            product.PowerSupplyFormat = PowerSupplyFormat;
            product.Efficiency = Efficiency;
            product.Connectors = Connectors;
            product.PowerSupplyProtectorsFeatures = PowerSupplyProtectorsFeatures;


            context.PowerSupplies.Add(product);
            context.SaveChanges();
            return Page();
        }
        public AddPowerSupplyModel(AppDbContext _context)
            : base(_context) { }
    }
}
