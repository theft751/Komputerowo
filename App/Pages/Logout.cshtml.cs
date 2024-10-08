using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.SetInt32("isLogged", 0);
            HttpContext.Session.Remove("LoggedUserId");
            return new RedirectToPageResult("Index");
        }
    }
}
