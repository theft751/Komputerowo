using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;
using Microsoft.SqlServer.Server;
using System.Reflection;
using System.Runtime.InteropServices;

namespace App.Pages.Products
{
    public class ProcessorModel : ProductPageModel
    {
        public int Cores { get; set; } //Amount of cores
        public int Threads { get; set; }
        public int Frequency { get; set; } //Frequency per Core
        public int CacheSize { get; set; } //Mb
        public bool IntegratedGpu { get; set; }
        public bool hasCoolerIncluded { get; set; }

        public string ProcessorSocket { get; set; }
        public string ProcessorSerie { get; set; }

        protected override void initializeEssentialProductProperties(int productId)
        {
            //Initialize inherited properties from ProductModel
            base.initializeEssentialProductProperties(productId);

            Processor processor = context.Processors.Find(productId);

            //Initialize properties specific for DesktopComputer
            Cores = processor.Cores;
            Threads = processor.Threads;
            Frequency = processor.Frequency;
            CacheSize = processor.CacheSize;
            IntegratedGpu = processor.IntegratedGpu;
            hasCoolerIncluded = processor.hasCoolerIncluded;
            ProcessorSocket = processor.ProcessorSocket;
            ProcessorSerie = processor.ProcessorSerie;
        }

        ProcessorModel(AppDbContext _context)
            : base(_context)
        {
        }
    }
}
