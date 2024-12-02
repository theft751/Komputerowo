using DataBaseContext;
using Domain.AppModel;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App.Pages.AdminPanel
{
    public class AddOrEditKeyboardModel : AddOrEditProductModel
    {
        [BindProperty]
        public string SwitchType { get; set; } //For example mechanical, membrane, hybrid etc.

        [BindProperty]
        public string Connectivity { get; set; } //for example usb, or bluetooth or 2.4 GHz, also can has info about wire length

        [BindProperty]
        public string Destination { get; set; } //for example to office or for gamers

        [BindProperty]
        public string Profile { get; set; } ////Low-profile or high-profile or other one

        [BindProperty]
        public bool Lighting { get; set; }

        [BindProperty]
        public bool NumericKeypad { get; set; }
        public AddOrEditKeyboardModel(AppDbContext _context)
            : base(_context) { }

        public override IActionResult OnPost()
        {
            Keyboard product = OperationMode == OperationMode.Add ? new Keyboard() : context.Keyboards.Find(Id);

            //set properties inherited from product 
            setProductEssentialProperties(product); ;


            //GraphicCard properties
            product.SwitchType = SwitchType;
            product.Connectivity = Connectivity;
            product.Destination = Destination;
            product.Profile = Profile;
            product.Lighting = Lighting;
            product.NumericKeypad = NumericKeypad;

            if (OperationMode == OperationMode.Add) context.Keyboards.Add(product);
            context.SaveChanges();
            return Page();
        }


        public override IActionResult OnGetEdit(int id)
        {
            Keyboard product = context.Keyboards.Find(id);

            //GraphicCard properties
            product.SwitchType = SwitchType;
            product.Connectivity = Connectivity;
            product.Destination = Destination;
            product.Profile = Profile;
            product.Lighting = Lighting;
            product.NumericKeypad = NumericKeypad;

            setProductEssentialPropertiesOnEdit(id);
            return Page();
        }
    }
}
