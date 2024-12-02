using DataBaseContext;
using Domain.EntityModels.Products.OtherDevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.AppModel;
namespace App.Pages.AdminPanel
{
    public class AddOrEditMouseModel : AddOrEditProductModel
    {
        [BindProperty]
        public int Dpi { get; set; }

        [BindProperty]
        public string Profile { get; set; } //Lefthanded or righthanded

        [BindProperty]
        public string Connectivity { get; set; } //for example usb, or bluetooth or 2.4 GHz, also can has info about wire length

        [BindProperty]
        public string Destination { get; set; } //for example to office or for gamers

        [BindProperty]
        public int ButtonsAmount { get; set; }

        [BindProperty]
        public string SensorType { get; set; } // Optical, Laser

        [BindProperty]
        public bool Lighting { get; set; }

        public AddOrEditMouseModel(AppDbContext _context)
            : base(_context) { }
        public override IActionResult OnPost()
        {
            Mouse product = OperationMode == OperationMode.Add ? new Mouse() : context.Mouses.Find(Id);

            //set properties inherited from product 
            setProductEssentialProperties(product); ;


            //Mouse properties
            product.SensorType = SensorType;
            product.ButtonsAmount = ButtonsAmount;
            product.Connectivity = Connectivity;
            product.Destination = Destination;
            product.Profile = Profile;
            product.Lighting = Lighting;


            if (OperationMode == OperationMode.Add) context.Mouses.Add(product);
            context.SaveChanges();
            return Page();
        }


        public override IActionResult OnGetEdit(int id)
        {
            Mouse product = context.Mouses.Find(id);
            
            //Mouse properties
            product.SensorType = SensorType;
            product.ButtonsAmount = ButtonsAmount;
            product.Connectivity = Connectivity;
            product.Destination = Destination;
            product.Profile = Profile;
            product.Lighting = Lighting;

            setProductEssentialPropertiesOnEdit(id);
            return Page();
        }
    }
}
