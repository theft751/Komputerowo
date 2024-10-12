using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DataModel.Additional.ComputerParts;
using Model.DataModel.Main;
using Model.DataModel.Products.ComputerParts;

namespace App.Pages.AdminPanel
{
    public class AddCaseModel : AddProductModel
    {
        [BindProperty]
        public string MotherBoardFormats { get; set; } = "";

        [BindProperty]
        public string PowerSupplyFormat { get; set; } = "";

        [BindProperty]
        public CaseType CaseType { get; set; }



        public override IActionResult OnPost()
        {
            Case product = new Case();
            //Product properties
            product.Name = Name;
            product.Producer = Producer;
            product.Description = Description;
            product.AdditionalInfo = AdditionalInfo;
            product.Color = Color;
            product.Amount = Amount;
            product.GuarantyTime = GuarantyTime;
            product.Price = Price;

            //Case properties
            product.MotherBoardFormats = MotherBoardFormats;
            product.PowerSupplyFormat = PowerSupplyFormat;
            product.CaseType = CaseType;

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
        public AddCaseModel(AppDbContext _context)
            :base(_context){}
    }
}
