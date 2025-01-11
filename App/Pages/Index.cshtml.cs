using DataBaseContext;
using Domain.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext context;

        const int productPerCategory = 4;

        //Computers
        public IEnumerable<int> DesktopComputerIds {  get; set; }
        public IEnumerable<int> LaptopIds { get; set; }

        //Peripherials;
        public IEnumerable<int> MonitorIds {  get; set; }
        public IEnumerable<int> MouseIds { get; set; }
        public IEnumerable<int> KeyboardIds { get; set; }
        public IEnumerable<int> PrinterIds { get; set; }

        //Computer Amount properties
        public int DesktopComputersAmount {  get; set; }
        public int LaptopsAmount { get; set; }

        //Peripherials Amount properties
        public int MonitorsAmount { get; set; }
        public int MousesAmount { get; set; }
        public int KeyboardsAmount { get; set; }
        public int PrintersAmount { get; set; }


        public IActionResult OnGet()
        {
            //Computers

            DesktopComputerIds = 
                context.DesktopComputers
                .ToList()
                .OrderByDescending(x=>x.AverageRate)
                .Take(productPerCategory)
                .Select(x => x.Id)
                .ToList();
            DesktopComputersAmount=context.DesktopComputers.Count();


            LaptopIds =
                context.Laptops
                .ToList()
                .OrderByDescending(x=>x.AverageRate)
                .Take(productPerCategory)
                .Select(x => x.Id)
                .ToList();
            LaptopsAmount=context.Laptops.Count();

            //Peripherials

            MonitorIds =
                context.Monitors
                .ToList()
                .OrderByDescending(x=>x.AverageRate)
                .Take(productPerCategory)
                .Select(x => x.Id)
                .ToList();
            MonitorsAmount = context.Monitors.Count();

            MouseIds =
                context.Mouses
                .ToList()
                .OrderByDescending(x=>x.AverageRate)
                .Take(productPerCategory)
                .Select(x => x.Id)
                .ToList();
            MousesAmount = context.Mouses.Count();

            KeyboardIds =
                context.Keyboards
                .ToList()
                .OrderByDescending(x=>x.AverageRate)
                .Take(productPerCategory)
                .Select(x => x.Id)
                .ToList();
            KeyboardsAmount = context.Keyboards.Count();

            PrinterIds =
                context.Printers
                .ToList()
                .OrderByDescending(x=>x.AverageRate)
                .Take(productPerCategory)
                .Select(x => x.Id)
                .ToList();
            PrintersAmount = context.Keyboards.Count();

            return Page();
        }
        public IActionResult OnPostAddToBasket(int productId, int amount)
        {
            List<BasketElement> basket;



            try
            {
                basket =
                JsonSerializer
                .Deserialize<List<BasketElement>>(
                    Request.Cookies["Basket"]
                    );
            }
            catch
            {
                basket = new List<BasketElement>();
            }

            if (basket.Where(x => x.ProductId == productId).Any())
            {
                basket.FirstOrDefault(x => x.ProductId == productId).Amount += amount;
            }
            else
            {
                BasketElement basketElement = new BasketElement()
                {
                    ProductId = productId,
                    Amount = amount
                };
                basket.Add(basketElement);
            }
            
            string basketJson = JsonSerializer .Serialize( basket );

            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };

            Response.Cookies.Append("Basket", basketJson, cookieOptions);

            return OnGet();
        }
        public IndexModel(AppDbContext _context)
        {
            context = _context;
        }
    }
}