using Domain.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace App.Pages
{
    public class BasketModel : PageModel
    {
        public IEnumerable<BasketElement> BasketElements { get; set; }
        public int ProductsAmount { get; set; }
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
                return OnGet();

        }
    }
}
