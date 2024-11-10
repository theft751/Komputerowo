using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Model.EntityModels.Additional.Common;
using Model.EntityModels.Main;
using System.Security.Cryptography;
using System.Text;

namespace App.Pages
{
    public class registerModel : PageModel
    {
        private AppDbContext context;

        [BindProperty]
        public string email { get; set; }
        
        [BindProperty]
        public string password { get; set; }

        [BindProperty]
        public string repeatPassword { get; set; }

        [BindProperty]
        public string firstName { get; set; }

        [BindProperty]
        public string lastName { get; set; }

        [BindProperty]
        public string phoneNumber { get; set; }

        [BindProperty]
        public string postCode { get; set; }

        [BindProperty]
        public Voivodeship voivodeship { get; set; }

        [BindProperty]
        public string town { get; set; }

        [BindProperty]
        public string street { get; set; }

        [BindProperty]
        public string numberOfBuilding { get; set; }

        [BindProperty]
        public string apartmentNumber { get; set; }

        public IActionResult OnGet()
        {
            ViewData["badPasswordInfo"] = "";
            ViewData["badEmailInfo"] = "";
            if (HttpContext.Session.GetInt32("isLogged") == 1)
                return RedirectToPage("Index");
            else
                return Page();
        }

        public IActionResult OnPost()
        {
            var foundEmail = context.Users.Where(x=>x.Email == email).FirstOrDefault();
            if (foundEmail == null)
            { 
                if (password == repeatPassword)
                {
                    try
                    {
                        Adress adress = new Adress();
                        adress.PostCode = postCode;
                        adress.Voivodeship = voivodeship;
                        adress.Town = town;
                        adress.Street = street;
                        adress.NumberOfBuilding = numberOfBuilding;
                        adress.ApartmentNumber = apartmentNumber != null ? apartmentNumber : "";

                        User user = new User();
                        user.Email = email;
                        user.FirstName = firstName;
                        user.LastName = lastName;
                        user.PhoneNumber = phoneNumber;
                        user.UserType = UserType.NormalUser;
                        user.Adress = adress;

                        //Password hashing
                        using (SHA256 sha256 = SHA256.Create())
                        {
                            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                            string hashedPassword = Convert.ToBase64String(hashBytes);
                            user.Password = hashedPassword;
                        }


                        context.Users.Add(user);
                        context.Adresses.Add(adress);
                        context.SaveChanges();
                        return RedirectToPage("/RegisterCompleted");
                    }
                    catch (Exception)
                    {
                        return new RedirectToPageResult("/Error");
                    }
                }
                else
                {

                    ViewData["badPasswordInfo"] = "Hasla nie sa identyczne";
                    return Page();
                }
            }
            else
            {
                ViewData["badEmailInfo"] = "Ten adres email jest ju¿ zajêty";
                return Page();
            }
            
        }
        public registerModel(AppDbContext _context)
        {

            context = _context;
        }
    }
}
