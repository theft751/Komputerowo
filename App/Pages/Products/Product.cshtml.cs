using DataBaseContext;
using Domain.EntityModels.Additional.Common;
using Domain.EntityModels.Main;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;

namespace App.Pages.Products
{
    public class ProductPageModel : PageModel
    {
        AppDbContext context;
        public IActionResult OnGet(int id)
        {
            try
            { 
                Product p = context.Products.Find(id);
                switch (p.ProductType)
                {
                    case ProductType.CASE:
                        return new RedirectToPageResult($"/Products/Case", new {productId = id});
                        break;
                    case ProductType.DESKTOP_COMPUTER:
                        return new RedirectToPageResult($"/Products/DesktopComputer", new { productId = id });
                        break;
                    case ProductType.DISK_DRIVE:
                        return new RedirectToPageResult($"/Products/DiskDrive", new { productId = id });
                        break;
                    case ProductType.GRAPHIC_CARD:
                        return new RedirectToPageResult($"/Products/GraphicCard", new { productId = id });
                        break;
                    case ProductType.LAPTOP:
                        return new RedirectToPageResult($"/Products/Laptop", new { productId = id });
                        break;
                    case ProductType.MOTHERBOARD:
                        return new RedirectToPageResult($"/Products/MotherBoard", new { productId = id });
                        break;
                    case ProductType.POWER_SUPPLY:
                        return new RedirectToPageResult($"/Products/PowerSupply", new { productId = id });
                        break;
                    case ProductType.PROCESSOR:
                        return new RedirectToPageResult($"/Products/Processor", new { productId = id });
                        break;
                    case ProductType.RAM:
                        return new RedirectToPageResult($"/Products/Ram", new { productId = id });
                        break;
                    case ProductType.SMARTPHONE:
                        return new RedirectToPageResult($"/Products/Smartphone", new { productId = id });
                        break;
                    case ProductType.TELEVISOR:
                        return new RedirectToPageResult($"/Products/Televisor", new { productId = id });
                        break;
                    default:
                        return new RedirectToPageResult("/Error");
                }
            }
            catch
            {
                return new RedirectToPageResult("/Error");
            }
        }
        public ProductPageModel(AppDbContext _context)
        {
            context = _context;
        }
    }
}
