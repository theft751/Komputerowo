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
        const string TestDataDirectoryPath = "C:\\Users\\Miłosz\\source\\repos\\PracaInzynierska\\DataBaseContext\\Testdata";
        
        const string casesPath = "json\\Cases.json";
        const string desktopComputersPath = "json\\DesktopComputers.json";
        const string graphicCardsPath = "json\\GraphicCards.json";
        const string processorsPath = "json\\Processors.json";

        const string bonusImagesPath = "json\\BonusImages.json"; 
        const string mainImagesPath = "json\\MainImages.json";
        
        
        public static void Seed(AppDbContext context)
        {
            if (context.Database.EnsureCreated())
            {
                //json strings
                string casesJson;
                string desktopComputersJson;
                string processorsJson;
                string graphicCardsJson;

                string bonusImagesJson;
                string mainImagesJson;
                


                //Deserialized collections from json file declaration
                ICollection<Case> cases;
                ICollection<DesktopComputer> desktopComputers;
                ICollection<GraphicCard> graphicCards;
                ICollection<Processor> processors;

                ICollection<BonusImageSeedingModel> bonusImageSeedingModels;
                ICollection<MainImageSeedingModel> mainImageSeedingModels;

                //Reading data from json files
                try
                {
                    casesJson = File.ReadAllText($"{TestDataDirectoryPath }\\{casesPath}");
                    desktopComputersJson = File.ReadAllText($"{TestDataDirectoryPath}\\{desktopComputersPath}");
                    graphicCardsJson = File.ReadAllText($"{TestDataDirectoryPath}\\{graphicCardsPath}"); 
                    processorsJson = File.ReadAllText($"{TestDataDirectoryPath}\\{processorsPath}"); 

                    bonusImagesJson = File.ReadAllText($"{TestDataDirectoryPath}\\{bonusImagesPath}");
                    mainImagesJson = File.ReadAllText($"{TestDataDirectoryPath}\\{mainImagesPath}");

                }
                catch (FileNotFoundException)
                {
                    throw new FileNotFoundException("Json file cannot be found");
                }
                catch (FileLoadException)
                {
                    throw new FileLoadException("Json file cannot be loaded");
                }
                catch (Exception)
                {
                    throw new FileLoadException("An unidentified problem has occurred");
                }

                //Deserializing json data
                //try
                //{
                    cases = JsonSerializer.Deserialize<ICollection<Case>>(casesJson);
                    desktopComputers = JsonSerializer.Deserialize<ICollection<DesktopComputer>>(desktopComputersJson);
                    graphicCards = JsonSerializer.Deserialize<ICollection<GraphicCard>>(graphicCardsJson);
                    processors = JsonSerializer.Deserialize<ICollection<Processor>>(processorsJson);

                bonusImageSeedingModels = JsonSerializer.Deserialize<ICollection<BonusImageSeedingModel>>(bonusImagesJson);
                    mainImageSeedingModels = JsonSerializer.Deserialize<ICollection<MainImageSeedingModel>>(mainImagesJson);
                //}
                //catch
                //{
                    //throw new Exception("Json deserialization failed");
                //}

                //Converting bonusImageSeedingModels to BonusProductImages and mainImageSeedingModels to MainImages
                ICollection <BonusProductImage> bonusProductImages = convertToBonusImages(bonusImageSeedingModels);
                ICollection<MainProductImage> mainProductImages = convertToMainImages(mainImageSeedingModels);

                //Open database connection for sql queries
                context.Database.OpenConnection();
                
                //Adding MainProductsImages
                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [MainProductImages] ON");
                context.MainProductImages.AddRange(mainProductImages);
                context.SaveChanges();
                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [MainProductImages] OFF");

                //Adding Rams
                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [Products] ON");
                context.Cases.AddRange(cases);
                context.SaveChanges();
                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [Products] OFF");

                //Adding DesktopComputers
                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [Products] ON");
                context.DesktopComputers.AddRange(desktopComputers);
                context.SaveChanges();
                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [Products] OFF");

                //Adding GraphicCards
                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [Products] ON");
                context.GraphicCards.AddRange(graphicCards);
                context.SaveChanges();
                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [Products] OFF");

                //Adding Processors
                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [Products] ON");
                context.Processors.AddRange(processors);
                context.SaveChanges();

                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [Products] OFF");

                //Adding BonusProductsImages
                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [BonusProductImages] ON");
                context.BonusProductImages.AddRange(bonusProductImages);
                context.SaveChanges();
                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [BonusProductImages] OFF");

                //Close database connection for sql queries
                context.Database.CloseConnection();


            }
        }

       static ICollection<BonusProductImage> convertToBonusImages(ICollection<BonusImageSeedingModel> bonusImageSeedingModels)
        {
            ICollection<BonusProductImage> bonusProductImages = new List<BonusProductImage>();
            foreach(var element in bonusImageSeedingModels)
            {
                try
                {
                    byte[] imageData = File.ReadAllBytes($"{TestDataDirectoryPath}\\{element.Path}");
                    bonusProductImages.Add(new BonusProductImage()
                    {
                        Id = element.Id,
                        ProductId = element.ProductId,
                        Data = imageData,
                        Title = element.Title,
                        Type = element.Type
                    });
                }
                catch (FileNotFoundException) 
                {
                    throw new FileNotFoundException("Image file cannot be found");
                }
                catch (FileLoadException)
                {
                    throw new FileLoadException("Image file cannot be loaded");
                }
                catch (Exception)
                {
                    throw new FileLoadException("An unidentified problem has occurred");
                }
            }
            return bonusProductImages;

       }
        static ICollection<MainProductImage> convertToMainImages(ICollection<MainImageSeedingModel> bonusImageSeedingModels)
        {
            ICollection<MainProductImage> mainProductImages = new List<MainProductImage>();
            foreach (var element in bonusImageSeedingModels)
            {
                try
                {
                    byte[] imageData = File.ReadAllBytes($"{TestDataDirectoryPath}\\{element.Path}");
                    mainProductImages.Add(new MainProductImage()
                    {
                        Id = element.Id,
                        Data = imageData,
                        Title = element.Title,
                        Type = element.Type
                    });
                }
                catch (FileNotFoundException)
                {
                    throw new FileNotFoundException("Image file cannot be found");
                }
                catch (FileLoadException)
                {
                    throw new FileLoadException("Image file cannot be loaded");
                }
                catch (Exception)
                {
                    throw new FileLoadException("An unidentified problem has occurred");
                }
            }
            return mainProductImages;

        }
    }

}


