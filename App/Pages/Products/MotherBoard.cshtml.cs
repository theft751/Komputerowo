using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;
using Microsoft.CodeAnalysis;

namespace App.Pages.Products
{
    public class MotherBoardModel : ProductPageModel
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
        protected override void initializeEssentialProductProperties(int productId)
        {
            //Initialize inherited properties from ProductModel
            base.initializeEssentialProductProperties(productId);

            MotherBoard motherBoard = context.MotherBoards.Find(productId);

            //Initialize properties specific for DesktopComputer
            Format = motherBoard.Format;
            ProcessorSocket = motherBoard.ProcessorSocket;
            Chipset = motherBoard.Chipset;
            InternalSockets = motherBoard.InternalSockets;
            ExternalSockets = motherBoard.ExternalSockets;
            SupportedMemoryTypes = motherBoard.SupportedMemoryTypes;
            SupportedMemoryTypesOC = motherBoard.SupportedMemoryTypesOC;
            ProcesorArchitecture = motherBoard.ProcesorArchitecture;
            SupportedProcessorFamilies = motherBoard.SupportedProcessorFamilies;
            RamSlots = motherBoard.RamSlots;
        }
        MotherBoardModel(AppDbContext _context)
            : base(_context)
        {
        }
    }
}
