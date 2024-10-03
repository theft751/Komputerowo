using Model.DataModel.Additional.ComputerParts;
using Model.DataModel.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel.Products.ComputerParts
{
    public class Processor: Product
    {
        public int Cores { get; set; } //Amount of cores
        public int Threads { get; set; }
        public int Frequency { get; set; } //Frequency per Core
        public int CacheSize { get; set; } //Mb
        public bool IntegratedGpu {  get; set; }
        public bool hasCoolerIncluded { get; set; }

        //Navigation Property
        public ProcessorSocket ProcessorSocket{ get; set; }
        public ProcessorSerie ProcessorSerie{ get; set; }
    }
}
