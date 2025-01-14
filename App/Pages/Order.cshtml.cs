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
        public IEnumerable<BasketElement> OrderItems { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string OrderNumber { get; set; }
        public string AcountNumber { get; set; }
        public decimal Price { get; set; }
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
            OrderNumber = order.Number;
            OrderStatus = order.Status;
            OrderItems = order
                .Items
                .Select(
                    orderItem =>
                    new BasketElement()
                    {
                        Amount = orderItem.Amount,
                        ProductId = orderItem.ProductId
                    }
                );
            AcountNumber = context.BankAcountNumber.FirstOrDefault().Number;
            Price = OrderItems
            .ToList()
            .Select(
                orderItem =>
                context
                .Products
                .Where(
                    product =>
                    orderItem.ProductId == product.Id)
                .Select(
                    product =>
                    product.Price * orderItem.Amount)
                .FirstOrDefault())
            .Sum();
            return Page();

        }
        public OrderModel(AppDbContext _context)
        {
            context = _context;
        }
    }
}
