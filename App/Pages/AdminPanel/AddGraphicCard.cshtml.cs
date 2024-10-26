using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DataModel.Main;
using Model.DataModel.Products.ComputerParts;

namespace App.Pages.AdminPanel
{
    public class AddGraphicCardModel : AddProductModel
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
            GraphicCard product = new GraphicCard();

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

            context.Products.Add(product);
            context.SaveChanges();
            return Page();
        }
        
        public AddGraphicCardModel(AppDbContext _context)
            :base(_context){}
    }
}
