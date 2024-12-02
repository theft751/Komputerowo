using DataBaseContext;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Products
{
    public class KeyboardModel : ProductTemplatePageModel
    {
        public string SwitchType { get; set; } //For example mechanical, membrane, hybrid etc.
        public string Connectivity { get; set; } //for example usb, or bluetooth or 2.4 GHz, also can has info about wire length
        public string Destination { get; set; } //for example to office or for gamers
        public string Profile { get; set; } ////Low-profile or high-profile or other one
        public bool Lighting { get; set; }
        public bool NumericKeypad { get; set; }

        public KeyboardModel(AppDbContext _context)
            : base(_context)
        {
        }

        protected override void initializeEssentialProductProperties(int productId)
        {
            //Initialize inherited properties from ProductModel
            base.initializeEssentialProductProperties(productId);

            Keyboard product = context.Keyboards.Find(productId);

            //Initialize properties specific for DesktopComputer
            SwitchType = product.SwitchType;
            Connectivity = product.Connectivity;
            Destination = product.Destination;
            Profile = product.Profile;
            Lighting = product.Lighting;
            NumericKeypad = product.NumericKeypad;
           
        }
    }
}
