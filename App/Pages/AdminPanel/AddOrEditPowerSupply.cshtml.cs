using DataBaseContext;
using Domain.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.SqlServer.Server;
using Domain.EntityModels.Main;
using Domain.EntityModels.Products.ComputerParts;
using System.Reflection;
using System.Runtime.InteropServices;

namespace App.Pages.AdminPanel
{
    public class AddOrEditPowerSupplyModel : AddOrEditProductModel
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

            PowerSupply product = OperationMode == OperationMode.Add ? new PowerSupply() : context.PowerSupplies.Find(Id);

            //set properties inherited from product 
            setProductEssentialProperties(product); ;

            //power supply properties
            product.MaximalPower = MaximalPower;
            product.Certyficate = Certyficate;
            product.PowerSupplyFormat = PowerSupplyFormat;
            product.Efficiency = Efficiency;
            product.Connectors = Connectors;
            product.PowerSupplyProtectorsFeatures = PowerSupplyProtectorsFeatures;


            if (OperationMode == OperationMode.Add)context.PowerSupplies.Add(product);
            context.SaveChanges();
            return Page();
        }

        public override IActionResult OnGetEdit(int id)
        {
            PowerSupply product = context.PowerSupplies.Find(id);

            //power supply properties
            MaximalPower = product.MaximalPower;
            Certyficate = product.Certyficate;
            PowerSupplyFormat = product.PowerSupplyFormat;
            Efficiency = product.Efficiency;
            Connectors = product.Connectors;
            PowerSupplyProtectorsFeatures = product.PowerSupplyProtectorsFeatures;

            setProductEssentialPropertiesOnEdit(id);
            return Page();
        }
        public AddOrEditPowerSupplyModel(AppDbContext _context)
            : base(_context) { }
    }
}
