using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages
{
    public class UserSettingsPanelModel : PageModel
    {
        AppDbContext context; 
        public IActionResult OnGet()
        {
            if(HttpContext.Session.GetInt32("isLogged") == 1)
            { 
                try
                {
                    string userEmail = 
                        context
                        .Users
                        .Where(x=>x.Id==HttpContext.Session.GetInt32("LoggedUserId"))
                        .First().Email;
                    ViewData["userEmail"] = userEmail;
                    return Page();
                }
                catch(Exception)
                {
                    ViewData["userEmail"] = "NonValidUser";
                    return Page();
                }
            }
            else
            {
                return new RedirectToPageResult("Index");
            }
        }
        public UserSettingsPanelModel(AppDbContext _context)
        {
            context = _context;
        }
    }
}
