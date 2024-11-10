using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.EntityModels.Main;
using System.Security.Cryptography;
using System.Text;

namespace App.Pages
{
    public class  ChangePasswordModel : PageModel
    {
        [BindProperty]
        public string OldPassword { get; set; }

        [BindProperty]
        public string NewPassword { get; set; }

        [BindProperty]
        public string RepeatedNewPassword { get; set; }
        
        AppDbContext context;
        
        public IActionResult OnGet()
        {
            @ViewData["BadInputInfo"] = "";
            if (HttpContext.Session.GetInt32("isLogged") == 0)
                return new RedirectToPageResult("Index");
            else
                return Page();
        }
        public IActionResult OnPost()
        {
            User user =
                context.Users.
                Where(x => x.Id == HttpContext.Session.GetInt32("LoggedUserId"))
                .FirstOrDefault();
            string hashedCorrectOldPassword = user.Password ;
            string hashedNewPassword;
            string hashedRepeatedNewPassword;
            string hashededOldPassword;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(NewPassword));
                hashedNewPassword = Convert.ToBase64String(hashBytes);

                hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(RepeatedNewPassword));
                hashedRepeatedNewPassword = Convert.ToBase64String(hashBytes);

                
                hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(OldPassword));
                hashededOldPassword = Convert.ToBase64String(hashBytes);
            }
            if (hashedCorrectOldPassword == hashededOldPassword)
            {
                if (hashedNewPassword == hashedRepeatedNewPassword)
                {
                    user.Password = hashedNewPassword;
                    context.SaveChanges();
                    return new RedirectToPageResult("PasswordChangedSuccessfully");
                }
                else
                {
                    if (hashedCorrectOldPassword != OldPassword)
                    {
                        ViewData["OldPasswordInputInfo"] = "Podane has�o jest b��dne";
                    }
                    ViewData["NewPasswordInputInfo"] = "Has�a nie s� takie same";
                    return Page();
                }
            }
            else
            {
                if (hashedNewPassword != hashedRepeatedNewPassword)
                {
                    ViewData["NewPasswordInputInfo"] = "Has�a nie s� takie same";
                }
                ViewData["OldPasswordInputInfo"] = "Podane has�o jest b��dne";
                return Page();
            }


        }
        public ChangePasswordModel(AppDbContext _context)
        {
            context = _context;
        }
        
    }
}
