using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DataModel.Main;
using Model.DataModel.Products.OtherDevices;

namespace App.Pages.AdminPanel
{
    public class AddTelevisorModel : AddProductModel
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

        public AddTelevisorModel(AppDbContext _context)
            : base(_context) { }
        public override IActionResult OnPost()
        {
            Televisor product = new Televisor();

            //set properties inherited from product 
            setProductEssentialProperties(product); ;

            //Televisor properties
            product.Resolution = Resolution;
            product.ScreenDiagonal = ScreenDiagonal;
            product.ScreenRefreshRate = ScreenRefreshRate;
            product.ExternalPorts = ExternalPorts;
            product.hasSmartTv = hasSmartTv; 
            product.OperatingSystem = OperatingSystem;

            context.Products.Add(product);
            context.SaveChanges();
            return Page();
        }
    }
}
