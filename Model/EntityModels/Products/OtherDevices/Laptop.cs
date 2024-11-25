using Domain.EntityModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityModels.Products.OtherDevices
{
    public class Laptop :Product
    {
        public string Processor {  get; set; }
        public int RamSize {  get; set; } //GB
        public string RamType { get; set; }
        public int DiskSize { get; set; }
        public string DiskType { get; set; }
        public string Gpu {  get; set; }
        public string BatteryCapacity { get; set; }
        public string ExternalPorts { get; set; }
        public string Resolution { get; set; }
        public decimal ScreenDiagonal {  get; set; } //inches
        public string ScreenType { get; set; }
        public string OperatingSystem { get; set; }
    }
}
