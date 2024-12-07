using DataBaseContext;
using Domain.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.EntityModels.Main;
using Domain.EntityModels.Products.ComputerParts;

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
            Processor product = OperationMode == OperationMode.Add ? new Processor():context.Processors.Find(Id);

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
            product.CoolerIncluded = hasCoolerIncluded;


            if (OperationMode == OperationMode.Add) context.Processors.Add(product);
            context.SaveChanges();
            return Page();
        }

        public override IActionResult OnGetEdit(int id)
        {
            Processor product = context.Processors.Find(id);

            //Procesor properties
            Cores = product.Cores;
            Threads = product.Threads;
            Frequency = product.Frequency;
            CacheSize = product.CacheSize;
            ProcessorSocket = product.ProcessorSocket;
            ProcessorSerie = product.ProcessorSerie;
            IntegratedGpu = product.IntegratedGpu;
            hasCoolerIncluded = product.CoolerIncluded;

            setProductEssentialPropertiesOnEdit(id);
            return Page();
        }
        public AddOrEditProcessorModel(AppDbContext _context)
            : base(_context) { }
    }
}
