using Domain.EntityModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityModels.Products.OtherDevices
{
    public class Printer :Product
    {
        public string Destination { get; set; } //For example: for small office, For corporation, for home
        public int MonochromaticPrintingSpeed {  get; set; } //Pages per minute
        public string PrintTechnology { get; set; } //Laser, ink colour, monochromatic etc.
        public string MaxPrintingResolution { get; set; }
        public  string SupportedMediaTypes { get; set; } //Plain paper, Labels, Envelopes
        public string SupportedMediaFormats { get; set; } //For example A4, A5, A6
        public string Connectivity {  get; set; } //For example USB, Wi-Fi, LAN(Ethernet)
        public bool DuplexPrinting { get ; set; }
    }
}
