using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.Identity.Client;
using Model.DataModel.Additional.ComputerParts;
using Model.DataModel.Main;
using Model.DataModel.Products.ComputerParts;

namespace App.Pages.Products
{
    public class CaseModel : ProductModel
    {

        public string MotherBoardFormats { get; set; }

        public string PowerSupplyFormat { get; set; }



        public CaseType CaseType { get; set; }

        protected override void initializeEssentialProductProperties(int productId)
        {
            //Initialize inherited properties from ProductModel
            base.initializeEssentialProductProperties (productId);
            
            Case Case = context.Cases.Where(x => x.Id == productId).First();

            //Initialize properties specific for CaseModel
            MotherBoardFormats = Case.MotherBoardFormats;
            PowerSupplyFormat = Case.PowerSupplyFormat;
            CaseType = Case.CaseType;
            
        }

        public override IActionResult OnGet(int productId=1, int pageNumber=1)
        {
            try
             {
                PageNumber = pageNumber;

                //Initialize inherited properties from ProductModel
                initializeEssentialProductProperties(productId);
                return Page();
            }
            catch
            {
                return new RedirectToPageResult("/Error");
            }
        }
        public CaseModel(AppDbContext _context)
            : base(_context) { }
        
    }
}
