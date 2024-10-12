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
        public IActionResult OnPost()
        {
            GraphicCard product = new GraphicCard();

            //Product properties
            product.Name = Name;
            product.Producer = Producer;
            product.Description = Description;
            product.AdditionalInfo = AdditionalInfo;
            product.Color = Color;
            product.Amount = Amount;
            product.GuarantyTime = GuarantyTime;
            product.Price = Price;


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


            MainProductImage MainProductImage = new MainProductImage();
            product.MainImage = MainProductImage;

            MainProductImage.ImageTitle = MainImage.FileName;
            MainProductImage.ImageType = MainImage.ContentType;
            using (var memoryStream = new MemoryStream())
            {
                MainImage.CopyTo(memoryStream);
                MainProductImage.ImageData = memoryStream.ToArray();
            }


            foreach (var image in BonusImages)
            {
                BonusProductImage productImage = new BonusProductImage();
                productImage.ImageTitle = image.Name;
                productImage.ImageType = image.ContentType;

                using (var memoryStream = new MemoryStream())
                {
                    image.CopyTo(memoryStream);
                    productImage.ImageData = memoryStream.ToArray();
                }
                product.BonusImages.Add(productImage);
                context.BonusProductImages.Add(productImage);

            }

            context.MainProductImages.Add(MainProductImage);
            context.Products.Add(product);
            context.SaveChanges();
            return Page();
        }
        
        public AddGraphicCardModel(AppDbContext _context)
            :base(_context){}
    }
}
