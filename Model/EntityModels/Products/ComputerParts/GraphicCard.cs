﻿using Domain.EntityModels.Additional.ComputerParts;
using Domain.EntityModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.EntityModels.Products.ComputerParts
{
    public class GraphicCard : Product
    {
        public string Gpu{ get; set; }
        public string GraphicCardSerie { get; set; }
        public string MemoryType {  get; set; }
        public string ConnectorType { get; set; }
        public string OutputTypes { get; set; }
        public int MemorySize { get; set; }
        public int MemoryBus {  get; set; } //For example 256 bits
        public int CoreColck { get; set; }
        public int MemoryClock { get; set; }
        public bool Litghting { get; set; }
        public bool RayTracing { get; set; }
    }
}
