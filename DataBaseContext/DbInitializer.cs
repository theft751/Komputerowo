using DataBaseContext;
using Domain.AppModel;
using Domain.EntityModels.Main;
using Domain.EntityModels.Products.ComputerParts;
using Domain.EntityModels.Products.OtherDevices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataBaseContext
{
    //This static class initialize database with test data from json files
    public static class DbInitializer
    {
        //Path to Testdata folder
        const string testDataDirectoryPath = "C:\\Users\\Miłosz\\source\\repos\\PracaInzynierska\\DataBaseContext\\Testdata";
        
        const string casesPath = "json\\Cases.json";
        const string desktopComputersPath = "json\\DesktopComputers.json";
        const string graphicCardsPath = "json\\GraphicCards.json";
        const string processorsPath = "json\\Processors.json";
        const string motherboardsPath = "json\\MotherBoards.json";
        const string ramsPath = "json\\Rams.json";
        const string laptopsPath = "json\\Laptops.json";
        const string powerSuppliesPath = "json\\PowerSupplies.json";
        const string diskDrivesPath = "json\\DiskDrives.json";
        const string smartphonesPath = "json\\Smartphones.json";
        const string televisorsPath = "json\\Televisors.json";
        const string monitorsPath = "json\\Monitors.json";
        const string mousesPath = "json\\Mouses.json";
        const string keyboardsPath = "json\\Keyboards.json";
        const string printersPath = "json\\Printers.json";

        const string caseImagesPath = "Images\\Case";
        const string desktopComputerImagesPath = "Images\\DesktopComputer";
        const string graphicCardImagesPath = "Images\\GraphicCard";
        const string motherboardImagesPath = "Images\\Motherboard";
        const string processorImagesPath = "Images\\Processor";
        const string ramImagesPath = "Images\\Ram";
        const string laptopImagesPath = "Images\\Laptop";
        const string powerSupplyImagesPath = "Images\\PowerSupply";
        const string diskDrivesImagesPath = "Images\\DiskDrive";
        const string smartphoneImagesPath = "Images\\Smartphone";
        const string televisorImagesPath = "Images\\Televisor";
        const string monitorImagesPath = "Images\\Monitor";
        const string mouseImagesPath = "Images\\Mouse";
        const string keyboardImagesPath = "Images\\Keyboard";
        const string printerImagesPath = "Images\\Printer";

        public static void Seed(AppDbContext context)
        {
            if (context.Database.EnsureCreated())
            {
                //json strings
                string casesJson = File.ReadAllText($"{testDataDirectoryPath}\\{casesPath}"); ;
                string desktopComputersJson = File.ReadAllText($"{testDataDirectoryPath}\\{desktopComputersPath}"); ;
                string processorsJson = File.ReadAllText($"{testDataDirectoryPath}\\{processorsPath}");
                string graphicCardsJson = File.ReadAllText($"{testDataDirectoryPath}\\{graphicCardsPath}");
                string motherboardJson = File.ReadAllText($"{testDataDirectoryPath}\\{motherboardsPath}");
                string ramsJson = File.ReadAllText($"{testDataDirectoryPath}\\{ramsPath}");
                string laptopsJson = File.ReadAllText($"{testDataDirectoryPath}\\{laptopsPath}");
                string powerSuppliesJson = File.ReadAllText($"{testDataDirectoryPath}\\{powerSuppliesPath}");
                string diskDrivesJson = File.ReadAllText($"{testDataDirectoryPath}\\{diskDrivesPath}");
                string smartphonesJson = File.ReadAllText($"{testDataDirectoryPath}\\{smartphonesPath}");
                string televisorsJson = File.ReadAllText($"{testDataDirectoryPath}\\{televisorsPath}");
                string monitorsJson = File.ReadAllText($"{testDataDirectoryPath}\\{monitorsPath}");
                string mousesJson = File.ReadAllText($"{testDataDirectoryPath}\\{mousesPath}");
                string keyboardsJson = File.ReadAllText($"{testDataDirectoryPath}\\{keyboardsPath}");
                string printersJson = File.ReadAllText($"{testDataDirectoryPath}\\{printersPath}");

                //Deserialized collections from json files
                ICollection<Case> cases = JsonSerializer.Deserialize<ICollection<Case>>(casesJson);
                ICollection<DesktopComputer> desktopComputers = JsonSerializer.Deserialize<ICollection<DesktopComputer>>(desktopComputersJson);
                ICollection<GraphicCard> graphicCards = JsonSerializer.Deserialize<ICollection<GraphicCard>>(graphicCardsJson);
                ICollection<Processor> processors = JsonSerializer.Deserialize<ICollection<Processor>>(processorsJson);
                ICollection<MotherBoard> motherboards = JsonSerializer.Deserialize<ICollection<MotherBoard>>(motherboardJson);
                ICollection<Ram> rams = JsonSerializer.Deserialize<ICollection<Ram>>(ramsJson);
                ICollection<Laptop> laptops = JsonSerializer.Deserialize<ICollection<Laptop>>(laptopsJson);
                ICollection<PowerSupply> powerSupplies = JsonSerializer.Deserialize<ICollection<PowerSupply>>(powerSuppliesJson);
                ICollection<DiskDrive> diskDrives = JsonSerializer.Deserialize<ICollection<DiskDrive>>(diskDrivesJson);
                ICollection<Smartphone> smartphones = JsonSerializer.Deserialize<ICollection<Smartphone>>(smartphonesJson);
                ICollection<Televisor> televisors = JsonSerializer.Deserialize<ICollection<Televisor>>(televisorsJson);
                ICollection<MonitorScreen> monitors = JsonSerializer.Deserialize<ICollection<MonitorScreen>>(monitorsJson);
                ICollection<Mouse> mouses = JsonSerializer.Deserialize<ICollection<Mouse>>(mousesJson);
                ICollection<Keyboard> keyboards = JsonSerializer.Deserialize<ICollection<Keyboard>>(keyboardsJson);
                ICollection<Printer> printers = JsonSerializer.Deserialize<ICollection<Printer>>(printersJson);

                //Adding MainProductsImages
                addMainImages(cases, caseImagesPath, context);
                addMainImages(desktopComputers, desktopComputerImagesPath, context);
                addMainImages(graphicCards, graphicCardImagesPath, context);
                addMainImages(motherboards, motherboardImagesPath, context);
                addMainImages(processors, processorImagesPath, context);
                addMainImages(rams, ramImagesPath, context);
                addMainImages(laptops, laptopImagesPath, context);
                addMainImages(powerSupplies, powerSupplyImagesPath, context);
                addMainImages(diskDrives, diskDrivesImagesPath, context);
                addMainImages(smartphones, smartphoneImagesPath, context);
                addMainImages(televisors, televisorImagesPath, context);
                addMainImages(monitors, monitorImagesPath, context);
                addMainImages(mouses, mouseImagesPath, context);
                addMainImages(keyboards, keyboardImagesPath, context);
                addMainImages(printers, printerImagesPath, context);

                //Adding Products
                context.Cases.AddRange(cases);
                context.DesktopComputers.AddRange(desktopComputers);
                context.GraphicCards.AddRange(graphicCards);
                context.Processors.AddRange(processors);
                context.MotherBoards.AddRange(motherboards);
                context.Rams.AddRange(rams);
                context.Laptops.AddRange(laptops);
                context.PowerSupplies.AddRange(powerSupplies);
                context.DiskDrives.AddRange(diskDrives);
                context.Smartphones.AddRange(smartphones);
                context.Televisors.AddRange(televisors);
                context.Monitors.AddRange(monitors);
                context.Mouses.AddRange(mouses);
                context.Keyboards.AddRange(keyboards);
                context.Printers.AddRange(printers);  
                context.SaveChanges();

                context.BankAcountNumber.Add(new BankAcountNumber() { Number= "12 3456 7890 1234 5678 9012 3456" });

                //Adding BonusProductsImages
                addBonusImages(context.Cases, caseImagesPath, context);
                addBonusImages(context.DesktopComputers, desktopComputerImagesPath, context); 
                addBonusImages(context.GraphicCards, graphicCardImagesPath, context);
                addBonusImages(context.MotherBoards, motherboardImagesPath, context);
                addBonusImages(context.Processors, processorImagesPath, context);
                addBonusImages(context.Rams, ramImagesPath, context);
                addBonusImages(context.Laptops, laptopImagesPath, context);
                addBonusImages(context.PowerSupplies, powerSupplyImagesPath, context);
                addBonusImages(context.DiskDrives, diskDrivesImagesPath, context);
                addBonusImages(context.Smartphones, smartphoneImagesPath, context);
                addBonusImages(context.Televisors, televisorImagesPath, context);
                addBonusImages(context.Monitors, monitorImagesPath, context);
                addBonusImages(context.Mouses, mouseImagesPath, context);
                addBonusImages(context.Keyboards, keyboardImagesPath, context);
                addBonusImages(context.Printers, printerImagesPath, context);

                
            }
        }

        static void addBonusImages(IEnumerable<Product> products, string productImagePath, AppDbContext context)
        {
            byte[] bonusImage1Data = File.ReadAllBytes($"{testDataDirectoryPath}\\{productImagePath}\\BonusImage1.png");
            byte[] bonusImage2Data = File.ReadAllBytes($"{testDataDirectoryPath}\\{productImagePath}\\BonusImage2.png");
            byte[] bonusImage3Data = File.ReadAllBytes($"{testDataDirectoryPath}\\{productImagePath}\\BonusImage3.png");
            foreach (var product in products)
            {
                BonusProductImage bonusProductImage1 = new()
                {
                    ProductId = product.Id,
                    Data = bonusImage1Data,
                    Caption = "BonusImage1",
                    Type = "image/png"
                };
                BonusProductImage bonusProductImage2 = new()
                {
                    ProductId = product.Id,
                    Data = bonusImage2Data,
                    Caption = "BonusImage2",
                    Type = "image/png"
                };
                BonusProductImage bonusProductImage3 = new()
                {
                    ProductId = product.Id,
                    Data = bonusImage3Data,
                    Caption = "BonusImage3",
                    Type = "image/png"
                };
                context.BonusProductImages.Add(bonusProductImage1);
                context.BonusProductImages.Add(bonusProductImage2);
                context.BonusProductImages.Add(bonusProductImage3);
            }
            context.SaveChanges();
        }
        static void addMainImages (IEnumerable<Product> products, string productImagePath, AppDbContext context)
        {
            byte[] mainImageData = File.ReadAllBytes($"{testDataDirectoryPath}\\{productImagePath}\\MainImage.png");
            foreach (var product in products)
            {
                MainProductImage mainProductImage = new()
                {
                    Data = mainImageData,
                    Caption = "MainImage",
                    Type = "image/png"
                };
                context.Add(mainProductImage);
                context.SaveChanges();
                product.MainImageId = mainProductImage.Id;
            }
        }
    }
    
}


