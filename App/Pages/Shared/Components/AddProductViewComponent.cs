using Microsoft.AspNetCore.Mvc;

namespace App.Pages.Shared.Components
{
    public class AddProductViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
