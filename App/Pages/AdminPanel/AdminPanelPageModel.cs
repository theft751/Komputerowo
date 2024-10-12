using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DataModel.Additional.Common;
using Model.DataModel.Main;

namespace App.Pages.AdminPanel
{
    public abstract class AdminPanelPageModel :PageModel
    {
        protected AppDbContext context { get; set; }
        public IActionResult OnGet()
        {      
            /*
            if (HttpContext.Session.GetInt32("isLogged") == 1)
            {
                try
                {
                User user = 
                    context
                    .Users
                    .Where(x=>x.Id==HttpContext.Session.GetInt32("LoggedUserId"))
                    .First();
                    if (user.UserType == UserType.Admin)
                    {
                        return Page();
                    }
                    else
                    {
                        return new RedirectToPageResult("/Index");
                    }
                }
                catch
                {
                    return new RedirectToPageResult("/Error");
                }            }
            else
            {
                return new RedirectToPageResult("/Index");
            }
            */
            return Page();

        }
        public AdminPanelPageModel(AppDbContext _context)
        {
            context = _context;
        }
    }
}
