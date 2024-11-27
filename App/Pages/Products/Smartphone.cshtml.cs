using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;
using System.Threading;

namespace App.Pages.Products
{
    public class SmartphoneModel : ProductTemplatePageModel
    {
        public string BackCamera { get; set; }
        public string FrontCamera { get; set; }

        public string Resolution { get; set; }
        public decimal ScreenDiagonal { get; set; } //inches
        public int ScreenRefreshRate { get; set; } //Hz

        public string Processor { get; set; }
        public int RamSize { get; set; }
        public int EmbeddedMemorySize { get; set; }
        public string OperatingSystem { get; set; }
        public string ExternalPorts { get; set; }

        public int BatteryCapacity { get; set; }

        public bool Nfc { get; set; }
        public bool FingPrinterReader { get; set; }

        protected override void initializeEssentialProductProperties(int productId)
        {
            //Initialize inherited properties from ProductModel
            base.initializeEssentialProductProperties(productId);

            Smartphone smartphone = context.Smartphones.Find(productId);

            //Initialize properties specific for DesktopComputer
            BackCamera = smartphone.BackCamera;
            FrontCamera = smartphone.FrontCamera;
            Resolution = smartphone.Resolution;
            ScreenDiagonal = smartphone.ScreenDiagonal;
            ScreenRefreshRate = smartphone.ScreenRefreshRate;
            Processor = smartphone.Processor;
            RamSize = smartphone.RamSize;
            EmbeddedMemorySize = smartphone.EmbeddedMemorySize;
            OperatingSystem = smartphone.OperatingSystem;
            ExternalPorts = smartphone.ExternalPorts;
            BatteryCapacity = smartphone.BatteryCapacity;
            Nfc = smartphone.Nfc;
            FingPrinterReader = smartphone.FingPrinterReader;
        }

        public SmartphoneModel(AppDbContext _context)
            : base(_context)
        {
        }
    }
}
