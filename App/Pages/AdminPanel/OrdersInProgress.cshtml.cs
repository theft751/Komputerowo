using DataBaseContext;
using Domain.AppModel;
using Domain.EntityModels.Additional.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.AdminPanel
{
    public class OrdersInProgressModel : AdminPanelPageModel
    {
        public IEnumerable<OrderInProgress> OrdersInProgresses { get; set; }
        public IActionResult OnGet()
        {
            OrdersInProgresses = context
                .Orders
                .Where(order => order.Status == OrderStatus.InProgress)
                .Select(
                    order => new OrderInProgress()
                    {
                        Number = order.Number,
                        OrderDate = order.OrderDate
                    }
                );
            return AdminPage();
        }
        public OrdersInProgressModel(AppDbContext _context)
            : base(_context) { }
        public IActionResult OnPost(string orderNumber)
        {
            context
                .Orders
                .FirstOrDefault(order => order.Number == orderNumber)
                .Status = OrderStatus.Realised;
            context.SaveChanges();
            return OnGet();
        }
    }
}


