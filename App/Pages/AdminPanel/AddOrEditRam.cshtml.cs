using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.EntityModels.Main;
using Model.EntityModels.Products.ComputerParts;

namespace App.Pages.AdminPanel
{
    public class AddOrEditRamModel : AddOrEditProductModel
    {
        //Ram properties
        [BindProperty]
        public int SizePerChips { get; set; } //Gb

        [BindProperty]
        public int ChipsAmount { get; set; }

        [BindProperty]
        public int Frequency { get; set; }// MHz

        [BindProperty]
        public bool Ligthing { get; set; }

        [BindProperty]
        public string RamType { get; set; }

        public override IActionResult OnPost()
        {
            Ram product = new Ram();

            //set properties inherited from product 
            setProductEssentialProperties(product); ;

            //Ram properties
            product.SizePerChips = SizePerChips;
            product.ChipsAmount = ChipsAmount;
            product.Frequency = Frequency;
            product.Ligthing = Ligthing;
            product.RamType = RamType;

            context.Rams.Add(product);
            context.SaveChanges();
            return Page();
        }
        public AddOrEditRamModel(AppDbContext _context)
            : base(_context) { }
    }
}
