using DataBaseContext.Migrations;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace App.Pages.Shared.Components
{
    public class ReviewsAreaViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ICollection<ReviewDTO> reviewDTOs, int productId, int pageNumber)
        {
            ViewData["ProductId"] = productId;
            @ViewData["PageNumber"] = pageNumber;
            return View(reviewDTOs);
        }
    }
}