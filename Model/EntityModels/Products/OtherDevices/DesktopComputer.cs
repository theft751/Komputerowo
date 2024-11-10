using Model.EntityModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EntityModels.Products.OtherDevices
{
    public class DesktopComputer : Product
    {
        public string Processor {  get; set; }
        public string Chipset { get; set; }
        public string Gpu {  get; set; }
        public string GpuMemoryType { get; set; }
        public int GpuMemorySize { get; set; }
        public string RamType { get; set; }
        public int RamSize { get; set; }
        public string DiskType { get; set; }
        public int DiskSize { get; set; }
        public string ExternalPorts { get; set; }
        public string InternalPorts {  get; set; }
        public int PowerSupply { get; set; } //In watts
        public string OperatingSystem { get; set; }
    }
}
