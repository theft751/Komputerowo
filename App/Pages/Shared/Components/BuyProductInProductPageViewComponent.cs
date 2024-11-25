using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Domain.EntityModels.Additional.Common;

namespace App.Pages.Shared.Components
{
    public class BuyProductInProductPageViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int productId,Availability availability, 
            int productAmount, UserType userType, decimal price, int pageNumber)
        {
            BuyProductInProductPageVm buyProductInProductPageVm = 
                new BuyProductInProductPageVm(productId,availability, productAmount, userType, price, pageNumber);
           
            return View(buyProductInProductPageVm);
        }
    }
}
