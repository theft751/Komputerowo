using DataBaseContext;
using Domain.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.EntityModels.Additional.ComputerParts;
using Model.EntityModels.Main;
using Model.EntityModels.Products.ComputerParts;
using Model.EntityModels.Products.OtherDevices;

namespace App.Pages.AdminPanel
{
    public class AddOrEditCaseModel : AddOrEditProductModel
    {
        [BindProperty]
        public string MotherBoardFormats { get; set; } = "";

        [BindProperty]
        public string PowerSupplyFormat { get; set; } = "";

        [BindProperty]
        public CaseType CaseType { get; set; }

        public override IActionResult OnPost()
        {
            Case product = OperationMode == OperationMode.Add ? new Case() : context.Cases.Find(Id);
            //set properties inherited from product 
            setProductEssentialProperties(product);

            //Case properties
            product.MotherBoardFormats = MotherBoardFormats;
            product.PowerSupplyFormat = PowerSupplyFormat;
            product.CaseType = CaseType;

            
            if (OperationMode == OperationMode.Add)context.Cases.Add(product);
            context.SaveChanges();

            return Page();
        }
        public AddOrEditCaseModel(AppDbContext _context)
            :base(_context){}
    }
}
