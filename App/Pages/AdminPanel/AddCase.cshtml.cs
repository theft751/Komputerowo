using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DataModel.Additional.ComputerParts;
using Model.DataModel.Main;
using Model.DataModel.Products.ComputerParts;

namespace App.Pages.AdminPanel
{
    public class AddCaseModel : AddProductModel
    {
        [BindProperty]
        public string MotherBoardFormats { get; set; } = "";

        [BindProperty]
        public string PowerSupplyFormat { get; set; } = "";

        [BindProperty]
        public CaseType CaseType { get; set; }

        public override IActionResult OnPost()
        {
            Case product = new Case();

            //set properties inherited from product 
            setProductEssentialProperties(product);

            //Case properties
            product.MotherBoardFormats = MotherBoardFormats;
            product.PowerSupplyFormat = PowerSupplyFormat;
            product.CaseType = CaseType;

            context.Cases.Add(product);
            context.SaveChanges();

            return Page();
        }
        public AddCaseModel(AppDbContext _context)
            :base(_context){}
    }
}
