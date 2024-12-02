using Domain.EntityModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityModels.Products.OtherDevices
{
    public class Mouse: Product
    {
        public int Dpi {  get; set; }
        public string Profile { get; set; } //Lefthanded or righthanded
        public string Connectivity { get; set; } //for example usb, or bluetooth or 2.4 GHz, also can has info about wire length
        public string Destination { get; set; } //for example to office or for gamers
        public int ButtonsAmount { get; set; }
        public string SensorType { get; set; } // Optical, Laser
        public bool Lighting { get; set; }
    }
}
