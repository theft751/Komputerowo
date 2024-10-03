using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Model.DataModel.Additional.Common;
using Model.DataModel.Main;
using System.Security.Cryptography;
using System.Text;

namespace App.Pages
{
    public class registerModel : PageModel
    {
        private ApplicationDbContext _ApplicationDbContext;
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
        public void OnGet()
        {

        }

        public void OnPost()
        { 
            Adress adress = new Adress();
            adress.PostCode = postCode; 
            adress.Voivodeship = voivodeship;
            adress.Town = town;
            adress.Street = street;
            adress.numberOfBuilding = numberOfBuilding;
            adress.ApartmentNumber = apartmentNumber;

            
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


            _ApplicationDbContext.Users.Add(user);
            _ApplicationDbContext.Adresses.Add(adress);
        }
        public registerModel(ApplicationDbContext _context)
        {
            ApplicationDbContext applicationDbContext = _context;
        }
    }
}
