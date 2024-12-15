using DataBaseContext;
using Domain.AppModel;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Domain.EntityModels.Main;
using Domain.EntityModels.Additional.Common;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;

namespace App.Pages.Shared.Components
{
    public class ProductViewComponent : ViewComponent
    {
        AppDbContext context;

        public async Task<IViewComponentResult> InvokeAsync(int id, ViewMode viewMode, int? amountInBasket = null)
        {
            ProductType productType = context.Products.Find(id).ProductType;
            ProductVm ProductVm = new ProductVm();
            var linkGenerator = HttpContext.RequestServices.GetService<LinkGenerator>();
            string mainImageUrl;

            switch (productType)
            {
                case ProductType.Case:
                    mainImageUrl = linkGenerator.GetPathByPage("/products/case", "MainImage", new { productId = id });
                    Case computerCase = context.Cases.Find(id);
                    ProductVm = new ProductVm(computerCase, mainImageUrl, viewMode, amountInBasket);
                break;

                case ProductType.DiskDrive:
                    mainImageUrl = linkGenerator.GetPathByPage("/products/diskdrive", "MainImage", new { productId = id });
                    DiskDrive diskDrive = context.DiskDrives.Find(id);
                    ProductVm = new ProductVm(diskDrive, mainImageUrl, viewMode, amountInBasket);
                    break;

                case ProductType.GraphicCard:
                    mainImageUrl = linkGenerator.GetPathByPage("/products/graphiccard", "MainImage", new { productId = id });
                    GraphicCard graphicCard = context.GraphicCards.Find(id);
                    ProductVm = new ProductVm(graphicCard, mainImageUrl, viewMode, amountInBasket);
                    break;

                case ProductType.Motherboard:
                    mainImageUrl = linkGenerator.GetPathByPage("/products/motherboard", "MainImage", new { productId = id });
                    MotherBoard motherBoard = context.MotherBoards.Find(id);
                    ProductVm = new ProductVm(motherBoard, mainImageUrl, viewMode, amountInBasket);
                    break;

                case ProductType.PowerSupply:
                    mainImageUrl = linkGenerator.GetPathByPage("/products/powersupply", "MainImage", new { productId = id });
                    PowerSupply powerSupply = context.PowerSupplies.Find(id);
                    ProductVm = new ProductVm(powerSupply, mainImageUrl, viewMode, amountInBasket);
                    break;

                case ProductType.Processor:
                    mainImageUrl = linkGenerator.GetPathByPage("/products/processor", "MainImage", new { productId = id });
                    Processor processor = context.Processors.Find(id);
                    ProductVm = new ProductVm(processor, mainImageUrl, viewMode, amountInBasket);
                    break;

                case ProductType.Ram:
                    mainImageUrl = linkGenerator.GetPathByPage("/products/ram", "MainImage", new { productId = id });
                    Ram ram = context.Rams.Find(id);
                    ProductVm = new ProductVm(ram, mainImageUrl, viewMode, amountInBasket);
                    break;

                case ProductType.DesktopComputer:
                    mainImageUrl = linkGenerator.GetPathByPage("/products/desktopcomputer", "MainImage", new { productId = id });
                    DesktopComputer desktopComputer = context.DesktopComputers.Find(id);
                    ProductVm = new ProductVm(desktopComputer, mainImageUrl, viewMode, amountInBasket);
                    break;

                case ProductType.Keyboard:
                    mainImageUrl = linkGenerator.GetPathByPage("/products/keyboard", "MainImage", new { productId = id });
                    Keyboard keyboard = context.Keyboards.Find(id);
                    ProductVm = new ProductVm(keyboard, mainImageUrl, viewMode, amountInBasket);
                    break;

                case ProductType.Laptop:
                    mainImageUrl = linkGenerator.GetPathByPage("/products/laptop", "MainImage", new { productId = id });
                    Laptop laptop = context.Laptops.Find(id);
                    ProductVm = new ProductVm(laptop, mainImageUrl, viewMode, amountInBasket);
                    break;

                case ProductType.Monitor:
                    mainImageUrl = linkGenerator.GetPathByPage("/products/monitor", "MainImage", new { productId = id });
                    MonitorScreen monitor = context.Monitors.Find(id);
                    ProductVm = new ProductVm(monitor, mainImageUrl, viewMode, amountInBasket);
                    break;

                case ProductType.Mouse:
                    mainImageUrl = linkGenerator.GetPathByPage("/products/mouse", "MainImage", new { productId = id });
                    Mouse mouse = context.Mouses.Find(id);
                    ProductVm = new ProductVm(mouse, mainImageUrl, viewMode, amountInBasket);
                    break;

                case ProductType.Printer:
                    mainImageUrl = linkGenerator.GetPathByPage("/products/printer", "MainImage", new { productId = id });
                    Printer printer = context.Printers.Find(id);
                    ProductVm = new ProductVm(printer, mainImageUrl, viewMode, amountInBasket);
                    break;

                case ProductType.Smartphone:
                    mainImageUrl = linkGenerator.GetPathByPage("/products/smartphone", "MainImage", new { productId = id });
                    Smartphone smartphone = context.Smartphones.Find(id);
                    ProductVm = new ProductVm(smartphone, mainImageUrl, viewMode, amountInBasket);
                    break;

                case ProductType.Televisor:
                    mainImageUrl = linkGenerator.GetPathByPage("/products/case", "MainImage", new { productId = id });
                    Televisor televisor = context.Televisors.Find(id);
                    ProductVm = new ProductVm(televisor, mainImageUrl, viewMode, amountInBasket);
                    break;

            }




            return View(ProductVm);
        }
        public ProductViewComponent(AppDbContext _context)
        {
            this.context = _context;
        }
    }
}
