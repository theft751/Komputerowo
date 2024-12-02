using DataBaseContext;
using Domain.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.EntityModels.Main;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;

namespace App.Pages.AdminPanel
{
    public class AddOrEditTelevisorModel : AddOrEditProductModel
    {
        [BindProperty]
        public string Resolution { get; set; }

        [BindProperty]
        public decimal ScreenDiagonal { get; set; } //inches

        [BindProperty]
        public int ScreenRefreshRate { get; set; } //Hz

        [BindProperty]
        public string ExternalPorts { get; set; }

        [BindProperty]
        public bool hasSmartTv { get; set; }

        [BindProperty]
        public string OperatingSystem { get; set; }

        public AddOrEditTelevisorModel(AppDbContext _context)
            : base(_context) { }
        public override IActionResult OnPost()
        {
            Televisor product = OperationMode == OperationMode.Add ? new Televisor() : context.Televisors.Find(Id);


            //set properties inherited from product 
            setProductEssentialProperties(product); ;

            //Televisor properties
            product.Resolution = Resolution;
            product.ScreenDiagonal = ScreenDiagonal;
            product.ScreenRefreshRate = ScreenRefreshRate;
            product.ExternalPorts = ExternalPorts;
            product.HasSmartTv = hasSmartTv; 
            product.OperatingSystem = OperatingSystem;
            
            if(OperationMode == OperationMode.Add) context.Products.Add(product);
            
            context.SaveChanges();
            return Page();
        }

        public override IActionResult OnGetEdit(int id)
        {
            Televisor product = context.Televisors.Find(id);

            //Televisor properties
            Resolution = product.Resolution;
            ScreenDiagonal = product.ScreenDiagonal;
            ScreenRefreshRate = product.ScreenRefreshRate;
            ExternalPorts = product.ExternalPorts;
            hasSmartTv = product.HasSmartTv;
            OperatingSystem = product.OperatingSystem;

            setProductEssentialPropertiesOnEdit(id);
            return Page();
        }
    }
}
