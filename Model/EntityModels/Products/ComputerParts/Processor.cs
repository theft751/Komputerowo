﻿using Domain.EntityModels.Additional.ComputerParts;
using Domain.EntityModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityModels.Products.ComputerParts
{
    public class Processor: Product
    {
        public int Cores { get; set; } //Amount of cores
        public int Threads { get; set; }
        public int Frequency { get; set; } //Frequency per Core
        public int CacheSize { get; set; } //Mb
        public bool IntegratedGpu {  get; set; }
        public bool CoolerIncluded { get; set; }

        public string ProcessorSocket{ get; set; }
        public string ProcessorSerie{ get; set; }
    }
}
