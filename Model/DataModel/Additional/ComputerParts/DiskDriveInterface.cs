using Model.DataModel.Products.ComputerParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel.Additional.ComputerParts
{
    public class DiskDriveInterface
    {
        int Id {  get; set; }
        public string Name { get; set; } //For example M2, SATA, ATA
        
        //Navigation properties
        ICollection<DiskDrive> DiskDrives { get; set; }
    }
}
