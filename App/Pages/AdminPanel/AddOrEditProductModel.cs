using DataBaseContext;
using Domain.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.EntityModels.Additional.Common;
using Domain.EntityModels.Main;
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
        public ProductPassData ProductPassData { get; set; }

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

            MainProductImage.Caption = MainImage.FileName;
            MainProductImage.Type = MainImage.ContentType;
            using (var memoryStream = new MemoryStream())
            {
                MainImage.CopyTo(memoryStream);
                MainProductImage.Data = memoryStream.ToArray();
            }


            foreach (var image in BonusImages)
            {
                BonusProductImage productImage = new BonusProductImage();
                productImage.Caption = image.Name;
                productImage.Type = image.ContentType;

                using (var memoryStream = new MemoryStream())
                {
                    image.CopyTo(memoryStream);
                    productImage.Data = memoryStream.ToArray();
                }
                product.BonusImages.Add(productImage);
                context.BonusProductImages.Add(productImage);

            }

            context.MainProductImages.Add(MainProductImage);
        }

        public abstract IActionResult OnPost();



        protected void setProductEssentialPropertiesOnEdit(int productId)
        {
            Product p = context.Products.Find(productId);

            Id = p.Id;
            Name = p.Name;
            Producer = p.Producer;
            Description = p.Description;
            AdditionalInfo = p.AdditionalInfo;
            Color = p.Color;
            Amount = p.Amount;
            GuarantyTime = p.GuarantyTime; //Months
            Price = p.Price;

            OperationMode = OperationMode.Edit;

            ProductPassData = new(
                p.Id,
                OperationMode.Edit,
                p.AdditionalInfo,
                p.Color,
                p.Amount,
                p.GuarantyTime,
                p.Name,
                p.Description,
                p.Price,
                p.Producer);
        }
        protected void setProductEssentialPropertiesOnAdd()
        {
            ProductPassData = new(
                0,
                OperationMode.Add,
                "",
                "",
                1,
                0,
                "",
                "",
                0,
                "");

        }
        public IActionResult OnGetAdd()
        {
            OperationMode = OperationMode.Add;
            setProductEssentialPropertiesOnAdd();
            return AdminPage();
        }
        public abstract IActionResult OnGetEdit(int id);

        public AddOrEditProductModel(AppDbContext _context)
         :base(_context){}
    }
}
