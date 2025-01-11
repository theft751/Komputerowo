using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace App.Pages
{
    public class OrderCompletedModel : PageModel
    {
        AppDbContext context {  get; set; }
        public string AcountNumber { get; set; }
        public string OrderNumber { get; set; }
        public void OnGet(string orderNumber)
        {
            OrderNumber = orderNumber;
            AcountNumber = context.BankAcountNumber.FirstOrDefault().Number; 
        }
        public OrderCompletedModel(AppDbContext _context)
        {
            context = _context;
        }
        
    }
}
