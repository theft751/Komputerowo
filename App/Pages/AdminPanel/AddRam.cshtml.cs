using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DataModel.Main;
using Model.DataModel.Products.ComputerParts;

namespace App.Pages.AdminPanel
{
    public class AddRamModel : AddProductModel
    {
        //Ram properties
        [BindProperty]
        public int SizePerChips { get; set; } //Gb

        [BindProperty]
        public int ChipsAmount { get; set; }

        [BindProperty]
        public int Frequency { get; set; }// MHz

        [BindProperty]
        public bool Ligthing { get; set; }

        [BindProperty]
        public string RamType { get; set; }

        public IActionResult OnPost()
        {
            Ram product = new Ram();

            //Product properties
            product.Name = Name;
            product.Producer = Producer;
            product.AdditionalInfo = AdditionalInfo;
            product.Color = Color;
            product.Amount = Amount;
            product.GuarantyTime = GuarantyTime;
            product.Price = Price;
            
            //Ram properties
            product.SizePerChips = SizePerChips;
            product.ChipsAmount = ChipsAmount;
            product.Frequency = Frequency;
            product.Ligthing = Ligthing;
            product.RamType = RamType;

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
            context.Rams.Add(product);
            context.SaveChanges();
            return Page();
        }
        public AddRamModel(AppDbContext _context)
            : base(_context) { }
    }
}
