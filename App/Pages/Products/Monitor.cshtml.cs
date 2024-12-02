using DataBaseContext;
using Domain.EntityModels.Products.OtherDevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;

namespace App.Pages.Products
{
    public class MonitorModel : ProductTemplatePageModel
    {
        public string Resolution { get; set; }
        public decimal ScreenDiagonal { get; set; } //inches
        public int ScreenRefreshRate { get; set; } //Hz
        public string ExternalPorts { get; set; }
        public string ScreenType { get; set; } // for example ips
        public bool BuiltInSpeakers { get; set; }
        public decimal Latency { get; set; } // in miliseconds

        protected override void initializeEssentialProductProperties(int productId)
        {
            //Initialize inherited properties from ProductModel
            base.initializeEssentialProductProperties(productId);

            MonitorScreen monitor = context.Monitors.Find(productId);

            Resolution = monitor.Resolution;
            ScreenDiagonal = monitor.ScreenDiagonal;
            ScreenRefreshRate = monitor.ScreenRefreshRate;
            ExternalPorts = monitor.ExternalPorts;
            ScreenType = monitor.ScreenType;
            BuiltInSpeakers = monitor.BuiltInSpeakers;
            Latency = monitor.Latency;
        }

        public MonitorModel(AppDbContext _context)
        : base(_context)
        {
        }
    }
}

