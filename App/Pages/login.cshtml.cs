using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DataModel.Main;
using System.Security.Cryptography;
using System.Text;

namespace App.Pages
{
    public class loginModel : PageModel
    {
        private ApplicationDbContext context;
        [BindProperty]
        public string email { get; set; }

        [BindProperty]
        public string password { get; set; }

        public IActionResult OnPost()
        {
            User FoundUser = context.Users.Where(x => x.Email == email).FirstOrDefault();
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
                        HttpContext.Session.SetInt32($"LoggedUserId", FoundUser.Id);
                        return Page();
                    }
                }

            }
            return Page();
    
        }
        public loginModel(ApplicationDbContext _context) 
        {
                context = _context;
        }
    }
}
