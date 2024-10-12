using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Model.DataModel.Additional.ComputerParts;
using Model.DataModel.Main;
using Model.DataModel.Products.ComputerParts;

namespace App.Pages.AdminPanel
{
    public class AddDiskDriveModel : AddProductModel
    {
        [BindProperty]
        public int DiskSize { get; set; } = 0; //In GB

        [BindProperty]
        public int ReadSpeed { get; set; } = 0; //In Mb/s

        [BindProperty]
        public int WriteSpeed { get; set; } = 0; //In Mb/s

        [BindProperty]
        public string DiskDriveInterface { get; set; }

        [BindProperty]
        public DiskDriveType DiskDriveType { get; set; }


        public IActionResult OnPost()
        {
            //Product properties 
            DiskDrive product = new DiskDrive();
            product.Name = Name;
            product.Producer = Producer;
            product.Description = Description;
            product.AdditionalInfo = AdditionalInfo;
            product.Color = Color;
            product.Amount = Amount;
            product.GuarantyTime = GuarantyTime;
            product.Price = Price;

            //DiskDrive properties 
            product.DiskSize = DiskSize;
            product.ReadSpeed = ReadSpeed;
            product.WriteSpeed = WriteSpeed;
            product.DiskDriveInterface = DiskDriveInterface;
            product.DiskDriveType = DiskDriveType;

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
            context.DiskDrives.Add(product);
            context.SaveChanges();
            return Page();
        }


        public AddDiskDriveModel(AppDbContext _context)
            : base(_context) { }
    }
}
