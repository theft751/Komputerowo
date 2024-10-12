using Model.DataModel.Additional.ComputerParts;
using Model.DataModel.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel.Products.ComputerParts
{
    public class Case:Product
    {

        public string MotherBoardFormats { get; set; }

        public string PowerSupplyFormat { get; set; }

        public CaseType CaseType { get; set; }
    }
}
