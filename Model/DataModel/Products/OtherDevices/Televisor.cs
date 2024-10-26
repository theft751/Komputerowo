﻿using Model.DataModel.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel.Products.OtherDevices
{
    public class Televisor: Product
    {
        public string Resolution { get; set; }
        public decimal ScreenDiagonal { get; set; } //inches
        public int ScreenRefreshRate { get; set; } //Hz
        
        public string ExternalPorts { get; set; }
        public bool hasSmartTv { get; set; }
        public string OperatingSystem { get; set; }
    }
}
