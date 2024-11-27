using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;

namespace App.Pages.Products
{
    public class TelevisorModel : ProductTemplatePageModel
    {
        public string Resolution { get; set; }
        public decimal ScreenDiagonal { get; set; } //inches
        public int ScreenRefreshRate { get; set; } //Hz

        public string ExternalPorts { get; set; }
        public bool hasSmartTv { get; set; }
        public string OperatingSystem { get; set; }
        protected override void initializeEssentialProductProperties(int productId)
        {
            //Initialize inherited properties from ProductModel
            base.initializeEssentialProductProperties(productId);

            Televisor telvisor = context.Televisors.Find(productId);

            //Initialize properties specific for DesktopComputer
            Resolution = telvisor.Resolution;
            ScreenDiagonal = telvisor.ScreenDiagonal;
            ScreenRefreshRate = telvisor.ScreenRefreshRate;

            ExternalPorts = telvisor.ExternalPorts;
            hasSmartTv = telvisor.hasSmartTv;
            OperatingSystem = telvisor.OperatingSystem;
        }
        public TelevisorModel(AppDbContext _context)
            : base(_context)
        {
        }
    }
}
