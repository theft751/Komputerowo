using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages
{
    public class RegisterCompletedModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("isLogged") == 1)
                return RedirectToPage("Index");
            else
                return Page();
        }
    }
}
