using Microsoft.AspNetCore.Mvc;

namespace App.Pages.Shared.Components
{
    public class ImagesAreaViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ICollection<int> bonusProductImagesId, int productId)
        {
            ViewData["MainImageUrl"] = Url.Page($"{HttpContext.Request.Path}", "MainImage", new { productId = productId } );
            
            List<(string Url, int Id)> imagesData = new List<(string Url, int Id)>();
            
            foreach (var imageId in bonusProductImagesId)
                imagesData
                    .Add (
                        new (
                            Url.Page($"{HttpContext.Request.Path}", "BonusImage",
                            new { imageId = imageId }), 
                            imageId
                            ) 
                        );
            
            return View(imagesData);
        }
    }
}
