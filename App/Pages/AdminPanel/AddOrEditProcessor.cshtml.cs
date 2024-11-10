using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.EntityModels.Main;
using Model.EntityModels.Products.ComputerParts;

namespace App.Pages.AdminPanel
{

    public class AddOrEditProcessorModel : AddOrEditProductModel
    {
        //Processor properties
        [BindProperty]
        public int Cores { get; set; } //Amount of cores

        [BindProperty]
        public int Threads { get; set; }

        [BindProperty]
        public int Frequency { get; set; } //Frequency per Core

        [BindProperty]
        public int CacheSize { get; set; } //Mb

        [BindProperty]
        public string ProcessorSocket { get; set; }

        [BindProperty]
        public string ProcessorSerie { get; set; }
        [BindProperty]
        public bool IntegratedGpu { get; set; }

        [BindProperty]
        public bool hasCoolerIncluded { get; set; }

        public override IActionResult OnPost()
        {
            Processor product = new Processor();

            //set properties inherited from product 
            setProductEssentialProperties(product); ;

            //Procesor properties
            product.Cores = Cores;
            product.Threads = Threads;  
            product.Frequency = Frequency;
            product.CacheSize = CacheSize;
            product.ProcessorSocket = ProcessorSocket;
            product.ProcessorSerie = ProcessorSerie;
            product.IntegratedGpu = IntegratedGpu;
            product.hasCoolerIncluded = hasCoolerIncluded;


            context.Processors.Add(product);
            context.SaveChanges();
            return Page();
        }

        public AddOrEditProcessorModel(AppDbContext _context)
            : base(_context) { }
    }
}
