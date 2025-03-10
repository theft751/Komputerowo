using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;

namespace App.Pages.Products
{
    public class RamModel : ProductTemplatePageModel
    {
        public int TotalSize { get => SizePerChips * ChipsAmount; }
        public int SizePerChips { get; set; } //Gb
        public int ChipsAmount { get; set; }
        public int Frequency { get; set; }// MHz
        public bool Ligthing { get; set; }
        public string RamType { get; set; }
        public RamModel(AppDbContext _context)
            : base(_context)
        {
        }
        protected override void initializeEssentialProductProperties(int productId)
        {
            base.initializeEssentialProductProperties(productId);
            Ram ram = context.Rams.Find(productId);

            SizePerChips = ram.SizePerChips;
            ChipsAmount = ram.ChipsAmount;
            Frequency = ram.Frequency;
            Ligthing = ram.Ligthing;
            RamType = ram.RamType;
        }
    }
}
