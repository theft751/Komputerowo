using DataBaseContext;
using Domain.EntityModels.Products.OtherDevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.Arm;

namespace App.Pages.Products
{
    public class PrinterModel : ProductTemplatePageModel
    {
        public string Destination { get; set; } //For example: for small office, For corporation, for home
        public int MonochromaticPrintingSpeed { get; set; } //Pages per minute
        public string PrintTechnology { get; set; } //Laser, ink colour, monochromatic etc.
        public string MaxPrintingResolution { get; set; }
        public string SupportedMediaTypes { get; set; } //Plain paper, Labels, Envelopes
        public string SupportedMediaFormats { get; set; } //For example A4, A5, A6
        public string Connectivity { get; set; } //For example USB, Wi-Fi, LAN(Ethernet)
        public bool DuplexPrinting { get; set; }

        protected override void initializeEssentialProductProperties(int productId)
        {
            //Initialize inherited properties from ProductModel
            base.initializeEssentialProductProperties(productId);

            Printer product = context.Printers.Find(productId);

            //Initialize properties specific for DesktopComputer
            Destination = product.Destination;
            MonochromaticPrintingSpeed = product.MonochromaticPrintingSpeed;
            PrintTechnology = product.PrintTechnology;
            MaxPrintingResolution = product.MaxPrintingResolution;
            SupportedMediaTypes = product.SupportedMediaTypes;
            SupportedMediaFormats = product.SupportedMediaFormats;
            Connectivity = product.Connectivity;
            DuplexPrinting = product.DuplexPrinting;
        }

        public PrinterModel(AppDbContext _context)
            : base(_context)
        {
        }
    }
}
