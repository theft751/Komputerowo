using Domain.EntityModels.Additional.ComputerParts;
using Domain.EntityModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityModels.Products.ComputerParts
{

    public class Case:Product
    {
        public string MotherBoardFormats { get; set; }

        public string PowerSupplyFormat { get; set; }

        public CaseType CaseType { get; set; }
    }
}
