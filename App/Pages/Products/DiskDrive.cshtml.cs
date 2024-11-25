using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;
using System.Runtime.InteropServices;
using Domain.EntityModels.Additional.ComputerParts;

namespace App.Pages.Products
{
    public class DiskDriveModel : ProductPageModel
    {
        public int DiskSize { get; set; } = 0; //In GB
        public int ReadSpeed { get; set; } = 0; //In Mb/s
        public int WriteSpeed { get; set; } = 0; //In Mb/s
        public DiskDriveType DiskDriveType { get; set; }
        public string DiskDriveInterface { get; set; }

        protected override void initializeEssentialProductProperties(int productId)
        {
            //Initialize inherited properties from ProductModel
            base.initializeEssentialProductProperties(productId);

            DiskDrive diskDrive = context.DiskDrives.Find(productId);

            //Initialize properties specific for DesktopComputer
            DiskSize = diskDrive.DiskSize;
            ReadSpeed = diskDrive.ReadSpeed;
            WriteSpeed = diskDrive.WriteSpeed;
            DiskDriveType = diskDrive.DiskDriveType;
            DiskDriveInterface = diskDrive.DiskDriveInterface;
        }


        DiskDriveModel(AppDbContext _context)
            : base(_context)
        {
        }
    }
}
