﻿using Domain.EntityModels.Additional.ComputerParts;
using Domain.EntityModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.EntityModels.Products.ComputerParts
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
