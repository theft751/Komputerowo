using DataBaseContext;
using Domain.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.EntityModels.Additional.Common;
using Model.EntityModels.Main;
using System.Drawing;

namespace App.Pages.AdminPanel
{
    public abstract class AddOrEditProductModel : AdminPanelPageModel
    {
        [BindProperty]
        public OperationMode OperationMode { get; set; }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        ProductPassData ProductPassData { get; set; }

        [BindProperty]
        public string Name { get; set; } = "";

        [BindProperty]
        public string Producer { get; set; } = "";

        [BindProperty]
        public string Description { get; set; } = "";

        [BindProperty]
        public string AdditionalInfo { get; set; } = "";

        [BindProperty]
        public string Color { get; set; } = "";

        [BindProperty]
        public int Amount { get; set; } = 0;

        [BindProperty]
        public int GuarantyTime { get; set; } = 0; //Months

        [BindProperty]
        public decimal Price { get; set; } = 0;

        [BindProperty]
        public IFormFile MainImage { get; set; }

        [BindProperty]
        public ICollection<IFormFile> BonusImages { get; set; }
        
        protected void setProductEssentialProperties(Product product)
        {
            product.Name = Name;
            product.Producer = Producer;
            product.Description = Description;
            product.AdditionalInfo = AdditionalInfo;
            product.Color = Color;
            product.Amount = Amount;
            product.GuarantyTime = GuarantyTime;
            product.Price = Price;


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
        }

        public abstract IActionResult OnPost();

       

        private void onEditInitializePassData()
        {
            OperationMode = OperationMode.Edit;
            ProductPassData productData = new(
                Id,
                OperationMode.Edit,
                AdditionalInfo,
                Color,
                Amount,
                GuarantyTime,
                Name,
                Description,
                Price,
                Producer);
            
        }
        public IActionResult OnGetAdd()
        {
            OperationMode operationMode = OperationMode.Add;
            
            return Page();
        }

        public AddOrEditProductModel(AppDbContext _context)
            :base(_context) { }
    }
}
