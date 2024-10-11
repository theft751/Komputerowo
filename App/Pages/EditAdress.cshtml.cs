using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DataModel.Additional.Common;
using Model.DataModel.Main;

namespace App.Pages
{
    public class EditAdressModel : PageModel
    {
        AppDbContext context {  get; set; }

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

        public EditAdressModel(AppDbContext _context)
        {
            context = _context;
        }

        public IActionResult OnGet()
        {
            try
            {
                if (HttpContext.Session.GetInt32("isLogged") == 1)
                {
                    Adress userAdress =
                        context
                        .Users
                        .Where(x => x.Id == HttpContext.Session.GetInt32("LoggedUserId"))
                        .First().Adress;
                    postCode = userAdress.PostCode;
                    voivodeship = userAdress.Voivodeship;
                    town = userAdress.Town;
                    street = userAdress.Street;
                    numberOfBuilding = userAdress.NumberOfBuilding;
                    apartmentNumber = userAdress.ApartmentNumber; 
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
        public IActionResult OnPost()
        {
            Adress userAdress =
                context
                .Users
                .Where(x => x.Id == HttpContext.Session.GetInt32("LoggedUserId"))
                .First().Adress;
            userAdress.PostCode = postCode;
            userAdress.Voivodeship = voivodeship;
            userAdress.Town = town;
            userAdress.Street = street;
            userAdress.NumberOfBuilding = numberOfBuilding;
            userAdress.ApartmentNumber = apartmentNumber == null ?"":apartmentNumber;
            context.SaveChanges();
            return new RedirectToPageResult("DataUpdatedSuccessfully");
        }
    }
}
