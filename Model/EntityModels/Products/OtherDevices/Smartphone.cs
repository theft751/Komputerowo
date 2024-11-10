using Model.EntityModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EntityModels.Products.OtherDevices
{
    public class Smartphone :Product
    {
        public string BackCamera {  get; set; }
        public string FrontCamera { get; set; }

        public string Resolution { get; set; }
        public decimal ScreenDiagonal { get; set; } //inches
        public int ScreenRefreshRate { get; set; } //Hz

        public string Processor {  get; set; }
        public int RamSize { get; set; }
        public int EmbeddedMemorySize { get; set; }
        public string OperatingSystem { get; set; }
        public string ExternalPorts { get; set; }

        public int BatteryCapacity { get; set; }

        public bool Nfc { get; set; }
        public bool FingPrinterReader { get; set; }

    }
}
