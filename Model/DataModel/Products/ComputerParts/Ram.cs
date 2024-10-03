using Model.DataModel.Additional.ComputerParts;
using Model.DataModel.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel.Products.ComputerParts
{
    public class Ram: Product
    {
        public int TotalSize {get => SizePerChips*ChipsAmount;}
        public int SizePerChips { get; set; } //Gb
        public int ChipsAmount { get; set; }
        public int Frequency { get; set; }// MHz
        public bool Ligthing { get; set; }
        
        public RamType RamType { get; set; }
    }
}
