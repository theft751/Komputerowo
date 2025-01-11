using DataBaseContext;
using Domain.EntityModels.Main;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Dynamic;

namespace App.Pages.AdminPanel
{
    public class IndexModel : AdminPanelPageModel
    {
        [BindProperty]
        public string AcountNumber {  get; set; }
        public IActionResult OnGet()
        {
            AcountNumber = context.BankAcountNumber.FirstOrDefault().Number; 
            return AdminPage();
        }
        public IndexModel(AppDbContext _context)
            : base(_context) { }
    }
}
