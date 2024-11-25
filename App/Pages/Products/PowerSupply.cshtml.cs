using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;

namespace App.Pages.Products
{
    public class PowerSupplyModel : ProductPageModel
    {
        public int MaximalPower { get; set; } // In Watts
        public string Certyficate { get; set; }
        public string PowerSupplyFormat { get; set; }
        public string Efficiency { get; set; }
        public string Connectors { get; set; }
        public string PowerSupplyProtectorsFeatures { get; set; }
        PowerSupplyModel(AppDbContext _context)
            : base(_context)
        {
        }
    }
}
