using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.EntityModels.Additional.Common;
using Domain.EntityModels.Main;

namespace App.Pages.AdminPanel
{
    public abstract class AdminPanelPageModel :PageModel
    {
        protected AppDbContext context { get; set; }
        public IActionResult AdminPage()
        {      
            if (isUserAdmin)
            {
                return Page();
            }
            else
            {
                return new RedirectToPageResult("/Index");
            }

        }
        protected bool isUserAdmin
        {
            get
            {
                if (HttpContext.Session.GetInt32("isLogged") == 1)
                {
                    try
                    {
                        User user =
                            context
                            .Users
                            .Where(x => x.Id == HttpContext.Session.GetInt32("LoggedUserId"))
                            .First();
                        if (user.UserType == UserType.Admin)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        throw new Exception("Connection to database cannot be realised");
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        public AdminPanelPageModel(AppDbContext _context)
        {
            context = _context;
        }

    }
}
