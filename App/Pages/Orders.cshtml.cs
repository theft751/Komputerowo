using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages
{
    public class OrdersModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("isLogged") == 0 || HttpContext.Session.GetInt32("isUserAdmin") == 1)
            {
                return new RedirectToPageResult("/Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
