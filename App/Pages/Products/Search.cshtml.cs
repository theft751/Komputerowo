using DataBaseContext;
using Domain.AppModel;
using Domain.EntityModels.Additional.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace App.Pages.Products
{
    public class SearchModel : PageModel
    {
        AppDbContext context;
        const int elementsPerPage = 10;

        public string SearchText {  get; set; }

        public int PagesAmount { get; set; }
        public int ActualPageNumber { get; set; }
        public IEnumerable<int> ProductIds { get; set; }
        public int AllSearchedProducts { get; set; }
        public SortMode SortMode { get; set; } = SortMode.SortByRateAsc;

        public IActionResult OnGet([FromRoute] string searchText, [FromRoute] int pageNumber = 1)
        {
            ActualPageNumber = pageNumber;
            SearchText = searchText;

            AllSearchedProducts = context.Products
                .Where(p => p.Name.ToUpper().Contains(searchText.ToUpper())).Count();

            switch (SortMode)
            {
                case SortMode.SortByPriceAsc:
                    ProductIds =
                        context.Products
                        .Where(p => p.Name.ToUpper().Contains(searchText.ToUpper()))
                        .OrderBy(p => p.Price)
                        .Skip((ActualPageNumber - 1) * elementsPerPage)
                        .Take(elementsPerPage)
                        .Select(product => product.Id)
                        .ToList();
                    break;

                case SortMode.SortByPriceDesc:
                    ProductIds =
                    context.Products
                    .Where(p => p.Name.ToUpper().Contains(searchText.ToUpper()))
                    .OrderByDescending(p => p.Price)
                    .Skip((ActualPageNumber - 1) * elementsPerPage)
                    .Take(elementsPerPage)
                    .Select(product => product.Id)
                    .ToList();
                    break;

                case SortMode.SortByRateAsc:
                    ProductIds =
                        context.Products
                        .Where(p => p.Name.ToUpper().Contains(searchText.ToUpper()))
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
                        .Where(p => p.Name.ToUpper().Contains(searchText.ToUpper()))
                        .ToList()
                        .OrderByDescending(p => p.AverageRate)
                        .Skip((ActualPageNumber - 1) * elementsPerPage)
                        .Take(elementsPerPage)
                        .Select(product => product.Id)
                        .ToList();
                    break;
            }


            PagesAmount =
                AllSearchedProducts % elementsPerPage == 0
                ? AllSearchedProducts / elementsPerPage
                : AllSearchedProducts / elementsPerPage + 1;

            return Page();
        }

        public IActionResult OnGetSort([FromRoute] string searchText, string sortMode)
        {
            SortMode = (SortMode)Enum.Parse(typeof(SortMode), sortMode, true);
            return OnGet(searchText);
        }

        public IActionResult OnPostAddToBasket([FromRoute] string searchText, int productId, int amount)
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

            return OnGet(searchText);
        }

        public SearchModel(AppDbContext _context)
        {
            context = _context;
        }
    }
}
