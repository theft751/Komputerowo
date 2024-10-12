using Model.DataModel.Additional.ComputerParts;
using Model.DataModel.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel.Products.ComputerParts
{
    public class DiskDrive: Product
    {
        public int DiskSize { get; set; } = 0; //In GB
        public int ReadSpeed { get; set; } = 0; //In Mb/s
        public int WriteSpeed { get; set; } = 0; //In Mb/s
        public DiskDriveType DiskDriveType { get; set; }   
        public string DiskDriveInterface { get; set; }
    }
}
