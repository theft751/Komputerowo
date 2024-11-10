using DataBaseContext;
using Domain.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Model.EntityModels.Additional.ComputerParts;
using Model.EntityModels.Main;
using Model.EntityModels.Products.ComputerParts;
using Model.EntityModels.Products.OtherDevices;

namespace App.Pages.AdminPanel
{
    public class AddOrEditDiskDriveModel : AddOrEditProductModel
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
            DiskDrive product = OperationMode == OperationMode.Add ? new DiskDrive() : context.DiskDrives.Find(Id);

            //set properties inherited from product 
            setProductEssentialProperties(product); ;

            //DiskDrive properties 
            product.DiskSize = DiskSize;
            product.ReadSpeed = ReadSpeed;
            product.WriteSpeed = WriteSpeed;
            product.DiskDriveInterface = DiskDriveInterface;
            product.DiskDriveType = DiskDriveType;

            if (OperationMode == OperationMode.Add)context.DiskDrives.Add(product);
            context.SaveChanges();
            return Page();
        }


        public AddOrEditDiskDriveModel(AppDbContext _context)
            : base(_context) { }
    }
}
