using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Domain.DTO;

namespace App.Pages.Shared.Components
{
    record ProductDataRecord (string Product, string Category, string Producer, int Rate, int ReviewsAmount);
    public class ProductHeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string product, string category, string producer, int rate, int reviewsAmount)
        {
            ViewBag.Product = product;
            ViewBag.Category = category;
            ViewBag.Producer = producer;
            ViewBag.Rate = rate;
            ViewBag.RatesCount = reviewsAmount;
            return View(
                new ProductDataRecord
                (
                    product, 
                    category,
                    producer, 
                    rate,
                    reviewsAmount
                )
                );
        }
    }
}
