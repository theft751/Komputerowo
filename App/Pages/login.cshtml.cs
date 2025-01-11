using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.EntityModels.Additional.Common;
using Domain.EntityModels.Main;
using System.Security.Cryptography;
using System.Text;

namespace App.Pages
{
    public class loginModel : PageModel
    {
        private AppDbContext context;
        [BindProperty]
        public string email { get; set; }

        [BindProperty]
        public string password { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("isLogged") == 1)
            {
                return new RedirectToPageResult("/Index");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            User FoundUser = context.Users.FirstOrDefault(x => x.Email == email);
            string foundPassword = "";
            string foundEmail = "";

            if (FoundUser != null)
            {
                foundEmail = FoundUser.Email;
                foundPassword = FoundUser.Password;
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    string hashedPassword = Convert.ToBase64String(hashBytes);
                    if (hashedPassword == foundPassword) {
                        HttpContext.Session.SetInt32("isLogged", 1);
                        HttpContext.Session.SetInt32("isUserAdmin", FoundUser.UserType == UserType.Admin ? 1:0);
                        HttpContext.Session.SetInt32($"LoggedUserId", FoundUser.Id);
                        return new RedirectToPageResult("Index");
                    }
                }

            }
            TempData["loginMessage"] = "Nieprawid³owe danie logowania";
            return Page();
    
        }
        public loginModel(AppDbContext _context) 
        {
                context = _context;
        }
    }
}
