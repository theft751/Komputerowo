using DataBaseContext;
using Domain.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.EntityModels.Additional.ComputerParts;
using Domain.EntityModels.Main;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;

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

            return AdminPage();
        }

        public override IActionResult OnGetEdit(int id)
        {
            Case product = context.Cases.Find(id);
            MotherBoardFormats = product.MotherBoardFormats;
            PowerSupplyFormat = product.PowerSupplyFormat;
            CaseType = product.CaseType;
            setProductEssentialPropertiesOnEdit(id);
            
            return AdminPage();
        }
        public AddOrEditCaseModel(AppDbContext _context)
            :base(_context){}
    }
}
