using Azure.Identity;
using DataBaseContext;
using Domain.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Model.EntityModels.Additional.Common;
using Model.EntityModels.Main;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Dynamic;

namespace App.Pages.Products
{

    public abstract class ProductModel : PageModel
    {
        protected AppDbContext context { get; set; }

        public int ProductAmount { get; set; }

        public UserType UserType { get; set; }

        public const int ReviewsPerPage = 10;

        public int AverageRate { get => context.Products.Where(x => x.Id == ProductId).FirstOrDefault().AverageRate; }

        public int ReviewsPageAmount
        {
            get
            {
                int result;
                int count = context.Reviews.Count();
                if (count % ReviewsPerPage == 0)
                    result = count / ReviewsPerPage;
                else
                    result = count / ReviewsPerPage+1;
                return result;
            }
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string AdditionalInfo { get; set; }

        public ProductType ProductType { get; set; } //dyscryminator

        public int ReviewsAmount { get=> context.Reviews.Where(x=>x.UserId==ProductId).Count(); }
        public int GuarantyTime { get; set; } //Months
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Producer { get; set; }
        public Availability Availability { get; set; }
        public int PageNumber { get; set; }

        public ICollection<int> BonusProductImagesId { get; set; }
        public ICollection<ReviewData> ReviewsData { get; set; } = new List<ReviewData>();

        protected virtual void initializeEssentialProductProperties(int id)
        {
            Product p = context.Products.Where(x => x.Id == id).First();
            
            //Setting title of page
            ViewData["Title"] = p.Name;
            
            //seting public properties
            ProductId = id;
            AdditionalInfo = p.AdditionalInfo;
            Color = p.Color;
            ProductType = p.ProductType;
            GuarantyTime = p.GuarantyTime;
            Name = p.Name;  
            Description = p.Description;
            Price = p.Price;
            Producer = p.Producer;
            Availability = p.Availability;
            ProductAmount = p.Amount;

            if (HttpContext.Session.GetInt32("isLogged") == 1)
            {
                UserType = context.Users.Find(HttpContext.Session.GetInt32("LoggedUserId")).UserType;
            }   
            else
                UserType = UserType.NormalUser;

            initializeReviewDTOs();

            foreach (var image in p.BonusImages)
                BonusProductImagesId.Add(image.Id);

        }

        //Static http requests
        public IActionResult OnGetMainImage(int productId)
        {
            int mainProductImageId = context.Products.Where(x=>x.Id==productId).First().MainImageId;
            MainProductImage mainImage = context.MainProductImages.Where(x=>x.Id==mainProductImageId).First();
            return File(mainImage.ImageData, mainImage.ImageType);
        }
        public IActionResult OnGetBonusImage(int imageId)
        {
            BonusProductImage bonusProductImage = context.BonusProductImages.Where(x=>x.Id== imageId).First();

            return File(bonusProductImage.ImageData, bonusProductImage.ImageType);
        }

        //Interactive http requests
        public IActionResult OnPostAddReview(int productId, string reviewContent, int pageNumber, int rate)
        {
            if (HttpContext.Session.GetInt32("isLogged") == 1)
            {
                try
                {
                    Review review = new Review();
                    review.ReleaseDate = DateTime.Now;
                    review.Text = reviewContent;
                    review.UserId = HttpContext.Session.GetInt32("LoggedUserId").Value;
                    review.ProductId = productId;
                    review.Rate = rate;
                    context.Reviews.Add(review);
                    context.SaveChanges();
                    return OnGet(productId, pageNumber);
                }
                catch
                {
                    return new RedirectToPageResult("/Error");
                }
            }
            else
                return new RedirectToPageResult("/Error");
        }
        public IActionResult OnPostReviewDelete(int reviewId, int productId, int pageNumber=1)
        {
            if(HttpContext.Session.GetInt32("isLogged")==1)
            {
                if (HttpContext.Session.GetInt32("LoggedUserId") == context.Reviews.Where(x=>x.Id==reviewId).First().UserId)
                {
                    context.Reviews.Remove(context.Reviews.Where(x => x.Id == reviewId).First());
                    context.SaveChanges();
                }
                
            }
            return OnGet(productId, pageNumber);
        }


        public abstract IActionResult OnGet(int productId, int pageNumber);

        private void initializeReviewDTOs()
        {
            int skip = (PageNumber - 1) * ReviewsPerPage;
            int skipLast = 0;

            context.Reviews
                .Skip(skip)
                .Take(ReviewsPerPage)
                .ToList()
                .ForEach(
                    review =>
                        ReviewsData.Add(
                            new ReviewData(
                                Id: review.Id,
                                Username: review.User.FirstName,
                                UserId: review.UserId,
                                Content: review.Text,
                                Rate: review.Rate,
                                ReleaseDate: review.ReleaseDate
                                )
                            )
                );
        }

        public IActionResult OnPostEditReview(int productId, int reviewId, int pageNumber, string reviewContent, int rate)
        {
            
            try
            {
                Review? review = context.Reviews.Find(reviewId);
                if(HttpContext.Session.GetInt32("isLogged") == 1)
                {
                    if (HttpContext.Session.GetInt32("LoggedUserId") == review.UserId)
                    {
                        review.Text = reviewContent;
                        review.Rate = rate;
                        context.SaveChanges();
                    }
                }
                return OnGet(productId, pageNumber);
            }
            catch 
            {
                return new RedirectToPageResult("/Error"); 
            }

            
        }

        public ProductModel (AppDbContext _context)
        {
            context = _context;
            
            BonusProductImagesId = new List<int>();            
        }
    }
}
