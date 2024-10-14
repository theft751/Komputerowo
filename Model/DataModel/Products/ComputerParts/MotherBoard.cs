using Model.DataModel.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel.Products.ComputerParts
{
    public class MotherBoard: Product
    {
        public string Format { get; set; }
        public string ProcessorSocket { get; set; }
        public string Chipset { get; set; }
        public string InternalSockets { get; set; }
        public string ExternalSockets { get; set; }
        public string SupportedMemoryTypes { get; set; }
        public string SupportedMemoryTypesOC { get; set; }
        public string ProcesorArchitecture { get; set; }
        public string SupportedProcessorFamilies { get; set; }
        public int RamSlots { get; set; }
    }
}
