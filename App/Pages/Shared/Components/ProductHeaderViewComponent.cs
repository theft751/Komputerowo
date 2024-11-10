using Microsoft.AspNetCore.Mvc;
using Model.EntityModels.Additional.Common;
using Domain.ViewModels; 
namespace App.Pages.Shared.Components
{
    public class ProductHeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string product, 
            string producer, int rate, int reviewsAmount, int productId, ProductType productType)
        {
            return View(
                new ProductHeaderVm
                (
                    product,
                    producer, 
                    rate,
                    reviewsAmount,
                    productId,
                    productType
                )
            );
        }
    }
}
