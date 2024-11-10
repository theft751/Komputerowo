using Model.EntityModels.Additional.ComputerParts;
using Model.EntityModels.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EntityModels.Products.ComputerParts
{
    public class Ram: Product
    {
        [NotMapped]
        public int TotalSize {get => SizePerChips*ChipsAmount;}
        public int SizePerChips { get; set; } //Gb
        public int ChipsAmount { get; set; }
        public int Frequency { get; set; }// MHz
        public bool Ligthing { get; set; }   
        public string RamType { get; set; }
    }
}
 