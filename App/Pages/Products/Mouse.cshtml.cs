using DataBaseContext;
using Domain.EntityModels.Products.OtherDevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Products
{
    public class MouseModel : ProductTemplatePageModel
    {
        public int Dpi { get; set; }
        public string Profile { get; set; } //Lefthanded or righthanded
        public string Connectivity { get; set; } //for example usb, or bluetooth or 2.4 GHz, also can has info about wire length
        public string Destination { get; set; } //for example to office or for gamers
        public int ButtonsAmount { get; set; }
        public string SensorType { get; set; } // Optical, Laser
        public bool Lighting { get; set; }
        protected override void initializeEssentialProductProperties(int productId)
        {
            //Initialize inherited properties from ProductModel
            base.initializeEssentialProductProperties(productId);

            Mouse product = context.Mouses.Find(productId);

            //Initialize properties specific for DesktopComputer
            Dpi = product.Dpi;
            Profile = product.Profile;
            Connectivity = product.Connectivity;
            Destination = product.Destination;
            ButtonsAmount = product.ButtonsAmount;
            SensorType = product.SensorType;
            Lighting = product.Lighting;
        }
        public MouseModel(AppDbContext _context)
            : base(_context)
        {
        }
    }
}
