using DataBaseContext;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.AppModel;
namespace App.Pages.AdminPanel
{
    public class AddOrEditMonitorModel : AddOrEditProductModel
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
        public string ScreenType { get; set; } // for example ips

        [BindProperty]
        public bool BuiltInSpeakers { get; set; }

        [BindProperty]
        public decimal Latency { get; set; } // in miliseconds

        public override IActionResult OnPost()
        {
            Domain.AppModel.OperationMode operationMode = OperationMode;
            MonitorScreen product = operationMode == OperationMode.Add ? new MonitorScreen() : context.Monitors.Find(Id);

            //set properties inherited from product 
            setProductEssentialProperties(product); ;

            //monitor properties
            product.Resolution = Resolution;
            product.ScreenDiagonal = ScreenDiagonal;
            product.ScreenRefreshRate = ScreenRefreshRate;
            product.ExternalPorts = ExternalPorts;
            product.ScreenType = ScreenType;
            product.BuiltInSpeakers = BuiltInSpeakers;
            product.Latency = Latency;
            product.ExternalPorts = ExternalPorts;
            product.Resolution = Resolution;
            product.ScreenDiagonal = ScreenDiagonal;
            product.ScreenType = ScreenType;

            if (operationMode == OperationMode.Add) context.Monitors.Add(product);
            context.SaveChanges();
            return Page();
        }


        public override IActionResult OnGetEdit(int id)
        {
            MonitorScreen product = context.Monitors.Find(id);


            product.Resolution = Resolution;
            product.ScreenDiagonal = ScreenDiagonal;
            product.ScreenRefreshRate = ScreenRefreshRate;
            product.ExternalPorts = ExternalPorts;
            product.ScreenType = ScreenType;
            product.BuiltInSpeakers = BuiltInSpeakers;
            product.Latency = Latency;
            product.ExternalPorts = ExternalPorts;
            product.Resolution = Resolution;
            product.ScreenDiagonal = ScreenDiagonal;
            product.ScreenType = ScreenType;

            setProductEssentialPropertiesOnEdit(id);
            return Page();
        }

        public AddOrEditMonitorModel(AppDbContext _context)
            : base(_context) { }
    }
}

