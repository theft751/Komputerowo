using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;
using Domain.EntityModels.Additional.ComputerParts;

namespace App.Pages.Products
{
    public class GraphicCardModel : ProductPageModel
    {
        public string Gpu { get; set; }
        public string GraphicCardSerie { get; set; }
        public string MemoryType { get; set; }
        public string ConnectorType { get; set; }
        public string OutputTypes { get; set; }
        public int MemorySize { get; set; }
        public int MemoryBus { get; set; } //For example 256 bits
        public int CoreColck { get; set; }
        public int MemoryClock { get; set; }
        public bool Litghting { get; set; }
        public bool RayTracing { get; set; }

        protected override void initializeEssentialProductProperties(int productId)
        {
            //Initialize inherited properties from ProductModel
            base.initializeEssentialProductProperties(productId);

            GraphicCard graphicCard = context.GraphicCards.Find(productId);

            //Initialize properties specific for DesktopComputer
            Gpu = graphicCard.Gpu;
            GraphicCardSerie = graphicCard.GraphicCardSerie;
            MemoryType = graphicCard.MemoryType;
            ConnectorType = graphicCard.ConnectorType;
            OutputTypes = graphicCard.OutputTypes;
            MemorySize = graphicCard.MemorySize;
            MemoryBus = graphicCard.MemoryBus;
            CoreColck = graphicCard.CoreColck;
            MemoryClock = graphicCard.MemoryClock;
            Litghting = graphicCard.Litghting;
            RayTracing = graphicCard.RayTracing;
        }
        GraphicCardModel(AppDbContext _context)
            : base(_context)
        {
        }
    }
}
