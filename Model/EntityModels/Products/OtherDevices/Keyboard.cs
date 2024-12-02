using Domain.EntityModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityModels.Products.OtherDevices
{
    public class Keyboard :Product
    {
        public string SwitchType {  get; set; } //For example mechanical, membrane, hybrid etc.
        public string Connectivity { get; set; } //for example usb, or bluetooth or 2.4 GHz, also can has info about wire length
        public string Destination { get; set; } //for example to office or for gamers
        public string Profile { get; set; } ////Low-profile or high-profile or other one
        public bool Lighting { get; set; }
        public bool NumericKeypad {  get; set; }
    }
}
