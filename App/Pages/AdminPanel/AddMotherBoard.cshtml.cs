using DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.DataModel.Main;
using Model.DataModel.Products.ComputerParts;

namespace App.Pages.AdminPanel
{
    public class AddMotherBoardModel : AddProductModel
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
            MotherBoard product = new MotherBoard();

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

            context.Products.Add(product);
            context.SaveChanges();
            return Page();
        }

        public AddMotherBoardModel(AppDbContext _context)
            : base(_context) { }
    }
}
