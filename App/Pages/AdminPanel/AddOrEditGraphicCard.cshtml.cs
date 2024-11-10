using DataBaseContext;
using Domain.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.EntityModels.Main;
using Model.EntityModels.Products.ComputerParts;

namespace App.Pages.AdminPanel
{
    public class AddOrEditGraphicCardModel : AddOrEditProductModel
    {
        [BindProperty]
        public string Gpu { get; set; }

        [BindProperty]
        public string GraphicCardSerie { get; set; }

        [BindProperty]
        public string MemoryType { get; set; }

        [BindProperty]
        public string ConnectorType { get; set; }

        [BindProperty]
        public string OutputTypes { get; set; }

        [BindProperty]
        public int MemorySize { get; set; }

        [BindProperty]
        public int MemoryBus { get; set; } //For example 256 bits

        [BindProperty]
        public int CoreColck { get; set; }

        [BindProperty]
        public int MemoryClock { get; set; }

        [BindProperty]
        public bool Litghting { get; set; }

        [BindProperty]
        public bool RayTracing { get; set; }
        public override IActionResult OnPost()
        {
            GraphicCard product = OperationMode == OperationMode.Add ? new GraphicCard():context.GraphicCards.Find(Id);

            //set properties inherited from product 
            setProductEssentialProperties(product); ;


            //GraphicCard properties
            product.Gpu = Gpu;
            product.GraphicCardSerie = GraphicCardSerie;
            product.MemoryType = MemoryType;
            product.ConnectorType = ConnectorType;
            product.OutputTypes = OutputTypes;
            product.MemorySize = MemorySize;
            product.MemoryBus = MemoryBus;
            product.CoreColck = CoreColck;
            product.MemoryClock = MemoryClock;
            product.Litghting = Litghting;
            product.RayTracing = RayTracing;

            if(OperationMode == OperationMode.Add)context.GraphicCards.Add(product);
            context.SaveChanges();
            return Page();
        }
        
        public AddOrEditGraphicCardModel(AppDbContext _context)
            :base(_context){}
    }
}
