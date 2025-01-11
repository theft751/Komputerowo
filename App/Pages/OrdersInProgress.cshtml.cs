using DataBaseContext;
using Domain.AppModel;
using Domain.EntityModels.Additional.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages
{
    public class OrdersInProgressModel : PageModel
    {
        AppDbContext context;
        public IEnumerable<OrderInProgress> OrdersInProgresses { get; set; }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("isLogged") == 0 || HttpContext.Session.GetInt32("isUserAdmin") == 1)
            {
                return new RedirectToPageResult("/Index");
            }

            OrdersInProgresses = context
                .Users
                .Find("LoggedUserId")
                .Orders
                .Where(order => order.Status == OrderStatus.InProgress)
                .Select(
                    order => new OrderInProgress()
                    {
                        Number = order.Number,
                        OrderDate = order.OrderDate
                    }
                );
            return Page();
        }
        public OrdersInProgressModel(AppDbContext _context)
        {
            context = _context;
        }
    }
}
