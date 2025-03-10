﻿using Domain.EntityModels.Additional.ComputerParts;
using Domain.EntityModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityModels.Products.ComputerParts
{
    public class PowerSupply:Product
    {
        public int MaximalPower {  get; set; } // In Watts
        public string Certyficate { get; set; }
        public string PowerSupplyFormat {  get; set; } 
        public string Efficiency { get; set; }
        public string Connectors { get; set; }
        public string PowerSupplyProtectorsFeatures { get; set; }
    }
}
