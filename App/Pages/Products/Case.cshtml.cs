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
    public class CaseModel : ProductTemplatePageModel
    {

        public string MotherBoardFormats { get; set; }

        public string PowerSupplyFormat { get; set; }
        public string RequestPath { get; set; }


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

        public override IActionResult OnGet([FromRoute] int productId = 1, [FromRoute] int pageNumber = 1)
        {
            return base.OnGet(productId, pageNumber);
        }


        public CaseModel(AppDbContext _context)
            : base(_context) { }
        
    }
}
