using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Model.DataModel.Additional.ComputerParts;
using Model.DataModel.Main;
using Model.DataModel.Products.ComputerParts;

namespace App.Pages.AdminPanel
{
    public class AddDiskDriveModel : AddProductModel
    {
        [BindProperty]
        public int DiskSize { get; set; } = 0; //In GB

        [BindProperty]
        public int ReadSpeed { get; set; } = 0; //In Mb/s

        [BindProperty]
        public int WriteSpeed { get; set; } = 0; //In Mb/s

        [BindProperty]
        public string DiskDriveInterface { get; set; }

        [BindProperty]
        public DiskDriveType DiskDriveType { get; set; }


        public override IActionResult OnPost()
        {
            DiskDrive product = new DiskDrive();

            //set properties inherited from product 
            setProductEssentialProperties(product); ;

            //DiskDrive properties 
            product.DiskSize = DiskSize;
            product.ReadSpeed = ReadSpeed;
            product.WriteSpeed = WriteSpeed;
            product.DiskDriveInterface = DiskDriveInterface;
            product.DiskDriveType = DiskDriveType;

            context.DiskDrives.Add(product);
            context.SaveChanges();
            return Page();
        }


        public AddDiskDriveModel(AppDbContext _context)
            : base(_context) { }
    }
}
