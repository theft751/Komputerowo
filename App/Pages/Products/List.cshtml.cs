using DataBaseContext;
using Domain.AppModel;
using Domain.EntityModels.Additional.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace App.Pages.Products
{
    public class ListModel : PageModel
    {
        AppDbContext context;
        const int elementsPerPage = 10;

        public int PagesAmount { get; set; }
        public int ActualPageNumber { get; set; }
        public ProductType ProductType { get; set; }
        public IEnumerable<int> ProductIds { get; set; }
        public int ProductsInCategoryAmount { get; set; }
        public SortMode SortMode { get; set; } = SortMode.SortByRateAsc;


        public IActionResult OnGet([FromRoute]string typeOfProduct, [FromRoute] int pageNumber = 1)
        {
            ActualPageNumber = pageNumber;
            ProductType = (ProductType)Enum.Parse(typeof(ProductType), typeOfProduct, true);

            ProductsInCategoryAmount = context.Products
                .Where(product => product.ProductType == ProductType).Count();

            switch(SortMode)
            {
                case SortMode.SortByPriceAsc:
                    ProductIds =
                        context.Products
                        .Where(product => product.ProductType == ProductType)
                        .OrderBy(p => p.Price)
                        .Skip((ActualPageNumber - 1) * elementsPerPage)
                        .Take(elementsPerPage)
                        .Select(product => product.Id)
                        .ToList();
                    break;

                case SortMode.SortByPriceDesc:
                    ProductIds =
                    context.Products
                    .Where(product => product.ProductType == ProductType)
                    .OrderByDescending(p => p.Price)
                    .Skip((ActualPageNumber - 1) * elementsPerPage)
                    .Take(elementsPerPage)
                    .Select(product => product.Id)
                    .ToList();
                    break;

                case SortMode.SortByRateAsc:
                    ProductIds =
                        context.Products
                        .Where(product => product.ProductType == ProductType)
                        .ToList()
                        .OrderBy(p => p.AverageRate)
                        .Skip((ActualPageNumber - 1) * elementsPerPage)
                        .Take(elementsPerPage)
                        .Select(product => product.Id)
                        .ToList();
                    break;

                case SortMode.SortByRateDesc:
                    ProductIds =
                        context.Products
                        .Where(product => product.ProductType == ProductType)
                        .ToList()
                        .OrderByDescending(p => p.AverageRate)
                        .Skip((ActualPageNumber - 1) * elementsPerPage)
                        .Take(elementsPerPage)
                        .Select(product => product.Id)
                        .ToList();
                    break;
            }


            PagesAmount = 
                ProductsInCategoryAmount % elementsPerPage == 0 
                ? ProductsInCategoryAmount / elementsPerPage 
                : ProductsInCategoryAmount / elementsPerPage+1;

            return Page();

            
        }

        public IActionResult OnGetSort([FromRoute]string typeOfProduct, string sortMode)
        {
            SortMode = (SortMode)Enum.Parse(typeof(SortMode), sortMode, true);
            return OnGet(typeOfProduct);
        }

        public IActionResult OnPostAddToBasket([FromRoute] string typeOfProduct, int productId, int amount)
        {
            List<BasketElement> basket;



            try
            {
                basket =
                JsonSerializer
                .Deserialize<List<BasketElement>>(
                    Request.Cookies["Basket"]
                    );
            }
            catch
            {
                basket = new List<BasketElement>();
            }

            if (basket.Where(x => x.ProductId == productId).Any())
            {
                basket.FirstOrDefault(x => x.ProductId == productId).Amount += amount;
            }
            else
            {
                BasketElement basketElement = new BasketElement()
                {
                    ProductId = productId,
                    Amount = amount
                };
                basket.Add(basketElement);
            }

            string basketJson = JsonSerializer.Serialize(basket);

            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };

            Response.Cookies.Append("Basket", basketJson, cookieOptions);

            return OnGet(typeOfProduct);
        }

        public ListModel(AppDbContext _context)
        {
            context = _context;
        }
    }
}


