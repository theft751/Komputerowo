using DataBaseContext;
using Domain.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.SqlServer.Server;
using Domain.EntityModels.Main;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;

namespace App.Pages.AdminPanel
{
    public class AddOrEditMotherBoardModel : AddOrEditProductModel
    {
        [BindProperty]
        public string Format { get; set; }

        [BindProperty]
        public string ProcessorSocket { get; set; }

        [BindProperty]
        public string Chipset { get; set; }

        [BindProperty]
        public string InternalSockets { get; set; }

        [BindProperty]
        public string ExternalSockets { get; set; }

        [BindProperty]
        public string SupportedMemoryTypes { get; set; }

        [BindProperty]
        public string SupportedMemoryTypesOC { get; set; }

        [BindProperty]
        public int RamSlots { get; set; }

        [BindProperty]
        public string ProcesorArchitecture { get; set; }

        [BindProperty]
        public string SupportedProcessorFamilies { get; set; }

        public override IActionResult OnPost()
        {      
            MotherBoard product = OperationMode == OperationMode.Add ? new MotherBoard() : context.MotherBoards.Find(Id);

            //set properties inherited from product 
            setProductEssentialProperties(product); ;

            //motherboard properties
            product.Format=Format;
            product.ProcessorSocket = ProcessorSocket;
            product.Chipset = Chipset;
            product.InternalSockets = InternalSockets;  
            product.ExternalSockets = ExternalSockets;
            product.SupportedMemoryTypes = SupportedMemoryTypes; 
            product.SupportedMemoryTypesOC = SupportedMemoryTypesOC;
            product.RamSlots = RamSlots;
            product.ProcesorArchitecture = ProcesorArchitecture;
            product.SupportedProcessorFamilies = SupportedProcessorFamilies;    

            if (OperationMode == OperationMode.Add) context.MotherBoards.Add(product);
            context.SaveChanges();
            return Page();
        }

        public override IActionResult OnGetEdit(int id)
        {
            MotherBoard product = context.MotherBoards.Find(id);

            //motherboard properties
            Format = product.Format;
            ProcessorSocket = product.ProcessorSocket;
            Chipset = product.Chipset;
            InternalSockets = product.InternalSockets;
            ExternalSockets = product.ExternalSockets;
            SupportedMemoryTypes = product.SupportedMemoryTypes;
            SupportedMemoryTypesOC = product.SupportedMemoryTypesOC;
            RamSlots = product.RamSlots;
            ProcesorArchitecture = product.ProcesorArchitecture;
            SupportedProcessorFamilies = product.SupportedProcessorFamilies;

            setProductEssentialPropertiesOnEdit(id);
            IFormFile a;
            
            return Page();
        }

        public AddOrEditMotherBoardModel(AppDbContext _context)
            : base(_context) { }
    }
}
