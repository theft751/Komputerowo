using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Model.DataModel.Main;

namespace App.Pages.AdminPanel
{
    public class EditProducerModel : PageModel
    {
        AppDbContext context { get; set; }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string Name { get; set; }

        public IActionResult OnGet(int _id, string _name)
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
                        return new RedirectToPageResult("Index");
                    }
                }
                catch
                {
                    return new RedirectToPageResult("Error");
                }            }
            else
            {
                return new RedirectToPageResult("Index");
            }    
            */
            Id = _id;
            Name = _name;
            return Page();
        }
        public IActionResult OnPost() 
        {
            try
            { 
                Producer producer = context.Producers.Where(x=>x.Id == Id).First();
                producer.Name = Name;
                context.SaveChanges();
                return new RedirectToPageResult("/AdminPanel/Producers");
            }
            catch
            {
                return new RedirectToPageResult("/Error");
            }
        }
        public EditProducerModel(AppDbContext _context) 
        {
            context = _context;
        }

    }
}
