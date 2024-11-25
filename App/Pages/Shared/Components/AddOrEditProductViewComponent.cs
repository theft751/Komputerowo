using Domain.AppModel;
using Microsoft.AspNetCore.Mvc;

namespace App.Pages.Shared.Components
{
    public class AddOrEditProductViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ProductPassData ProductPassData)
        {

            return View(ProductPassData);
        }
    }
}
