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

        const string caseImagesPath = "Images\\Case";
        const string desktopComputerImagesPath = "Images\\DesktopComputer";
        const string graphicCardImagesPath = "Images\\GraphicCard";
        const string motherboardImagesPath = "Images\\Motherboard";
        const string processorImagesPath = "Images\\Processor";
        const string ramImagesPath = "Images\\Ram";
        
        public static void Seed(AppDbContext context)
        {
            if (context.Database.EnsureCreated())
            {
                //json strings
                string casesJson;
                string desktopComputersJson;
                string processorsJson;
                string graphicCardsJson;
                string motherboardJson;
                string ramsJson;

                string bonusImagesJson;
                string mainImagesJson;
                


                //Deserialized collections from json file declaration
                ICollection<Case> cases;
                ICollection<DesktopComputer> desktopComputers;
                ICollection<GraphicCard> graphicCards;
                ICollection<Processor> processors;
                ICollection<MotherBoard> motherboards;
                ICollection<Ram> rams;

                ICollection<BonusImageSeedingModel> bonusImageSeedingModels;
                ICollection<MainImageSeedingModel> mainImageSeedingModels;

                //Reading data from json files

                casesJson = File.ReadAllText($"{testDataDirectoryPath}\\{casesPath}");
                desktopComputersJson = File.ReadAllText($"{testDataDirectoryPath}\\{desktopComputersPath}");
                graphicCardsJson = File.ReadAllText($"{testDataDirectoryPath}\\{graphicCardsPath}");
                processorsJson = File.ReadAllText($"{testDataDirectoryPath}\\{processorsPath}");
                motherboardJson = File.ReadAllText($"{testDataDirectoryPath}\\{motherboardsPath}");
                ramsJson = File.ReadAllText($"{testDataDirectoryPath}\\{ramsPath}");

                cases = JsonSerializer.Deserialize<ICollection<Case>>(casesJson);
                desktopComputers = JsonSerializer.Deserialize<ICollection<DesktopComputer>>(desktopComputersJson);
                graphicCards = JsonSerializer.Deserialize<ICollection<GraphicCard>>(graphicCardsJson);
                processors = JsonSerializer.Deserialize<ICollection<Processor>>(processorsJson);
                motherboards = JsonSerializer.Deserialize<ICollection<MotherBoard>>(motherboardJson);
                rams = JsonSerializer.Deserialize<ICollection<Ram>>(ramsJson);


                //Open database connection for sql queries
                context.Database.OpenConnection();

                //Adding MainProductsImages
                addMainImages(cases, caseImagesPath, context);
                addMainImages(desktopComputers, desktopComputerImagesPath, context);
                addMainImages(graphicCards, graphicCardImagesPath, context);
                addMainImages(motherboards, motherboardImagesPath, context);
                addMainImages(processors, processorImagesPath, context);
                addMainImages(rams, ramImagesPath, context);

                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [Products] ON");

                //Adding DesktopComputers
                context.Cases.AddRange(cases);
                context.DesktopComputers.AddRange(desktopComputers);
                context.GraphicCards.AddRange(graphicCards);
                context.Processors.AddRange(processors);
                context.MotherBoards.AddRange(motherboards);
                context.Rams.AddRange(rams);
                context.SaveChanges();

                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [Products] OFF");

                //Adding BonusProductsImages
                addBonusImages(context.Cases, caseImagesPath, context);
                addBonusImages(context.DesktopComputers, desktopComputerImagesPath, context); 
                addBonusImages(context.GraphicCards, graphicCardImagesPath, context);
                addBonusImages(context.MotherBoards, motherboardImagesPath, context);
                addBonusImages(context.Processors, processorImagesPath, context);
                addBonusImages(context.Rams, ramImagesPath, context);

                //Close database connection for sql queries
                context.Database.CloseConnection();


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
                    Caption = "BonusImage2",
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


