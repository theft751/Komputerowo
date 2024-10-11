using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DataModel.Additional.Common;
using Model.DataModel.Main;

namespace App.Pages.AdminPanel
{
    public class ProducersModel : PageModel
    {
        AppDbContext context;
        public IList<Producer> Producers { get; set; }
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
                        .Where(x => x.Id == HttpContext.Session.GetInt32("LoggedUserId"))
                        .First();
                    if (user.UserType == UserType.Admin)
                    {
                        return Page();
                    }
                    else
                    {
                        return new RedirectToPageResult("Index");
                    }
                }
                catch
                {
                    return new RedirectToPageResult("Error");
                }
            }
            else
            {
                return new RedirectToPageResult("Index");
            }
            */
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            try
            { 
                Producer producer = context.Producers.Where(producer => producer.Id == id).First();
                context.Producers.Remove(producer);
                context.SaveChanges();
                Producers = context.Producers.OrderBy(x => x.Name).ToList();
                return Page();
            }
            catch
            {
                return new RedirectToPageResult("/Error");
            }
        }

        public ProducersModel(AppDbContext _context)
        {
            context = _context;
            Producers = context.Producers.OrderBy(x => x.Name).ToList();
        }
    }
}
