using DataBaseContext.Migrations;
using Domain.AppModel;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace App.Pages.Shared.Components
{

    public class ReviewsAreaViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ICollection<ReviewData> reviewsData, 
            int productId, int pageNumber, int reviewsAmount, int reviewsPageAmount)
        {
            ReviewAreaVm reviewAreaVm =
                new ReviewAreaVm(
                    ReviewsData: reviewsData,
                    ProductId: productId,
                    PageNumber: pageNumber,
                    ReviewsAmount: reviewsAmount,
                    ReviewsPageAmount: reviewsPageAmount
                    );

            return View(reviewAreaVm);
        }
    }
}