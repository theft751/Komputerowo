using DataBaseContext;
using Domain.EntityModels.Products.OtherDevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.AppModel;

namespace App.Pages.AdminPanel
{
    public class AddOrEditPrinterModel : AddOrEditProductModel
    {
        [BindProperty]
        public string Destination { get; set; } //For example: for small office, For corporation, for home

        [BindProperty]
        public int MonochromaticPrintingSpeed { get; set; } //Pages per minute

        [BindProperty]
        public string PrintTechnology { get; set; } //Laser, ink colour, monochromatic etc.

        [BindProperty]
        public string MaxPrintingResolution { get; set; }

        [BindProperty]
        public string SupportedMediaTypes { get; set; } //Plain paper, Labels, Envelopes

        [BindProperty]
        public string SupportedMediaFormats { get; set; } //For example A4, A5, A6

        [BindProperty]
        public string Connectivity { get; set; } //For example USB, Wi-Fi, LAN(Ethernet)

        [BindProperty]
        public bool DuplexPrinting { get; set; }

        public AddOrEditPrinterModel(AppDbContext _context)
            : base(_context) { }

        public override IActionResult OnPost()
        {
            Printer product = OperationMode == OperationMode.Add ? new Printer() : context.Printers.Find(Id);

            //set properties inherited from product 
            setProductEssentialProperties(product); ;


            //Printer properties
            product.Destination = Destination;
            product.MonochromaticPrintingSpeed = MonochromaticPrintingSpeed;
            product.PrintTechnology = PrintTechnology;
            product.MaxPrintingResolution = MaxPrintingResolution;
            product.SupportedMediaTypes = SupportedMediaTypes;
            product.SupportedMediaFormats = SupportedMediaFormats;
            product.Connectivity = Connectivity;
            product.DuplexPrinting = DuplexPrinting;

            if (OperationMode == OperationMode.Add) context.Printers.Add(product);
            context.SaveChanges();
            return Page();
        }


        public override IActionResult OnGetEdit(int id)
        {
            Printer product = context.Printers.Find(id);

            //Printer properties
            product.Destination = Destination;
            product.MonochromaticPrintingSpeed = MonochromaticPrintingSpeed;
            product.PrintTechnology = PrintTechnology;
            product.MaxPrintingResolution = MaxPrintingResolution;
            product.SupportedMediaTypes = SupportedMediaTypes;
            product.SupportedMediaFormats = SupportedMediaFormats;
            product.Connectivity = Connectivity;
            product.DuplexPrinting = DuplexPrinting;

            setProductEssentialPropertiesOnEdit(id);
            return Page();
        }
    }
}
