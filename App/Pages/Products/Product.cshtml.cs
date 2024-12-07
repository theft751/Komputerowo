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
        public IActionResult OnGet([FromRoute]int id)
        {
            try
            { 
                Product p = context.Products.Find(id);
                switch (p.ProductType)
                {
                    case ProductType.Case:
                        return new RedirectToPageResult($"/Products/Case", new {productId = id});
                        break;
                    case ProductType.DesktopComputer:
                        return new RedirectToPageResult($"/Products/DesktopComputer", new { productId = id });
                        break;
                    case ProductType.DiskDrive:
                        return new RedirectToPageResult($"/Products/DiskDrive", new { productId = id });
                        break;
                    case ProductType.GraphicCard:
                        return new RedirectToPageResult($"/Products/GraphicCard", new { productId = id });
                        break;
                    case ProductType.Laptop:
                        return new RedirectToPageResult($"/Products/Laptop", new { productId = id });
                        break;
                    case ProductType.Motherboard:
                        return new RedirectToPageResult($"/Products/MotherBoard", new { productId = id });
                        break;
                    case ProductType.PowerSupply:
                        return new RedirectToPageResult($"/Products/PowerSupply", new { productId = id });
                        break;
                    case ProductType.Processor:
                        return new RedirectToPageResult($"/Products/Processor", new { productId = id });
                        break;
                    case ProductType.Ram:
                        return new RedirectToPageResult($"/Products/Ram", new { productId = id });
                        break;
                    case ProductType.Smartphone:
                        return new RedirectToPageResult($"/Products/Smartphone", new { productId = id });
                        break;
                    case ProductType.Televisor:
                        return new RedirectToPageResult($"/Products/Televisor", new { productId = id });
                        break;
                    case ProductType.Monitor:
                        return new RedirectToPageResult($"/Products/Monitor", new { productId = id });
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
