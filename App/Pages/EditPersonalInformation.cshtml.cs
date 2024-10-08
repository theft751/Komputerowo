using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public EditPersonalInformationModel(AppDbContext _context)
        {
            context = _context;
        }
        
    }
}
