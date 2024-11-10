using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Model.EntityModels.Additional.Common;

namespace App.Pages.Shared.Components
{
    public class BuyProductInProductPageViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Availability availability, 
            int productAmount, UserType userType, decimal price)
        {
            BuyProductInProductPageVm buyProductInProductPageVm = 
                new BuyProductInProductPageVm(availability, productAmount, userType, price);
           
            return View(buyProductInProductPageVm);
        }
    }
}
