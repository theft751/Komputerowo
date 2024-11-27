using Microsoft.AspNetCore.Mvc;

namespace App.Pages.Shared.Components
{
    public class ImagesAreaViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string requestPath, ICollection<int> bonusProductImagesId, int productId)
        {
            ViewData["MainImageUrl"] = Url.Page($"{requestPath}", "MainImage", new { productId = productId } );
            
            List<(string Url, int Id)> imagesData = new List<(string Url, int Id)>();
            
            foreach (var imageId in bonusProductImagesId)
                imagesData
                    .Add (
                        new (
                            Url.Page($"{requestPath}", "BonusImage",
                            new { imageId = imageId }), 
                            imageId
                            ) 
                        );
            
            return View(imagesData);
        }
    }
}
