using DataBaseContext;
using Domain.AppModel;
using Domain.EntityModels.Additional.Common;
using Domain.EntityModels.Main;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace App.Pages
{
    public class DeliveryAdressModel : PageModel
    {
        AppDbContext context { get; set; }

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

        [BindProperty]
        public int defaultOrAnother {  get; set; }

        public string userPostCode;

        public Voivodeship userVoivodeship;

        public string userTown { get; set; }

        public string userStreet { get; set; }

        public string userNumberOfBuilding { get; set; }

        public string userApartmentNumber { get; set; }


        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("isLogged") == 0 || HttpContext.Session.GetInt32("isUserAdmin") == 1)
            {
                return new RedirectToPageResult("/Login");
            }
            int userId = (int)HttpContext.Session.GetInt32("LoggedUserId");
            var adress = context.Users.Find(userId).Adress;
            userPostCode = adress.PostCode;
            userVoivodeship = adress.Voivodeship;
            userTown = adress.Town;
            userStreet = adress.Street;
            userNumberOfBuilding = adress.NumberOfBuilding;
            userApartmentNumber = adress.ApartmentNumber;
            return Page();
        }
        public DeliveryAdressModel(AppDbContext _context)
        {
            context = _context;
        }
        public IActionResult OnPost()
        {
            ICollection<BasketElement> basketElements;
            basketElements = JsonSerializer
                .Deserialize<List<BasketElement>>(
                    Request.Cookies["Basket"]
                    );

            OrderAdress orderAdress = new OrderAdress();
            if (defaultOrAnother == 0)
            {
                UserAdress userAdress = context
                    .Users
                    .Find(
                        (int)HttpContext.Session.GetInt32("LoggedUserId")
                    )
                    .Adress;
               
                orderAdress.ApartmentNumber = userAdress.ApartmentNumber;
                orderAdress.Street = userAdress.Street;
                orderAdress.NumberOfBuilding = userAdress.NumberOfBuilding;
                orderAdress.PostCode = userAdress.PostCode;
                orderAdress.Town = userAdress.Town;
                orderAdress.Voivodeship = userAdress.Voivodeship;
            }
            else
            {
                orderAdress.ApartmentNumber = apartmentNumber;
                orderAdress.Street = street;
                orderAdress.NumberOfBuilding = numberOfBuilding;
                orderAdress.PostCode = postCode;
                orderAdress.Town = town;
                orderAdress.Voivodeship = voivodeship;
            }
            context.OrderAdresses.Add( orderAdress );
            context.SaveChanges();
            string orderNumber = "";

            for (int i = 0; i < 12; i++)
            {
                orderNumber += new Random().Next(0, 9).ToString();
            }

            Order order = new Order();
            order.RealisationDate = DateTime.Now;
            order.UserId = (int)HttpContext.Session.GetInt32("LoggedUserId");
            order.Number = orderNumber;
            order.Adress = orderAdress;
            order.Status = OrderStatus.InProgress;
            order.OrderDate = DateTime.Now;
            

            context.Orders.Add(order);
            context.SaveChanges();

            ICollection<OrderItem> orderItems =
                basketElements
                .Select(
                    basketElement =>
                    new OrderItem()
                    {
                        ProductId = basketElement.ProductId,
                        Amount = basketElement.Amount,
                        Order = order
                    })
                .ToList();

            context.OrderItems.AddRange(orderItems);
            context.SaveChanges();

            basketElements.Clear();

            string basketJson = JsonSerializer.Serialize(basketElements);

            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };

            Response.Cookies.Append("Basket", basketJson, cookieOptions);


            return new RedirectToPageResult("OrderCompleted", new { orderNumber = orderNumber });
        }
    }
}
