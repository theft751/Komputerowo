using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Policy;

namespace App.Pages.Shared.Components
{
    public class LoggedUserEmailViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public LoggedUserEmailViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        { 
            string email;
            if (HttpContext.Session.GetInt32("isLogged") == 1)
                TempData["Display"] = _context.Users.Where(x => x.Id == HttpContext.Session.GetInt32("LoggedUserId")).First().Email;
            else
                TempData["Display"] = "NonValidUser";

            return View();
        }
    }
}
