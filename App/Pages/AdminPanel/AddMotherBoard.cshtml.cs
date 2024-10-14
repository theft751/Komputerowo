using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DataModel.Main;
using Model.DataModel.Products.ComputerParts;

namespace App.Pages.AdminPanel
{
    public class AddMotherBoardModel : AddProductModel
    {
        [BindProperty]
        public string Format { get; set; }

        [BindProperty]
        public string ProcessorSocket { get; set; }

        [BindProperty]
        public string Chipset { get; set; }

        [BindProperty]
        public string InternalSockets { get; set; }

        [BindProperty]
        public string ExternalSockets { get; set; }

        [BindProperty]
        public string SupportedMemoryTypes { get; set; }

        [BindProperty]
        public string SupportedMemoryTypesOC { get; set; }

        [BindProperty]
        public int RamSlots { get; set; }

        [BindProperty]
        public string ProcesorArchitecture { get; set; }

        [BindProperty]
        public string SupportedProcessorFamilies { get; set; }

        public IActionResult OnPost()
        {      
            //product properties
            MotherBoard product = new MotherBoard();
            product.Name = Name;
            product.Producer = Producer;
            product.Description = Description;
            product.AdditionalInfo = AdditionalInfo;
            product.Color = Color;
            product.Amount = Amount;
            product.GuarantyTime = GuarantyTime;
            product.Price = Price;

            //motherboard properties
            product.Format=Format;
            product.ProcessorSocket = ProcessorSocket;
            product.Chipset = Chipset;
            product.InternalSockets = InternalSockets;  
            product.ExternalSockets = ExternalSockets;
            product.SupportedMemoryTypes = SupportedMemoryTypes; 
            product.SupportedMemoryTypesOC = SupportedMemoryTypesOC;
            product.RamSlots = RamSlots;
            product.ProcesorArchitecture = ProcesorArchitecture;
            product.SupportedProcessorFamilies = SupportedProcessorFamilies;    

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

        public AddMotherBoardModel(AppDbContext _context)
            : base(_context) { }
    }
}
