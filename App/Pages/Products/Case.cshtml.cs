using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.Identity.Client;
using Domain.EntityModels.Additional.ComputerParts;
using Domain.EntityModels.Main;
using Domain.EntityModels.Products.ComputerParts;

namespace App.Pages.Products
{
    public class CaseModel : ProductPageModel
    {

        public string MotherBoardFormats { get; set; }

        public string PowerSupplyFormat { get; set; }



        public CaseType CaseType { get; set; }

        protected override void initializeEssentialProductProperties(int productId)
        {
            //Initialize inherited properties from ProductModel
            base.initializeEssentialProductProperties (productId);
            
            Case Case = context.Cases.Find(productId);

            //Initialize properties specific for CaseModel
            MotherBoardFormats = Case.MotherBoardFormats;
            PowerSupplyFormat = Case.PowerSupplyFormat;
            CaseType = Case.CaseType;
            
        }



        public CaseModel(AppDbContext _context)
            : base(_context) { }
        
    }
}
