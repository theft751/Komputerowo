using DataBaseContext;
using Domain.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.EntityModels.Main;
using Domain.EntityModels.Products.ComputerParts;
using System.Threading;

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
            Ram product = OperationMode == OperationMode.Add ? new Ram(): context.Rams.Find(Id);

            //set properties inherited from product 
            setProductEssentialProperties(product); ;



            if(OperationMode == OperationMode.Add) context.Rams.Add(product);
            context.SaveChanges();
            return Page();
        }
        public AddOrEditRamModel(AppDbContext _context)
            : base(_context) { }


        public override IActionResult OnGetEdit(int id)
        {
            Ram product = context.Rams.Find(id);

            //Ram properties
            SizePerChips = product.SizePerChips;
            ChipsAmount = product.ChipsAmount;
            Frequency = product.Frequency;
            Ligthing = product.Ligthing;
            RamType = product.RamType;

            setProductEssentialPropertiesOnEdit(id);
            return Page();
        }
    }
}
