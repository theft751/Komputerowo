using DataBaseContext;
using Domain.AppModel;
using Domain.EntityModels.Additional.Common;
using Domain.EntityModels.Main;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages
{
    public class OrderModel : PageModel
    {
        AppDbContext context { get; set; }
        public IEnumerable<BasketElement> orderItems { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public IActionResult OnGet(string number)
        {
            if (HttpContext.Session.GetInt32("isLogged") == 0)
            {
                return new RedirectToPageResult("/Index");
            }
            Order order = context.Orders.FirstOrDefault(order=>order.Number==number);
            if (order == null)
            {
                return new RedirectToPageResult("/Error");
            }
            OrderStatus = order.Status;
            orderItems = order
                .Items
                .Select(
                    orderItem =>
                    new BasketElement()
                    {
                        Amount = orderItem.Amount,
                        ProductId = orderItem.ProductId
                    }
                );
            return Page();

        }
        public OrderModel(AppDbContext _context)
        {
            context = _context;
        }
    }
}
