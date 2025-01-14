using DataBaseContext;
using Domain.AppModel;
using Domain.EntityModels.Additional.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.AdminPanel
{
    public class RealisedOrdersModel : AdminPanelPageModel
    {
        public IEnumerable<RealisedOrder> RealisedOrders { get; set; }
        public IActionResult OnGet()
        {
            RealisedOrders = context
                .Orders
                .Where(order => order.Status == OrderStatus.Realised)
                .Select(
                    order => new RealisedOrder()
                    {
                        Number = order.Number,
                        RealisationDate = (DateTime)order.RealisationDate,
                        OrderDate = order.OrderDate
                    }
                );
            return AdminPage();
        }
        public RealisedOrdersModel(AppDbContext _context)
            : base(_context) { }
        public IActionResult OnPost(string orderNumber)
        {
            context
                .Orders
                .FirstOrDefault(order=>order.Number == orderNumber)
                .Status = OrderStatus.InProgress;
            context.SaveChanges();
            return OnGet();
        }
    }
    
}
