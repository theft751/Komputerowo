using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DataModel.Main;
using Model.DataModel.Products.ComputerParts;

namespace App.Pages.AdminPanel
{
    public class AddPowerSupplyModel : AddProductModel
    {
        [BindProperty]
        public int MaximalPower { get; set; } // In Watts

        [BindProperty]
        public string Certyficate { get; set; }

        [BindProperty]
        public string PowerSupplyFormat { get; set; }

        [BindProperty]
        public string Efficiency { get; set; }

        [BindProperty]
        public string Connectors { get; set; }

        [BindProperty]
        public string PowerSupplyProtectorsFeatures { get; set; }

        public IActionResult OnPost()
        {

            PowerSupply product = new PowerSupply();

            //product properties
            product.Name = Name;
            product.Producer = Producer;
            product.Description = Description;
            product.AdditionalInfo = AdditionalInfo;
            product.Color = Color;
            product.Amount = Amount;
            product.GuarantyTime = GuarantyTime;
            product.Price = Price;

            //power supply properties
            product.MaximalPower = MaximalPower;
            product.Certyficate = Certyficate;
            product.PowerSupplyFormat = PowerSupplyFormat;
            product.Efficiency = Efficiency;
            product.Connectors = Connectors;
            product.PowerSupplyProtectorsFeatures = PowerSupplyProtectorsFeatures;

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
            context.PowerSupplies.Add(product);
            context.SaveChanges();
            return Page();
        }
        public AddPowerSupplyModel(AppDbContext _context)
            : base(_context) { }
    }
}
