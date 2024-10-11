using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Model.DataModel.Main;

namespace App.Pages
{
    public class EditPersonalInformationModel : PageModel
    {
        public AppDbContext context { get; set; }
        [BindProperty]
        public string firstName { get; set; }

        [BindProperty]
        public string lastName { get; set; }

        [BindProperty]
        public string phoneNumber { get; set; }

        public IActionResult OnGet()
        {
            try
            {
                if (HttpContext.Session.GetInt32("isLogged") == 1)
                {
                    User user =
                        context
                        .Users
                        .Where(x => x.Id == HttpContext.Session.GetInt32("LoggedUserId"))
                        .First();
                    firstName = user.FirstName;
                    lastName = user.LastName;
                    phoneNumber = user.PhoneNumber;
                    return Page();
                }
                else
                {
                    return new RedirectToPageResult("Index");
                }
            }
            catch
            {
                return new RedirectToPageResult("/Error");
            }
        }
        public IActionResult OnPost()
        {
            User user = 
                context
                .Users
                .Where(x=>x.Id == HttpContext.Session.GetInt32("isLogged"))
                .First();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.PhoneNumber = phoneNumber;
            context.SaveChanges();
            return new RedirectToPageResult("/DataUpdatedSuccessfully");
        }
        public EditPersonalInformationModel(AppDbContext _context)
        {
            context = _context;
        }
        
    }
}
