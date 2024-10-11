using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DataModel.Additional.Common;
using Model.DataModel.Main;
using System.Drawing;

namespace App.Pages.AdminPanel
{
    public class AddProductModel : PageModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AdditionalInfo { get; set; }
        public string Color { get; set; }
        public int Amount { get; set; }
        public int GuarantyTime { get; set; } //Months
        public decimal Price { get; set; }
        public Image MainImage { get; set; }
        public  ICollection<BonusProductImage> BonusImages { get; set; }
        public virtual Producer Producer { get; set; }
        public void OnGet()
        {
        }
    }
}
