using DataBaseContext;
using Domain.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace App.Pages
{
    public class BasketModel : PageModel
    {
        AppDbContext context;
        public IEnumerable<BasketElement> BasketElements { get; set; }
        public int ProductsAmount { get; set; }
        public decimal BasketPrice { get; set; }
        public IActionResult OnGet()
        {

            try
            { 
            BasketElements = JsonSerializer
                .Deserialize<List<BasketElement>>(
                    Request.Cookies["Basket"]
                    );
            }
            catch
            {
                BasketElements = new List<BasketElement>();
            }
            ProductsAmount = BasketElements.Count();
            BasketPrice = BasketElements
                .ToList()
                .Select(
                    basketElement =>
                    context
                    .Products
                    .Where(
                        product =>
                        basketElement.ProductId == product.Id)
                    .Select(
                        product =>
                        product.Price * basketElement.Amount)
                    .FirstOrDefault())
                .Sum();
               

            return Page();
        }
        public IActionResult OnPostRemove(int id)
        {
            ICollection<BasketElement> basketElements;
                basketElements = JsonSerializer
                    .Deserialize<List<BasketElement>>(
                        Request.Cookies["Basket"]
                        );
                BasketElements = new List<BasketElement>();
                BasketElement basketElementToRemove = basketElements.First(element => element.ProductId == id);
                basketElements.Remove(basketElementToRemove);
                string basketJson = JsonSerializer.Serialize(basketElements);
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(30)
                };

                Response.Cookies.Append("Basket", basketJson, cookieOptions);
            return OnGet();

        }
        public void OnPostBuy()
        {
            ICollection<BasketElement> basketElements;
            basketElements = JsonSerializer
                .Deserialize<List<BasketElement>>(
                    Request.Cookies["Basket"]
                    );


            basketElements.Clear();
            string basketJson = JsonSerializer.Serialize(basketElements);

            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };

            Response.Cookies.Append("Basket", basketJson, cookieOptions);
            
        }
        public BasketModel(AppDbContext _context)
        {
            context = _context;
        }
    }
}
