using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DataModel.Main;
using Model.DataModel.Products.ComputerParts;

namespace App.Pages.AdminPanel
{

    public class AddProcessorModel : AddProductModel
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

        public IActionResult OnPost()
        {
            //Product properties
            Processor product = new Processor();
            product.Name = Name;
            product.Producer = Producer;
            product.Description = Description;
            product.AdditionalInfo = AdditionalInfo;
            product.Color = Color;
            product.Amount = Amount;
            product.GuarantyTime = GuarantyTime;
            product.Price = Price;

            //Procesor properties
            product.Cores = Cores;
            product.Threads = Threads;  
            product.Frequency = Frequency;
            product.CacheSize = CacheSize;
            product.ProcessorSocket = ProcessorSocket;
            product.ProcessorSerie = ProcessorSerie;
            product.IntegratedGpu = IntegratedGpu;
            product.hasCoolerIncluded = hasCoolerIncluded;


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
            context.Processors.Add(product);
            context.SaveChanges();
            return Page();
        }

        public AddProcessorModel(AppDbContext _context)
            : base(_context) { }
    }
}
