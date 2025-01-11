using DataBaseContext;
using Domain.AppModel;
using Domain.EntityModels.Additional.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace App.Pages
{
    
    public class RealisedOrdersModel : PageModel
    {
        AppDbContext context;
        public IEnumerable<RealisedOrder> RealisedOrders { get; set; }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("isLogged") == 0 || HttpContext.Session.GetInt32("isUserAdmin") == 1)
            {
                return new RedirectToPageResult("/Index");
            }

            RealisedOrders = context
                .Users
                .Find("LoggedUserId")
                .Orders
                .Where(order=>order.Status==OrderStatus.Realised)
                .Select(
                    order=>new RealisedOrder()
                    { 
                        Number = order.Number,
                        RealisationDate = (DateTime)order.RealisationDate,
                        OrderDate = order.OrderDate
                    }
                );
            return Page();
        }
        public RealisedOrdersModel(AppDbContext _context)
        {
            context = _context;
        }
    }
}
