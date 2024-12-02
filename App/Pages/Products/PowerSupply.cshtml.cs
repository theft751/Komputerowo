using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;
using Microsoft.SqlServer.Server;
using System.Reflection;
using System.Runtime.InteropServices;

namespace App.Pages.Products
{
    public class PowerSupplyModel : ProductTemplatePageModel
    {
        public int MaximalPower { get; set; } // In Watts
        public string Certyficate { get; set; }
        public string PowerSupplyFormat { get; set; }
        public string Efficiency { get; set; }
        public string Connectors { get; set; }
        public string PowerSupplyProtectorsFeatures { get; set; }
        public PowerSupplyModel(AppDbContext _context)
            : base(_context)
        {
        }
        protected override void initializeEssentialProductProperties(int productId)
        {
            //Initialize inherited properties from ProductModel
            base.initializeEssentialProductProperties(productId);

            PowerSupply powerSupply = context.PowerSupplies.Find(productId);

            //Initialize properties specific for DesktopComputer
            MaximalPower = powerSupply.MaximalPower;
            Certyficate = powerSupply.Certyficate;
            PowerSupplyFormat = powerSupply.PowerSupplyFormat;
            Efficiency = powerSupply.Efficiency;
            Connectors = powerSupply.Connectors;
            PowerSupplyProtectorsFeatures = powerSupply.PowerSupplyProtectorsFeatures;
    }
    }
}
