using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages
{
    public class UserSettingsPanelModel : PageModel
    {
        AppDbContext context; 
        public void OnGet()
        {
            try
            {
                string userEmail = 
                    context
                    .Users
                    .Where(x=>x.Id==HttpContext.Session.GetInt32("LoggedUserId"))
                    .First().Email;
                ViewData["userEmail"] = userEmail;
            }
            catch(Exception)
            {
                ViewData["userEmail"] = "NonValidUser";
            }
        }
        public UserSettingsPanelModel(AppDbContext _context)
        {
            context = _context;
        }
    }
}
