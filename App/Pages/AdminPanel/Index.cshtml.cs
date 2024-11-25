using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Dynamic;

namespace App.Pages.AdminPanel
{
    public class IndexModel : AdminPanelPageModel
    {
        public IActionResult OnGet()
        {
            return AdminPage();
        }
        public IndexModel(AppDbContext _context)
            : base(_context) { }
    }
}
