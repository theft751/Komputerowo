using DataBaseContext;
using Domain.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Domain.EntityModels.Additional.ComputerParts;
using Domain.EntityModels.Main;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;
using System.Runtime.InteropServices;

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
        public override IActionResult OnGetEdit(int id)
        {
            
                DiskDrive product = context.DiskDrives.Find(id);

                DiskSize = product.DiskSize;
                ReadSpeed = product.ReadSpeed;
                WriteSpeed = product.WriteSpeed;
                DiskDriveInterface = product.DiskDriveInterface;
                DiskDriveType = product.DiskDriveType;

                setProductEssentialPropertiesOnEdit(id);
                return Page();
        }

            public AddOrEditDiskDriveModel(AppDbContext _context)
            : base(_context) { }
    }
}
